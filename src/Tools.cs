using System.Globalization;

namespace Riden
{
    class Tools
    {
        public static string FormatValue(double value, string format)
        {
            return value.ToString(format, CultureInfo.InvariantCulture);
        }

        public static int ParseInteger(string text)
        {
            return TryParseValue(text, out int value) ? value : 0;
        }

        public static double ParseDouble(string text)
        {
            return TryParseValue(text, out double value) ? value : double.NaN;
        }

        public static bool TryParseValue(string text, out int value)
        {
            if (text == null)
            {
                value = 0;
                return false;
            }

            return int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out value);
        }

        public static bool TryParseValue(string text, out double value)
        {
            if (text == null)
            {
                value = double.NaN;
                return false;
            }

            var dot = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            var styles = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite;
            return double.TryParse(text.Replace(dot, "."), styles, CultureInfo.InvariantCulture, out value);
        }
    }
}
