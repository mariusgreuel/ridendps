using System;

namespace DPS
{
    public class Options : CommandLineOptions
    {
        public bool Validate()
        {
            if (gui)
                return true;

            if (port != null)
            {
                if (id)
                    return true;

                if (dump != null)
                    return true;

                if (voltage != null || current != null)
                    return true;

                if (vlimit != null || climit != null || plimit != null)
                    return true;

                if (brightness != null)
                    return true;

                if (print)
                    return true;

                if (select)
                    return true;

                if (on || off)
                    return true;
            }

            return false;
        }

        [CommandLineOption(Alias = "p", Arguments = "COMx", Description = "Specifies the communication port")]
        public string port = null;

        [CommandLineOption(Alias = "b", Arguments = "9600", Description = "Specifies the communication port baudrate")]
        public int baudrate = 9600;

        [CommandLineOption(Alias = "a", Arguments = "x", Description = "Specifies the MODBUS slave address")]
        public int address = 1;

        [CommandLineOption(Description = "Print the DPS ID")]
        public bool id = false;

        [CommandLineOption(Alias = "m", Arguments = "x", Description = "Specifies the dataset memory")]
        public int dataset = 0;

        [CommandLineOption(Alias = "v", Arguments = "x", Description = "Sets the voltage [V]")]
        public string voltage = null;

        [CommandLineOption(Alias = "c", Arguments = "x", Description = "Sets the current [A]")]
        public string current = null;

        [CommandLineOption(Alias = "vl", Arguments = "x", Description = "Sets the voltage limit [V]")]
        public string vlimit = null;

        [CommandLineOption(Alias = "cl", Arguments = "x", Description = "Sets the current limit [A]")]
        public string climit = null;

        [CommandLineOption(Alias = "pl", Arguments = "x", Description = "Sets the power limit [W]")]
        public string plimit = null;

        [CommandLineOption(Alias = "l", Arguments = "x", Description = "Sets the brightness level [0..5]")]
        public string brightness = null;

        [CommandLineOption(Alias = "x", Description = "Selects the specified dataset")]
        public bool select = false;

        [CommandLineOption(Description = "Prints the specified dataset")]
        public bool print = false;

        [CommandLineOption(Alias = "e", Description = "Enable the output")]
        public bool on = false;

        [CommandLineOption(Alias = "d", Description = "Disable the output")]
        public bool off = false;

        [CommandLineOption(Description = "Dump register range")]
        public string dump = null;

        [CommandLineOption(Description = "Show the GUI")]
        public bool gui = false;

        [CommandLineOption(Description = "Enable verbose communication output")]
        public bool verbose = false;

        [CommandLineOption(Alias = "?", Category = "Miscellaneous", Description = "Display full help")]
        public bool help = false;
    }
}
