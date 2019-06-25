using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    [Serializable]
    public readonly partial struct AngleGradians
        : IEquatable<AngleGradians>
        , IComparable
        , IComparable<AngleGradians>
        , IFormattable
    {
        /// <summary>
        /// Represents a AngleGradians value that is not a number (NaN). This field is read-only.
        /// </summary>
        public static readonly AngleGradians NaN = new AngleGradians(double.NaN);

        /// <summary>
        /// Represents the zero AngleGradians value (0 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleGradians Zero = new AngleGradians(0.0);

        /// <summary>
        /// Represents the golden AngleGradians value (~137.508 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleGradians Golden = Angle.InGradians(AngleRadians.Golden);

        /// <summary>
        /// Represents the smallest possible value of a AngleGradians. This field is read-only.
        /// </summary>
        public static readonly AngleGradians MinValue = new AngleGradians(double.MinValue);

        /// <summary>
        /// Represents the largest possible value of a AngleGradians. This field is read-only.
        /// </summary>
        public static readonly AngleGradians MaxValue = new AngleGradians(double.MaxValue);

        /// <summary>
        /// Represents the right AngleGradians value (90 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleGradians Right = new AngleGradians(RightAngle);

        /// <summary>
        /// Represents the straight AngleGradians value (180 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleGradians Straight = new AngleGradians(StraightAngle);

        /// <summary>
        /// Represents the full AngleGradians value (360 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleGradians Full = new AngleGradians(FullAngle);

        /// <summary>
        /// Gets the amplitude of the angle in degrees. This field is read-only.
        /// </summary>
        public readonly double Gradians;

        internal AngleGradians(double degrees)
        {
            Gradians = degrees;
        }

        #region equality implementation

        /// <summary>
        /// Indicates whether two AngleGradians instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator ==(AngleGradians a1, AngleGradians a2) =>
            a1.Gradians == a2.Gradians;

        /// <summary>
        /// Indicates whether two AngleGradians instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator !=(AngleGradians a1, AngleGradians a2) =>
            a1.Gradians != a2.Gradians;

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified AngleGradians object.
        /// </summary>
        /// <param name="other">An AngleGradians to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="AngleGradians.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public bool Equals(AngleGradians other) =>
            Gradians == other.Gradians;

        #endregion

        #region comparison implementation

        /// <summary>
        /// Indicates whether a specified AngleGradians is less than another specified AngleGradians.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than the value of a2; otherwise, false.</returns>
        public static bool operator <(AngleGradians a1, AngleGradians a2) =>
            a1.Gradians < a2.Gradians;

        /// <summary>
        /// Indicates whether a specified AngleGradians is less than or equal to another specified AngleGradians.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator <=(AngleGradians a1, AngleGradians a2) =>
            a1.Gradians <= a2.Gradians;

        /// <summary>
        /// Indicates whether a specified AngleGradians is greater than another specified AngleGradians.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than the value of a2; otherwise, false.</returns>
        public static bool operator >(AngleGradians a1, AngleGradians a2) =>
            a1.Gradians > a2.Gradians;

        /// <summary>
        /// Indicates whether a specified AngleGradians is greater than or equal to another specified AngleGradians.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator >=(AngleGradians a1, AngleGradians a2) =>
            a1.Gradians >= a2.Gradians;

        int IComparable<AngleGradians>.CompareTo(AngleGradians other) =>
            Gradians.CompareTo(other.Gradians);

        int IComparable.CompareTo(object obj)
        {
            switch (obj)
            {
                case AngleGradians angle:
                    return Gradians.CompareTo(angle.Gradians);
                default:
                    return ThrowHelper.ThrowArgumentException<int>(nameof(obj), $"Argument has to be an {nameof(AngleGradians)}.");
            }
        }

        #endregion

        #region math operators

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleGradians operator -(AngleGradians angle) =>
            new AngleGradians(-angle.Gradians);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleGradians operator +(AngleGradians left, AngleGradians right) =>
            new AngleGradians(left.Gradians + right.Gradians);

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleGradians operator -(AngleGradians left, AngleGradians right) =>
            new AngleGradians(left.Gradians - right.Gradians);

        /// <summary>
        /// Multiplies a scalar by an angle value. 
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleGradians operator *(double left, AngleGradians right) =>
            new AngleGradians(left * right.Gradians);

        /// <summary>
        /// Divides a angle by a scalar value. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleGradians operator /(AngleGradians left, double right) =>
            new AngleGradians(left.Gradians / right);

        #endregion

        #region string format

        /// <summary>
        /// Converts the value of the current AngleGradians object to its equivalent string representation, using a specified format.
        /// </summary>
        /// <param name="format">A string that specifies the format to be used for the returned string.</param>
        /// <returns>A string representation of the value of the current AngleGradians object, in the specified format.</returns>
        public string ToString(string format) =>
            Gradians.ToString(format);

        /// <summary>
        /// Converts the value of the current AngleGradians object to its equivalent string representation using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current AngleGradians object as specified by format and provider.</returns>
        public string ToString(string format, IFormatProvider formatProvider) =>
            Gradians.ToString(format, formatProvider);

        #endregion

        #region object overrides

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>true if value is a AngleGradians object that represents the same angle as the current AngleGradians structure; otherwise, false.</returns>
        public override bool Equals(object obj) =>
            obj is AngleGradians angle && Equals(angle);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() =>
            Gradians.GetHashCode();

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() =>
            Gradians.ToString();

        #endregion

        internal const double RightAngle = 100.0;
        internal const double StraightAngle = 200.0;
        internal const double FullAngle = 400.0;

        internal static double Reduce(double degrees) =>
            Utils.Reduce(degrees, FullAngle);

        internal static Quadrant GetQuadrant(double degrees) =>
            Utils.GetQuadrant(degrees, RightAngle, StraightAngle, FullAngle);

        internal static double GetReference(double degrees) =>
            Utils.GetReference(degrees, RightAngle, StraightAngle, FullAngle);

    }
}
