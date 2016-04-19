using System;

namespace NetFabric
{
    public partial struct Angle
        : IEquatable<Angle>
        , IComparable
        , IComparable<Angle>
    {

        /// <summary>
        /// Compares this instance to a specified Angle object and returns an integer that indicates whether this instance is shorter than, equal to, or longer than the Angle object.
        /// </summary>
        /// <param name="value">An object to compare to this instance.</param>
        /// <returns>-1 if a1 is smaller than a2; 0 if a1 equals to a2; 1 if a1 is larger than a2.</returns>
        /// <remarks>This method implements the System.IComparable&lt;T&gt; interface, and performs slightly better than <see cref="Angle.CompareTo(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public int CompareTo(Angle value)
        {
            return radians.CompareTo(value.radians);
        }

        /// <summary>
        /// Compares this instance to a specified Angle object and returns an integer that indicates whether this instance is shorter than, equal to, or longer than the Angle object.
        /// </summary>
        /// <param name="obj">An object to compare to this instance.</param>
        /// <returns>-1 if a1 is smaller than a2; 0 if a1 equals to a2; 1 if a1 is larger than a2.</returns>
        /// <exception cref="ArgumentException">value is not an Angle.</exception>
        public int CompareTo(object obj)
        {
            if (!(obj is Angle))
                throw new ArgumentException("Argument has to be an Angle.", "value");
            return this.CompareTo((Angle)obj);
        }

        static int Compare(double d1, double d2)
        {
            return d1.CompareTo(d2);
        }

        static void ThrowArgumentOutOfRange(string paramName, object paramValue, string message)
        {
            throw new ArgumentOutOfRangeException(
                paramName,
                paramValue,
                message);
        }
    }
}
