using System;

namespace NetFabric
{
    public partial struct Angle
    {
        static int Compare(double d1, double d2)
        {
            return double.CompareTo(d1, d2);
        }

        static string FormatString(int value, string format, IFormatProvider formatProvider)
        {
            return value.ToString(format);
        }

        static string FormatString(double value, string format, IFormatProvider formatProvider)
        {
            return value.ToString(format);
        }

        static void ThrowArgumentOutOfRange(string paramName, object paramValue, string message)
        {
            throw new ArgumentOutOfRangeException(
                paramName,
                message);
        }

        static void ThrowFormatException(string format)
        {
            throw new Exception("The '" + format + "' format string is not supported.");
        }
    }
}
