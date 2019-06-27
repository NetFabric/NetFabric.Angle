using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace NetFabric
{
    [Serializable]
    public readonly partial struct AngleRevolutions
        : IEquatable<AngleRevolutions>
        , IComparable
        , IComparable<AngleRevolutions>
        , IFormattable
        , ISerializable
    {
        /// <summary>
        /// Represents a AngleRevolutions value that is not a number (NaN). This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions NaN = new AngleRevolutions(double.NaN);

        /// <summary>
        /// Represents the zero AngleRevolutions value (zero revolutions). This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions Zero = new AngleRevolutions(0.0);

        /// <summary>
        /// Represents the golden AngleRevolutions value (~137.508 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions Golden = Angle.InRevolutions(AngleRadians.Golden);

        /// <summary>
        /// Represents the smallest possible value of a AngleRevolutions. This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions MinValue = new AngleRevolutions(double.MinValue);

        /// <summary>
        /// Represents the largest possible value of a AngleRevolutions. This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions MaxValue = new AngleRevolutions(double.MaxValue);

        /// <summary>
        /// Represents the right AngleRevolutions value (1/4 revolution). This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions Right = new AngleRevolutions(RightAngle);

        /// <summary>
        /// Represents the straight AngleRevolutions value (1/2 revolution). This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions Straight = new AngleRevolutions(StraightAngle);

        /// <summary>
        /// Represents the full AngleRevolutions value (1 revolution). This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions Full = new AngleRevolutions(FullAngle);

        /// <summary>
        /// Gets the amplitude of the angle in revolutions. This field is read-only.
        /// </summary>
        public readonly double Revolutions;

        internal AngleRevolutions(double revolutions)
        {
            Revolutions = revolutions;
        }

        AngleRevolutions(SerializationInfo info, StreamingContext context)
        {
            if (info is null)
                ThrowHelper.ThrowArgumentNullException(nameof(info));

            Revolutions = info.GetDouble("revolutions");
        }

        #region equality implementation

        /// <summary>
        /// Indicates whether two AngleRevolutions instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator ==(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions == a2.Revolutions;

        /// <summary>
        /// Indicates whether two AngleRevolutions instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator !=(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions != a2.Revolutions;

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified AngleRevolutions object.
        /// </summary>
        /// <param name="other">An AngleRevolutions to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="AngleRevolutions.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public bool Equals(AngleRevolutions other) =>
            Revolutions == other.Revolutions;

        #endregion

        #region comparison implementation

        /// <summary>
        /// Indicates whether a specified AngleRevolutions is less than another specified AngleRevolutions.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than the value of a2; otherwise, false.</returns>
        public static bool operator <(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions < a2.Revolutions;

        /// <summary>
        /// Indicates whether a specified AngleRevolutions is less than or equal to another specified AngleRevolutions.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator <=(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions <= a2.Revolutions;

        /// <summary>
        /// Indicates whether a specified AngleRevolutions is greater than another specified AngleRevolutions.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than the value of a2; otherwise, false.</returns>
        public static bool operator >(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions > a2.Revolutions;

        /// <summary>
        /// Indicates whether a specified AngleRevolutions is greater than or equal to another specified AngleRevolutions.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator >=(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions >= a2.Revolutions;

        int IComparable<AngleRevolutions>.CompareTo(AngleRevolutions other) =>
            Revolutions.CompareTo(other.Revolutions);

        int IComparable.CompareTo(object obj)
        {
            switch (obj)
            {
                case AngleRevolutions angle:
                    return Revolutions.CompareTo(angle.Revolutions);
                default:
                    return ThrowHelper.ThrowArgumentException<int>(nameof(obj), $"Argument has to be an {nameof(AngleRevolutions)}.");
            }
        }

        #endregion

        #region math operators

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleRevolutions operator -(AngleRevolutions angle) =>
            new AngleRevolutions(-angle.Revolutions);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleRevolutions operator +(AngleRevolutions left, AngleRevolutions right) =>
            new AngleRevolutions(left.Revolutions + right.Revolutions);

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleRevolutions operator -(AngleRevolutions left, AngleRevolutions right) =>
            new AngleRevolutions(left.Revolutions - right.Revolutions);

        /// <summary>
        /// Multiplies a scalar by an angle value. 
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleRevolutions operator *(double left, AngleRevolutions right) =>
            new AngleRevolutions(left * right.Revolutions);

        /// <summary>
        /// Divides a angle by a scalar value. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleRevolutions operator /(AngleRevolutions left, double right) =>
            new AngleRevolutions(left.Revolutions / right);

        #endregion

        #region string format

        /// <summary>
        /// Converts the value of the current AngleRevolutions object to its equivalent string representation, using a specified format.
        /// </summary>
        /// <param name="format">A string that specifies the format to be used for the returned string.</param>
        /// <returns>A string representation of the value of the current AngleRevolutions object, in the specified format.</returns>
        public string ToString(string format) =>
            Revolutions.ToString(format);

        /// <summary>
        /// Converts the value of the current AngleRevolutions object to its equivalent string representation using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current AngleRevolutions object as specified by format and provider.</returns>
        public string ToString(string format, IFormatProvider formatProvider) =>
            Revolutions.ToString(format, formatProvider);

        #endregion

        #region object overrides

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>true if value is a AngleRevolutions object that represents the same angle as the current AngleRevolutions structure; otherwise, false.</returns>
        public override bool Equals(object obj) =>
            obj is AngleRevolutions angle && Equals(angle);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() =>
            Revolutions.GetHashCode();

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() =>
            Revolutions.ToString();

        #endregion

        internal const double RightAngle = 0.25;
        internal const double StraightAngle = 0.5;
        internal const double FullAngle = 1.0;

        internal static double Reduce(double revolutions)
        {
            var trunc = Math.Truncate(revolutions);
            if (trunc == revolutions)
                return 0.0;

            if (revolutions < 0)
                return FullAngle + revolutions - trunc;

            return revolutions - trunc;
        }

        internal static Quadrant GetQuadrant(double revolutions) =>
            Utils.GetQuadrant(revolutions, RightAngle, StraightAngle, FullAngle);

        internal static double GetReference(double revolutions) =>
            Utils.GetReference(revolutions, RightAngle, StraightAngle, FullAngle);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("revolutions", Revolutions);
        }
    }
}
