using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace DPS
{
    public class CommandLineOptionAttribute : Attribute
    {
        public CommandLineOptionAttribute()
        {
        }

        public string Name { get; set; }
        public string Alias { get; set; }
        public string Category { get; set; }
        public string Arguments { get; set; }
        public string Description { get; set; }
        public bool Extended { get; set; }
        public string FriendlyName => "-" + Name + (Arguments != null ? " <" + Arguments + ">" : "");
    }

    public abstract class CommandLineOptions
    {
        class CommandLineException : ApplicationException
        {
            public CommandLineException(string message, params object[] args)
                : base(string.Format(message, args))
            {
            }
        }

        public static T LoadFromFile<T>(string path)
        {
            using (XmlTextReader reader = new XmlTextReader(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.UnknownElement += new XmlElementEventHandler(serializer_UnknownElement);
                serializer.UnknownAttribute += new XmlAttributeEventHandler(serializer_UnknownAttribute);
                return (T)serializer.Deserialize(reader);
            }
        }

        public void ParseArguments(string arguments)
        {
            ParseArguments(SplitArguments(arguments));
        }

        public void ParseArguments(string[] arguments)
        {
            for (int i = 0; i < arguments.Length; i++)
            {
                string argument = arguments[i];
                if (argument.StartsWith("-") || argument.StartsWith("/"))
                {
                    string option = argument.Substring(1);

                    bool hasModifier = option.EndsWith("+") || option.EndsWith("-");
                    string name = hasModifier ? option.Substring(0, option.Length - 1) : option;

                    Type type = GetMemberType(name);
                    if (type == null || hasModifier && type != typeof(bool))
                        throw new CommandLineException("Unknown option '{0}'", argument);

                    if (type == typeof(bool))
                    {
                        bool value = !option.EndsWith("-");
                        SetMemberValue(name, value);
                    }
                    else if (type == typeof(int))
                    {
                        if (i + 1 >= arguments.Length)
                            throw new CommandLineException("Missing argument for option '{0}'", argument);

                        int value;
                        if (!int.TryParse(arguments[++i], out value))
                            throw new CommandLineException("Invalid input string for option '{0}'", argument);

                        SetMemberValue(name, value);
                    }
                    else if (type == typeof(uint))
                    {
                        if (i + 1 >= arguments.Length)
                            throw new CommandLineException("Missing argument for option '{0}'", argument);

                        uint value;
                        if (!uint.TryParse(arguments[++i], out value))
                            throw new CommandLineException("Invalid input string for option '{0}'", argument);

                        SetMemberValue(name, value);
                    }
                    else if (type == typeof(string))
                    {
                        if (i + 1 >= arguments.Length)
                            throw new CommandLineException("Missing argument for option '{0}'", argument);

                        string value = arguments[++i];
                        SetMemberValue(name, value);
                    }
                    else if (type == typeof(List<string>))
                    {
                        if (i + 1 >= arguments.Length)
                            throw new CommandLineException("Missing argument for option '{0}'", argument);

                        string[] values = arguments[++i].Split(',');
                        foreach (string value in values)
                        {
                            AddMemberValue(name, value.Trim());
                        }
                    }
                    else if (type.IsEnum)
                    {
                        if (i + 1 >= arguments.Length)
                            throw new CommandLineException("Missing argument for option '{0}'", argument);

                        string value = arguments[++i];
                        SetMemberValue(name, Enum.Parse(type, value));
                    }
                    else
                    {
                        throw new CommandLineException("Unknown option type '{0}'", argument);
                    }
                }
                else if (argument.StartsWith("@"))
                {
                    string file = argument.Substring(1);

                    try
                    {
                        using (StreamReader reader = new StreamReader(file))
                        {
                            while (!reader.EndOfStream)
                            {
                                string line = reader.ReadLine();
                                if (line.StartsWith("#"))
                                    continue;

                                try
                                {
                                    ParseArguments(line);
                                }
                                catch (CommandLineException exception)
                                {
                                    throw new CommandLineException("While processing response file '{0}': {1}", file, exception.Message);
                                }
                            }
                        }
                    }
                    catch (ArgumentException exception)
                    {
                        throw new CommandLineException("Failed to open response file '{0}': {1}", file, exception.Message);
                    }
                    catch (IOException exception)
                    {
                        throw new CommandLineException("Failed to open response file '{0}': {1}", file, exception.Message);
                    }
                }
                else
                {
                    fixedArguments.Add(argument);
                }
            }
        }

        public void WriteUsage()
        {
            WriteUsage(null);
        }

        public void WriteUsage(string extraInformation)
        {
            Type type = GetType();

            FieldInfo helpFieldInfo = GetField("?");
            bool showExtendedHelp = helpFieldInfo != null ? (bool)helpFieldInfo.GetValue(this) : false;

            var categories = new Dictionary<string, List<CommandLineOptionAttribute>>();

            categories.Add("", new List<CommandLineOptionAttribute>());

            int maxWidth = 0;

            foreach (FieldInfo fieldInfo in type.GetFields())
            {
                foreach (object attribute in fieldInfo.GetCustomAttributes(true))
                {
                    if (attribute is CommandLineOptionAttribute)
                    {
                        CommandLineOptionAttribute optionAttribute = (CommandLineOptionAttribute)attribute;

                        if (optionAttribute.Name == null)
                            optionAttribute.Name = fieldInfo.Name;

                        maxWidth = Math.Max(maxWidth, optionAttribute.FriendlyName.Length);

                        string category = "";
                        if (showExtendedHelp && optionAttribute.Category != null)
                            category = optionAttribute.Category;

                        List<CommandLineOptionAttribute> options;
                        if (!categories.TryGetValue(category, out options))
                        {
                            options = new List<CommandLineOptionAttribute>();
                            categories.Add(category, options);
                        }

                        options.Add(optionAttribute);

                        break;
                    }
                }
            }

            foreach (KeyValuePair<string, List<CommandLineOptionAttribute>> category in categories)
            {
                if (category.Key != "")
                {
                    Console.WriteLine();
                    Console.WriteLine(new string(' ', maxWidth) + "===" + category.Key + "===");
                }

                foreach (CommandLineOptionAttribute optionAttribute in category.Value)
                {
                    if (!optionAttribute.Extended || showExtendedHelp)
                    {
                        string name = optionAttribute.FriendlyName;
                        string description = optionAttribute.Description;
                        string space = new string(' ', maxWidth - optionAttribute.FriendlyName.Length + 1);

                        string option = "    " + name + space;
                        Console.WriteLine(option + WrapString(option.Length, description));
                    }
                }
            }

            if (showExtendedHelp && extraInformation != null)
            {
                Console.WriteLine();
                Console.WriteLine(extraInformation);
            }
        }

        public List<string> FixedArguments
        {
            get { return fixedArguments; }
        }

        string[] SplitArguments(string input)
        {
            List<string> arguments = new List<string>();

            char[] line = input.ToCharArray();

            int i = 0;
            while (i < line.Length)
            {
                // Skip whitespace.
                if (IsWhiteSpace(line[i]))
                {
                    i++;
                    continue;
                }

                string argument = string.Empty;

                while (i < line.Length && !IsWhiteSpace(line[i]))
                {
                    if (line[i] == '"')
                    {
                        char quoteChar = line[i++];
                        if (line[i] == quoteChar)
                        {
                            // Double-quote found, insert quote.
                            argument += line[i++];
                        }
                        else
                        {
                            // Quoted string. Consume until closing quote is found.
                            while (i < line.Length)
                            {
                                if (line[i] == quoteChar || IsEndOfLineChar(line[i]))
                                    break;

                                argument += line[i++];
                            }

                            if (line[i] == quoteChar)
                            {
                                i++;
                            }
                        }
                    }
                    else
                    {
                        // Normal string. Consume until separation chars are found.
                        while (i < line.Length)
                        {
                            if (IsWhiteSpace(line[i]) || line[i] == '"')
                                break;

                            argument += line[i++];
                        }
                    }
                }

                if (argument.Length > 0)
                {
                    arguments.Add(argument);
                }
            }

            return arguments.ToArray();
        }

        static bool IsWhiteSpace(char ch)
        {
            return ch == ' ' || ch == '\t' || ch == '\n' || ch == '\r';
        }

        static bool IsEndOfLineChar(char ch)
        {
            return ch == '\n' || ch == '\r';
        }

        FieldInfo GetField(string name)
        {
            Type type = GetType();

            foreach (FieldInfo fieldInfo in type.GetFields())
            {
                if (string.Compare(fieldInfo.Name, name, true) == 0)
                {
                    return fieldInfo;
                }

                foreach (object attribute in fieldInfo.GetCustomAttributes(true))
                {
                    if (attribute is CommandLineOptionAttribute)
                    {
                        CommandLineOptionAttribute optionAttribute = (CommandLineOptionAttribute)attribute;
                        if (string.Compare(optionAttribute.Name, name, true) == 0)
                        {
                            return fieldInfo;
                        }
                        else if (string.Compare(optionAttribute.Alias, name, true) == 0)
                        {
                            return fieldInfo;
                        }
                    }
                }
            }

            return null;
        }

        Type GetMemberType(string name)
        {
            FieldInfo fieldInfo = GetField(name);
            return fieldInfo != null ? fieldInfo.FieldType : null;
        }

        void SetMemberValue(string name, object value)
        {
            FieldInfo fieldInfo = GetField(name);
            fieldInfo.SetValue(this, value);
        }

        void AddMemberValue(string name, object value)
        {
            FieldInfo fieldInfo = GetField(name);
            IList list = (IList)fieldInfo.GetValue(this);
            list.Add(value);
        }

        static string CenterString(string text)
        {
            int width = Console.WindowWidth - 1;
            if (text.Length >= width)
                return text;

            return new string(' ', (width - text.Length) / 2) + text;
        }

        static string WrapString(int column, string text)
        {
            int width = Console.WindowWidth - 1;
            if (column >= width)
                return text;

            width -= column;

            string wrappedText = "";

            while (text.Length > width)
            {
                int pos = width;
                while (pos > 0 && !IsWhiteChar(text[pos]))
                    pos--;

                if (pos == 0)
                {
                    while (pos < text.Length && !IsWhiteChar(text[pos]))
                        pos++;
                }

                wrappedText += text.Substring(0, pos).TrimEnd();
                wrappedText += Environment.NewLine;
                wrappedText += new string(' ', column);
                text = text.Substring(pos).TrimStart();
            }

            return wrappedText + text;
        }

        static bool IsWhiteChar(char ch)
        {
            return ch == '\t' || ch == ' ';
        }

        static void serializer_UnknownElement(object sender, XmlElementEventArgs e)
        {
            throw new CommandLineException("Unknown element '{0}'", e.Element.Name);
        }

        static void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            throw new CommandLineException("Unknown attribute '{0}'", e.Attr.Name);
        }

        List<string> fixedArguments = new List<string>();
    }
}
