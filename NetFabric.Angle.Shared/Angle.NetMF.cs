using System;

namespace NetFabric
{
    public partial struct Angle
    {
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
    }
}
