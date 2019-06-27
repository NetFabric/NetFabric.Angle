using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    [Serializable]
    public readonly struct AngleDegreesMinutesSeconds
        : IEquatable<AngleDegreesMinutesSeconds>
        , IComparable
        , IComparable<AngleDegreesMinutesSeconds>
        , IFormattable
    {
        /// <summary>
        /// Represents a AngleDegreesMinutesSeconds value that is not a number (NaN). This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutesSeconds NaN = new AngleDegreesMinutesSeconds(0, 0, double.NaN);

        /// <summary>
        /// Represents the zero AngleDegreesMinutesSeconds value. This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutesSeconds Zero = new AngleDegreesMinutesSeconds(0, 0, 0.0);

        /// <summary>
        /// Represents the golden AngleDegreesMinutesSeconds value (~137.508 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutesSeconds Golden = Angle.InDegreesMinutesSeconds(AngleRadians.Golden);

        /// <summary>
        /// Represents the smallest possible value of a AngleDegreesMinutesSeconds. This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutesSeconds MinValue = new AngleDegreesMinutesSeconds(int.MinValue, 59, 60.0 - double.Epsilon);

        /// <summary>
        /// Represents the largest possible value of a AngleDegreesMinutesSeconds. This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutesSeconds MaxValue = new AngleDegreesMinutesSeconds(int.MaxValue, 59, 60.0 - double.Epsilon);

        /// <summary>
        /// Represents the right AngleDegreesMinutesSeconds value (90 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutesSeconds Right = new AngleDegreesMinutesSeconds(RightAngle, 0, 0.0);

        /// <summary>
        /// Represents the straight AngleDegreesMinutesSeconds value (180 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutesSeconds Straight = new AngleDegreesMinutesSeconds(StraightAngle, 0, 0.0);

        /// <summary>
        /// Represents the full AngleDegreesMinutesSeconds value (360 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutesSeconds Full = new AngleDegreesMinutesSeconds(FullAngle, 0, 0.0);

        /// <summary>
        /// Gets the degrees component of the amplitude of the angle. This field is read-only.
        /// </summary>
        public readonly int Degrees;

        /// <summary>
        /// Gets the minutes component of the amplitude of the angle. This field is read-only.
        /// </summary>
        public readonly int Minutes;

        /// <summary>
        /// Gets the seconds component of the amplitude of the angle. This field is read-only.
        /// </summary>
        public readonly double Seconds;

        internal AngleDegreesMinutesSeconds(double degrees)
        {
            Degrees = (int)degrees;
            var decimalMinutes = (degrees - Degrees) * 60.0;
            Minutes = (int)decimalMinutes;
            Seconds = (decimalMinutes - Minutes) * 60.0;
        }

        internal AngleDegreesMinutesSeconds(int degrees, int minutes, double seconds)
        {
            Degrees = degrees;
            Minutes = minutes;
            Seconds = seconds;
        }

        public void Deconstruct(out int degrees, out int minutes, out double seconds)
        {
            degrees = Degrees;
            minutes = Minutes;
            seconds = Seconds;
        }

        #region equality implementation

        /// <summary>
        /// Indicates whether two AngleDegreesMinutesSeconds instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator ==(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2) =>
            a1.Degrees == a2.Degrees && a1.Minutes == a2.Minutes && a1.Seconds == a2.Seconds;

        /// <summary>
        /// Indicates whether two AngleDegreesMinutesSeconds instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator !=(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2) =>
            a1.Degrees != a2.Degrees || a1.Minutes != a2.Minutes || a1.Seconds != a2.Seconds;

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified AngleDegreesMinutesSeconds object.
        /// </summary>
        /// <param name="other">An AngleDegreesMinutesSeconds to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="AngleDegreesMinutesSeconds.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public bool Equals(in AngleDegreesMinutesSeconds other) =>
            Degrees == other.Degrees && Minutes == other.Minutes && Seconds == other.Seconds;

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified AngleDegreesMinutesSeconds object.
        /// </summary>
        /// <param name="other">An AngleDegreesMinutesSeconds to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="AngleDegreesMinutesSeconds.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        bool IEquatable<AngleDegreesMinutesSeconds>.Equals(AngleDegreesMinutesSeconds other) =>
            Degrees == other.Degrees && Minutes == other.Minutes && Seconds == other.Seconds;

        #endregion

        #region comparison implementation

        /// <summary>
        /// Indicates whether a specified AngleDegreesMinutesSeconds is less than another specified AngleDegreesMinutesSeconds.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than the value of a2; otherwise, false.</returns>
        public static bool operator <(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2) =>
            AngleDegreesMinutesSeconds.Compare(a1, a2) < 0;

        /// <summary>
        /// Indicates whether a specified AngleDegreesMinutesSeconds is less than or equal to another specified AngleDegreesMinutesSeconds.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator <=(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2) =>
            AngleDegreesMinutesSeconds.Compare(a1, a2) <= 0;

        /// <summary>
        /// Indicates whether a specified AngleDegreesMinutesSeconds is greater than another specified AngleDegreesMinutesSeconds.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than the value of a2; otherwise, false.</returns>
        public static bool operator >(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2) =>
            AngleDegreesMinutesSeconds.Compare(a1, a2) > 0;

        /// <summary>
        /// Indicates whether a specified AngleDegreesMinutesSeconds is greater than or equal to another specified AngleDegreesMinutesSeconds.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator >=(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2) =>
            AngleDegreesMinutesSeconds.Compare(a1, a2) >= 0;

        int IComparable<AngleDegreesMinutesSeconds>.CompareTo(AngleDegreesMinutesSeconds other) =>
            Compare(this, other);

        int IComparable.CompareTo(object obj)
        {
            switch(obj)
            {
                case AngleDegreesMinutesSeconds angle:
                    return AngleDegreesMinutesSeconds.Compare(this, angle);
                default:
                    return ThrowHelper.ThrowArgumentException<int>(nameof(obj), $"Argument has to be an {nameof(AngleDegreesMinutesSeconds)}.");
            }
        }

        #endregion

        #region math operators

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleDegreesMinutesSeconds operator -(in AngleDegreesMinutesSeconds angle) =>
            new AngleDegreesMinutesSeconds(-angle.Degrees, -angle.Minutes, -angle.Seconds);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleDegreesMinutesSeconds operator +(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right)
        {
            var seconds = Utils.ToBase60(left.Seconds + right.Seconds, out var secondsCarry);
            var minutes = Utils.ToBase60(left.Minutes + right.Minutes + (int)secondsCarry, out var minutesCarry);
            var degrees = left.Degrees + right.Degrees + minutesCarry;
            return new AngleDegreesMinutesSeconds(degrees, minutes, seconds);
        }

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleDegreesMinutesSeconds operator -(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right)
        {
            double seconds, secondsCarry;
            if (left.Seconds >= right.Seconds)
            {
                seconds = Utils.ToBase60(left.Seconds - right.Seconds, out secondsCarry);
            }
            else
            {
                seconds = Utils.ToBase60(60.0 + left.Seconds - right.Seconds, out secondsCarry);
                secondsCarry -= 1.0;
            }

            int minutes, minutesCarry;
            if (left.Minutes >= right.Minutes)
            {
                minutes = Utils.ToBase60((int)secondsCarry + left.Minutes - right.Minutes, out minutesCarry);
            }
            else
            {
                minutes = Utils.ToBase60(60 + (int)secondsCarry + left.Minutes - right.Minutes, out minutesCarry);
                minutesCarry -= 1;
            }

            var degrees = minutesCarry + left.Degrees - right.Degrees;
            return new AngleDegreesMinutesSeconds(degrees, minutes, seconds);
        }

        /// <summary>
        /// Multiplies a scalar by an angle value. 
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleDegreesMinutesSeconds operator *(double left, in AngleDegreesMinutesSeconds right)
        {
            var seconds = Utils.ToBase60(left * right.Seconds, out var secondsCarry);
            var minutes = (int)Utils.ToBase60(left * right.Minutes + (int)secondsCarry, out var minutesCarry);
            var degrees = (int)(left * right.Degrees + minutesCarry);
            return new AngleDegreesMinutesSeconds(degrees, minutes, seconds);
        }

        /// <summary>
        /// Divides a angle by a scalar value. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleDegreesMinutesSeconds operator /(in AngleDegreesMinutesSeconds left, double right)
        {
            if (right == 0)
                return new AngleDegreesMinutesSeconds(0, 0, Double.NaN);

            var seconds = Utils.ToBase60(left.Seconds / right, out var secondsCarry);
            var minutes = (int)Utils.ToBase60(left.Minutes / right + (int)secondsCarry, out var minutesCarry);
            var degrees = (int)(left.Degrees / right + minutesCarry);
            return new AngleDegreesMinutesSeconds(degrees, minutes, seconds);
        }

        #endregion

        #region string format

        /// <summary>
        /// Converts the value of the current AngleDegreesMinutesSeconds object to its equivalent string representation, using a specified format.
        /// </summary>
        /// <param name="format">A string that specifies the format to be used for the returned string.</param>
        /// <returns>A string representation of the value of the current AngleDegreesMinutesSeconds object, in the specified format.</returns>
        public string ToString(string format) =>
            $"{Degrees}° {Minutes}' {Seconds.ToString(format)}\"";

        /// <summary>
        /// Converts the value of the current AngleDegreesMinutesSeconds object to its equivalent string representation using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current AngleDegreesMinutesSeconds object as specified by format and provider.</returns>
        public string ToString(string format, IFormatProvider formatProvider) =>
            $"{Degrees}° {Minutes}' {Seconds.ToString(format, formatProvider)}\"";

        #endregion

        #region object overrides

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>true if value is a AngleDegreesMinutesSeconds object that represents the same angle as the current AngleDegreesMinutesSeconds structure; otherwise, false.</returns>
        public override bool Equals(object obj) =>
            obj is AngleDegreesMinutesSeconds angle && Equals(angle);

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
                hash = (hash * HashingMultiplier) + Minutes;
                hash = (hash * HashingMultiplier) + Seconds.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() =>
            $"{Degrees}° {Minutes}' {Seconds}\"";

        #endregion

        internal const int RightAngle = 90;
        internal const int StraightAngle = 180;
        internal const int FullAngle = 360;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static AngleDegreesMinutesSeconds Reduce(in AngleDegreesMinutesSeconds angle)
        {
            var degrees = Utils.Reduce(angle.Degrees, FullAngle);
            if (angle.Minutes == 0 && angle.Seconds == 0)
                return new AngleDegreesMinutesSeconds(degrees, 0, 0.0);

            if (degrees < 0)
                return new AngleDegreesMinutesSeconds(FullAngle + degrees, angle.Minutes, angle.Seconds);

            return new AngleDegreesMinutesSeconds(degrees, angle.Minutes, angle.Seconds);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Quadrant GetQuadrant(int degrees) =>
            Utils.GetQuadrant(degrees, RightAngle, StraightAngle, FullAngle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static AngleDegreesMinutesSeconds GetReference(in AngleDegreesMinutesSeconds angle)
        {
            var degrees = Utils.GetReference(angle.Degrees, RightAngle, StraightAngle, FullAngle);
            if (angle.Minutes == 0 && angle.Seconds == 0)
                return new AngleDegreesMinutesSeconds(degrees, 0, 0.0);

            if (angle.Degrees < 0)
                return new AngleDegreesMinutesSeconds(degrees - 1, angle.Minutes + 60, angle.Seconds + 60.0);

            return new AngleDegreesMinutesSeconds(degrees, angle.Minutes, angle.Seconds);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double GetDegreesAngle(in AngleDegreesMinutesSeconds angle) =>
            angle.Degrees + angle.Minutes / 60.0 + angle.Seconds / 3_600.0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool EqualsReduced(in AngleDegreesMinutesSeconds angle1, in AngleDegreesMinutesSeconds angle2) =>
            AngleDegreesMinutesSeconds.Equals(Reduce(angle1), angle2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool GreaterThanReduced(in AngleDegreesMinutesSeconds angle1, in AngleDegreesMinutesSeconds angle2)
        {
            var reduced = Reduce(angle1);
            return reduced > angle2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool InRangeReduced(in AngleDegreesMinutesSeconds angle, in AngleDegreesMinutesSeconds minAngle, in AngleDegreesMinutesSeconds maxAngle)
        {
            var reduced = Reduce(angle);
            return (reduced > minAngle && reduced < maxAngle); 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int Compare(in AngleDegreesMinutesSeconds angle1, in AngleDegreesMinutesSeconds angle2)
        {
            if (angle1.Degrees > angle2.Degrees)
                return 1;
            if (angle1.Degrees < angle2.Degrees)
                return -1;
            if (angle1.Minutes > angle2.Minutes)
                return 1;
            if (angle1.Minutes < angle2.Minutes)
                return -1;
            if (angle1.Seconds > angle2.Seconds)
                return 1;
            if (angle1.Seconds < angle2.Seconds)
                return -1;
            return 0;
        }
    }
}
