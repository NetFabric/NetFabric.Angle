using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    /// <summary>
    /// Represents an angle measured in radians. 
    /// </summary>
    [Serializable]
    public readonly partial struct AngleRadians
        : IEquatable<AngleRadians>
        , IComparable
        , IComparable<AngleRadians>
        , IFormattable
    {
        /// <summary>
        /// Represents a AngleRadians value that is not a number (NaN). This field is read-only.
        /// </summary>
        public static readonly AngleRadians NaN = new AngleRadians(double.NaN);

        /// <summary>
        /// Represents the zero AngleRadians value (0 radians). This field is read-only.
        /// </summary>
        public static readonly AngleRadians Zero = new AngleRadians(0.0);

        /// <summary>
        /// Represents the golden AngleRadians value (~137.508 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleRadians Golden = new AngleRadians(Math.PI * (3.0 - Math.Sqrt(5.0)));

        /// <summary>
        /// Represents the smallest possible value of a AngleRadians. This field is read-only.
        /// </summary>
        public static readonly AngleRadians MinValue = new AngleRadians(double.MinValue);

        /// <summary>
        /// Represents the largest possible value of a AngleRadians. This field is read-only.
        /// </summary>
        public static readonly AngleRadians MaxValue = new AngleRadians(double.MaxValue);

        /// <summary>
        /// Represents the right AngleRadians value (π/2 radians). This field is read-only.
        /// </summary>
        public static readonly AngleRadians Right = new AngleRadians(RightAngle);

        /// <summary>
        /// Represents the straight AngleRadians value (π radians). This field is read-only.
        /// </summary>
        public static readonly AngleRadians Straight = new AngleRadians(StraightAngle);

        /// <summary>
        /// Represents the full AngleRadians value (2*π radians). This field is read-only.
        /// </summary>
        public static readonly AngleRadians Full = new AngleRadians(FullAngle);

        /// <summary>
        /// Gets the amplitude of the angle in radians. This field is read-only.
        /// </summary>
        public readonly double Radians;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal AngleRadians(double radians)
        {
            Radians = radians;
        }

        #region equality implementation

        /// <summary>
        /// Indicates whether two AngleRadians instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(AngleRadians a1, AngleRadians a2) =>
            a1.Radians == a2.Radians;

        /// <summary>
        /// Indicates whether two AngleRadians instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(AngleRadians a1, AngleRadians a2) =>
            a1.Radians != a2.Radians;

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified AngleRadians object.
        /// </summary>
        /// <param name="other">An AngleRadians to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="AngleRadians.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public bool Equals(AngleRadians other) =>
            Radians == other.Radians;

        #endregion

        #region comparison implementation

        /// <summary>
        /// Indicates whether a specified AngleRadians is less than another specified AngleRadians.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than the value of a2; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(AngleRadians a1, AngleRadians a2) =>
            a1.Radians < a2.Radians;

        /// <summary>
        /// Indicates whether a specified AngleRadians is less than or equal to another specified AngleRadians.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than or equal to the value of a2; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(AngleRadians a1, AngleRadians a2) =>
            a1.Radians <= a2.Radians;

        /// <summary>
        /// Indicates whether a specified AngleRadians is greater than another specified AngleRadians.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than the value of a2; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(AngleRadians a1, AngleRadians a2) =>
            a1.Radians > a2.Radians;

        /// <summary>
        /// Indicates whether a specified AngleRadians is greater than or equal to another specified AngleRadians.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than or equal to the value of a2; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(AngleRadians a1, AngleRadians a2) =>
            a1.Radians >= a2.Radians;

        int IComparable<AngleRadians>.CompareTo(AngleRadians other) =>
            Radians.CompareTo(other.Radians);

        int IComparable.CompareTo(object obj)
        {
            switch (obj)
            {
                case AngleRadians angle:
                    return Radians.CompareTo(angle.Radians);
                default:
                    return ThrowHelper.ThrowArgumentException<int>(nameof(obj), $"Argument has to be an {nameof(AngleRadians)}.");
            }
        }

        #endregion

        #region math operators

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians operator -(AngleRadians angle) =>
            new AngleRadians(-angle.Radians);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians operator +(AngleRadians left, AngleRadians right) =>
            new AngleRadians(left.Radians + right.Radians);

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians operator -(AngleRadians left, AngleRadians right) =>
            new AngleRadians(left.Radians - right.Radians);

        /// <summary>
        /// Multiplies a scalar by an angle value. 
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians operator *(double left, AngleRadians right) =>
            new AngleRadians(left * right.Radians);

        /// <summary>
        /// Divides a angle by a scalar value. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians operator /(AngleRadians left, double right) =>
            new AngleRadians(left.Radians / right);

        #endregion

        #region string format

        /// <summary>
        /// Converts the value of the current AngleRadians object to its equivalent string representation, using a specified format.
        /// </summary>
        /// <param name="format">A string that specifies the format to be used for the returned string.</param>
        /// <returns>A string representation of the value of the current AngleRadians object, in the specified format.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format) =>
            Radians.ToString(format);

        /// <summary>
        /// Converts the value of the current AngleRadians object to its equivalent string representation using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current AngleRadians object as specified by format and provider.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider) =>
            Radians.ToString(format, formatProvider);

        #endregion

        #region object overrides

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>true if value is a AngleRadians object that represents the same angle as the current AngleRadians structure; otherwise, false.</returns>
        public override bool Equals(object obj) =>
            obj is AngleRadians angle && Equals(angle);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() =>
            Radians.GetHashCode();

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() =>
            Radians.ToString();

        #endregion

        internal const double RightAngle = Math.PI * 0.5;
        internal const double StraightAngle = Math.PI;
        internal const double FullAngle = Math.PI * 2.0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double Reduce(double radians) =>
            Utils.Reduce(radians, FullAngle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Quadrant GetQuadrant(double radians) =>
            Utils.GetQuadrant(radians, RightAngle, FullAngle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double GetReference(double radians) =>
            Utils.GetReference(radians, RightAngle, StraightAngle, FullAngle);
    }
}
