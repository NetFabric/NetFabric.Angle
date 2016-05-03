using System;

namespace NetFabric
{
    public partial struct Angle
    {
        #region string format

        /// <summary>
        /// Converts the value of the current Angle object to its equivalent string representation, using a specified format.
        /// </summary>
        /// <param name="format">A string that specifies the format to be used for the returned string.</param>
        /// <returns>A string representation of the value of the current Angle object, in the specified format.</returns>
        public string ToString(string format)
        {
            if (format == null || format.Length == 0)
                format = formatDegrees;

            format = format.Trim().ToUpper(); 

            switch (format)
            {
                case formatRadians:
                    return ToRadians().ToString("G");
                case formatDegrees:
                    return ToDegrees().ToString("G");
                case formatGradians:
                    return ToGradians().ToString("G");
                default:
                    ThrowFormatException(format);
                    break;
            }

            throw new InvalidOperationException(); // should not get here
        }

#endregion


        static int Compare(double d1, double d2)
        {
            return double.CompareTo(d1, d2);
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
