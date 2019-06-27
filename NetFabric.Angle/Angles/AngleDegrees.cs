using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace NetFabric
{
    [Serializable]
    public readonly partial struct AngleDegrees
        : IEquatable<AngleDegrees>
        , IComparable
        , IComparable<AngleDegrees>
        , IFormattable
        , ISerializable
    {
        /// <summary>
        /// Represents a AngleDegrees value that is not a number (NaN). This field is read-only.
        /// </summary>
        public static readonly AngleDegrees NaN = new AngleDegrees(double.NaN);

        /// <summary>
        /// Represents the zero AngleDegrees value (0 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegrees Zero = new AngleDegrees(0.0);

        /// <summary>
        /// Represents the golden AngleDegrees value (~137.508 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegrees Golden = Angle.InDegrees(AngleRadians.Golden);

        /// <summary>
        /// Represents the smallest possible value of a AngleDegrees. This field is read-only.
        /// </summary>
        public static readonly AngleDegrees MinValue = new AngleDegrees(double.MinValue);

        /// <summary>
        /// Represents the largest possible value of a AngleDegrees. This field is read-only.
        /// </summary>
        public static readonly AngleDegrees MaxValue = new AngleDegrees(double.MaxValue);

        /// <summary>
        /// Represents the right AngleDegrees value (90 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegrees Right = new AngleDegrees(RightAngle);

        /// <summary>
        /// Represents the straight AngleDegrees value (180 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegrees Straight = new AngleDegrees(StraightAngle);

        /// <summary>
        /// Represents the full AngleDegrees value (360 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegrees Full = new AngleDegrees(FullAngle);

        /// <summary>
        /// Gets the amplitude of the angle in degrees. This field is read-only.
        /// </summary>
        public readonly double Degrees;

        internal AngleDegrees(double degrees)
        {
            Degrees = degrees;
        }

        AngleDegrees(SerializationInfo info, StreamingContext context)
        {
            if (info is null)
                ThrowHelper.ThrowArgumentNullException(nameof(info));

            Degrees = info.GetDouble("degrees");
        }

        #region equality implementation

        /// <summary>
        /// Indicates whether two AngleDegrees instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator ==(AngleDegrees a1, AngleDegrees a2) =>
            a1.Degrees == a2.Degrees;

        /// <summary>
        /// Indicates whether two AngleDegrees instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator !=(AngleDegrees a1, AngleDegrees a2) =>
            a1.Degrees != a2.Degrees;

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified AngleDegrees object.
        /// </summary>
        /// <param name="other">An AngleDegrees to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="AngleDegrees.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public bool Equals(AngleDegrees other) =>
            Degrees == other.Degrees;

        #endregion

        #region comparison implementation

        /// <summary>
        /// Indicates whether a specified AngleDegrees is less than another specified AngleDegrees.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than the value of a2; otherwise, false.</returns>
        public static bool operator <(AngleDegrees a1, AngleDegrees a2) =>
            a1.Degrees < a2.Degrees;

        /// <summary>
        /// Indicates whether a specified AngleDegrees is less than or equal to another specified AngleDegrees.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator <=(AngleDegrees a1, AngleDegrees a2) =>
            a1.Degrees <= a2.Degrees;

        /// <summary>
        /// Indicates whether a specified AngleDegrees is greater than another specified AngleDegrees.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than the value of a2; otherwise, false.</returns>
        public static bool operator >(AngleDegrees a1, AngleDegrees a2) =>
            a1.Degrees > a2.Degrees;

        /// <summary>
        /// Indicates whether a specified AngleDegrees is greater than or equal to another specified AngleDegrees.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator >=(AngleDegrees a1, AngleDegrees a2) =>
            a1.Degrees >= a2.Degrees;

        int IComparable<AngleDegrees>.CompareTo(AngleDegrees other) =>
            Degrees.CompareTo(other.Degrees);

        int IComparable.CompareTo(object obj)
        {
            switch (obj)
            {
                case AngleDegrees angle:
                    return Degrees.CompareTo(angle.Degrees);
                default:
                    return ThrowHelper.ThrowArgumentException<int>(nameof(obj), $"Argument has to be an {nameof(AngleDegrees)}.");
            }
        }

        #endregion

        #region math operators

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleDegrees operator -(AngleDegrees angle) =>
            new AngleDegrees(-angle.Degrees);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleDegrees operator +(AngleDegrees left, AngleDegrees right) =>
            new AngleDegrees(left.Degrees + right.Degrees);

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleDegrees operator -(AngleDegrees left, AngleDegrees right) =>
            new AngleDegrees(left.Degrees - right.Degrees);

        /// <summary>
        /// Multiplies a scalar by an angle value. 
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleDegrees operator *(double left, AngleDegrees right) =>
            new AngleDegrees(left * right.Degrees);

        /// <summary>
        /// Divides a angle by a scalar value. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleDegrees operator /(AngleDegrees left, double right) =>
            new AngleDegrees(left.Degrees / right);

        #endregion

        #region string format

        /// <summary>
        /// Converts the value of the current AngleDegrees object to its equivalent string representation, using a specified format.
        /// </summary>
        /// <param name="format">A string that specifies the format to be used for the returned string.</param>
        /// <returns>A string representation of the value of the current AngleDegrees object, in the specified format.</returns>
        public string ToString(string format) =>
            Degrees.ToString(format);

        /// <summary>
        /// Converts the value of the current AngleDegrees object to its equivalent string representation using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current AngleDegrees object as specified by format and provider.</returns>
        public string ToString(string format, IFormatProvider formatProvider) =>
            Degrees.ToString(format, formatProvider);

        #endregion

        #region object overrides

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>true if value is a AngleDegrees object that represents the same angle as the current AngleDegrees structure; otherwise, false.</returns>
        public override bool Equals(object obj) =>
            obj is AngleDegrees angle && Equals(angle);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() =>
            Degrees.GetHashCode();

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() =>
            Degrees.ToString();

        #endregion

        internal const double RightAngle = 90.0;
        internal const double StraightAngle = 180.0;
        internal const double FullAngle = 360.0;

        internal static double Reduce(double degrees) =>
            Utils.Reduce(degrees, FullAngle);

        internal static Quadrant GetQuadrant(double degrees) =>
            Utils.GetQuadrant(degrees, RightAngle, StraightAngle, FullAngle);

        internal static double GetReference(double degrees) =>
            Utils.GetReference(degrees, RightAngle, StraightAngle, FullAngle);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("degrees", Degrees);
        }
    }
}
