using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    /// <summary>
    /// Represents an angle measured in degrees and minutes. 
    /// </summary>    
    [Serializable]
    public readonly struct AngleDegreesMinutes
        : IEquatable<AngleDegreesMinutes>
        , IComparable
        , IComparable<AngleDegreesMinutes>
        , IFormattable
    {
        /// <summary>
        /// Represents a AngleDegreesMinutes value that is not a number (NaN). This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutes NaN = new AngleDegreesMinutes(0, double.NaN);

        /// <summary>
        /// Represents the zero AngleDegreesMinutes value (0 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutes Zero = new AngleDegreesMinutes(0, 0.0);

        /// <summary>
        /// Represents the golden AngleDegreesMinutes value (~137.508 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutes Golden = Angle.InDegreesMinutes(AngleRadians.Golden);

        /// <summary>
        /// Represents the smallest possible value of a AngleDegreesMinutes. This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutes MinValue = new AngleDegreesMinutes(int.MinValue, 60.0 - double.Epsilon);

        /// <summary>
        /// Represents the largest possible value of a AngleDegreesMinutes. This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutes MaxValue = new AngleDegreesMinutes(int.MaxValue, 60.0 - double.Epsilon);

        /// <summary>
        /// Represents the right AngleDegreesMinutes value (90 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutes Right = new AngleDegreesMinutes(RightAngle, 0.0);

        /// <summary>
        /// Represents the straight AngleDegreesMinutes value (180 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutes Straight = new AngleDegreesMinutes(StraightAngle, 0.0);

        /// <summary>
        /// Represents the full AngleDegreesMinutes value (360 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutes Full = new AngleDegreesMinutes(FullAngle, 0.0);

        /// <summary>
        /// Gets the degrees component of the amplitude of the angle. This field is read-only.
        /// </summary>
        public readonly int Degrees;

        /// <summary>
        /// Gets the minutes component of the amplitude of the angle. This field is read-only.
        /// </summary>
        public readonly double Minutes;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal AngleDegreesMinutes(double degrees)
        {
            Degrees = (int)Math.Floor(degrees);
            Minutes = Math.Abs(degrees - Degrees) * 60.0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal AngleDegreesMinutes(int degrees, double minutes)
        {
            Degrees = degrees;
            Minutes = minutes;
        }

        public void Deconstruct(out int degrees, out double minutes)
        {
            degrees = Degrees;
            minutes = Minutes;
        }

        #region equality implementation

        /// <summary>
        /// Indicates whether two AngleDegreesMinutes instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(in AngleDegreesMinutes a1, in AngleDegreesMinutes a2) =>
            a1.Degrees == a2.Degrees && a1.Minutes == a2.Minutes;

        /// <summary>
        /// Indicates whether two AngleDegreesMinutes instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(in AngleDegreesMinutes a1, in AngleDegreesMinutes a2) =>
            a1.Degrees != a2.Degrees || a1.Minutes != a2.Minutes;

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified AngleDegreesMinutes object.
        /// </summary>
        /// <param name="other">An AngleDegreesMinutes to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="AngleDegreesMinutes.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public bool Equals(in AngleDegreesMinutes other) =>
            Degrees == other.Degrees && Minutes == other.Minutes;

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified AngleDegreesMinutes object.
        /// </summary>
        /// <param name="other">An AngleDegreesMinutes to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="AngleDegreesMinutes.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        bool IEquatable<AngleDegreesMinutes>.Equals(AngleDegreesMinutes other) =>
            Degrees == other.Degrees && Minutes == other.Minutes;

        #endregion

        #region comparison implementation

        /// <summary>
        /// Indicates whether a specified AngleDegreesMinutes is less than another specified AngleDegreesMinutes.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than the value of a2; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(in AngleDegreesMinutes a1, in AngleDegreesMinutes a2) =>
            GetDegreesAngle(a1) < GetDegreesAngle(a2);

        /// <summary>
        /// Indicates whether a specified AngleDegreesMinutes is less than or equal to another specified AngleDegreesMinutes.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than or equal to the value of a2; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(in AngleDegreesMinutes a1, in AngleDegreesMinutes a2) =>
            GetDegreesAngle(a1) <= GetDegreesAngle(a2);

        /// <summary>
        /// Indicates whether a specified AngleDegreesMinutes is greater than another specified AngleDegreesMinutes.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than the value of a2; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(in AngleDegreesMinutes a1, in AngleDegreesMinutes a2) =>
            GetDegreesAngle(a1) > GetDegreesAngle(a2);

        /// <summary>
        /// Indicates whether a specified AngleDegreesMinutes is greater than or equal to another specified AngleDegreesMinutes.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than or equal to the value of a2; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(in AngleDegreesMinutes a1, in AngleDegreesMinutes a2) =>
            GetDegreesAngle(a1) >= GetDegreesAngle(a2);

        int IComparable<AngleDegreesMinutes>.CompareTo(AngleDegreesMinutes other) =>
            Angle.Compare(this, other);

        int IComparable.CompareTo(object obj)
        {
            switch (obj)
            {
                case AngleDegreesMinutes angle:
                    return Angle.Compare(this, angle);
                default:
                    return ThrowHelper.ThrowArgumentException<int>(nameof(obj), $"Argument has to be an {nameof(AngleDegreesMinutes)}.");
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
        public static AngleDegreesMinutes operator -(in AngleDegreesMinutes angle) =>
            new AngleDegreesMinutes(-angle.Degrees, angle.Minutes);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleDegreesMinutes operator +(in AngleDegreesMinutes left, in AngleDegreesMinutes right)
        {
            var totalMinutes = left.Minutes + right.Minutes;
            var totalDegrees = left.Degrees + right.Degrees + (int)Math.Floor(totalMinutes / 60.0);
            return new AngleDegreesMinutes(totalDegrees, totalMinutes % 60.0);
        }

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleDegreesMinutes operator -(in AngleDegreesMinutes left, in AngleDegreesMinutes right)
        {
            var totalMinutes = left.Minutes - right.Minutes;
            var totalDegrees = left.Degrees - right.Degrees + (int)Math.Floor(totalMinutes / 60.0);
            return new AngleDegreesMinutes(totalDegrees, totalMinutes % 60.0);
        }

        /// <summary>
        /// Multiplies a scalar by an angle value. 
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleDegreesMinutes operator *(double left, in AngleDegreesMinutes right)
        {
            var totalMinutes = left * right.Minutes;
            var totalDegrees = (int)Math.Floor(left * right.Degrees + totalMinutes / 60.0);
            return new AngleDegreesMinutes(totalDegrees, totalMinutes % 60.0);
        }

        /// <summary>
        /// Divides a angle by a scalar value. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleDegreesMinutes operator /(in AngleDegreesMinutes left, double right)
        {
            var totalMinutes = left.Minutes / right;
            var totalDegrees = (int)Math.Floor(left.Degrees / right + totalMinutes / 60.0);
            return new AngleDegreesMinutes(totalDegrees, totalMinutes % 60.0);
        }

        #endregion

        #region string format

        /// <summary>
        /// Converts the value of the current AngleDegreesMinutes object to its equivalent string representation, using a specified format.
        /// </summary>
        /// <param name="format">A string that specifies the format to be used for the returned string.</param>
        /// <returns>A string representation of the value of the current AngleDegreesMinutes object, in the specified format.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format) =>
            $"{Degrees}° {Minutes.ToString(format)}'";

        /// <summary>
        /// Converts the value of the current AngleDegreesMinutes object to its equivalent string representation using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current AngleDegreesMinutes object as specified by format and provider.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider) =>
            $"{Degrees}° {Minutes.ToString(format, formatProvider)}'";

        #endregion

        #region object overrides

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>true if value is a AngleDegreesMinutes object that represents the same angle as the current AngleDegreesMinutes structure; otherwise, false.</returns>
        public override bool Equals(object obj) =>
            obj is AngleDegreesMinutes angle && Equals(angle);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                var hash = HashingBase;
                hash = (hash * HashingMultiplier) + Degrees;
                hash = (hash * HashingMultiplier) + Minutes.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() =>
            $"{Degrees}° {Minutes}'";

        #endregion

        internal const int RightAngle = 90;
        internal const int StraightAngle = 180;
        internal const int FullAngle = 360;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int Reduce(int degrees) =>
            Utils.Reduce(degrees, FullAngle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Quadrant GetQuadrant(int degrees) =>
            Utils.GetQuadrant(degrees, RightAngle, FullAngle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double GetReference(in AngleDegreesMinutes angle) =>
            Utils.GetReference(GetDegreesAngle(angle), RightAngle, StraightAngle, FullAngle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double GetDegreesAngle(in AngleDegreesMinutes angle)
        {
            var dec = angle.Minutes / 60.0;
            return Math.Sign(angle.Degrees) < 0 ? angle.Degrees - dec : angle.Degrees + dec;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool EqualsReduced(in AngleDegreesMinutes angle, int degrees)
        {
            var reduced = Reduce(Math.Abs(angle.Degrees));
            return reduced == degrees && angle.Minutes == 0.0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool GreaterThanReduced(in AngleDegreesMinutes angle, int minDegrees)
        {
            var reduced = Reduce(Math.Abs(angle.Degrees));
            return reduced > minDegrees || 
                reduced == minDegrees && angle.Minutes > 0.0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool InRangeReduced(in AngleDegreesMinutes angle, int minDegrees, int maxDegrees)
        {
            var reduced = Reduce(Math.Abs(angle.Degrees));
            return (reduced > minDegrees || 
                reduced == minDegrees && angle.Minutes > 0.0) && 
                reduced < maxDegrees;
        }
    }
}
