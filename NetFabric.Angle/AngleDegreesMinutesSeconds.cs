using System;
#if !NET35
using System.Runtime.CompilerServices;
#endif

namespace NetFabric
{
    public readonly struct AngleDegreesMinutesSeconds
        : IEquatable<AngleDegreesMinutesSeconds>
        , IComparable
        , IComparable<AngleDegreesMinutesSeconds>
        , IFormattable
    {
        /// <summary>
        /// Represents the zero AngleDegreesMinutesSeconds value (0 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutesSeconds Zero = new AngleDegreesMinutesSeconds(0, 0, 0.0);

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
            Degrees = (int)Math.Floor(degrees);
            var decimalMinutes = Math.Abs(degrees - Degrees) * 60.0;
            Minutes = (int)Math.Floor(decimalMinutes);
            Seconds = Math.Abs(degrees - Degrees) * 60.0;
        }

        internal AngleDegreesMinutesSeconds(int degrees, int minutes, double seconds)
        {
            Degrees = degrees;
            Minutes = minutes;
            Seconds = seconds;
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
        /// Indicates whether two AngleDegreesMinutesSeconds instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool Equals(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2) =>
            a1.Degrees == a2.Degrees && a1.Minutes == a2.Minutes && a1.Seconds == a2.Seconds;

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified AngleDegreesMinutesSeconds object.
        /// </summary>
        /// <param name="other">An AngleDegreesMinutesSeconds to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="AngleDegreesMinutesSeconds.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public bool Equals(AngleDegreesMinutesSeconds other) =>
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
            GetDegreesAngle(a1) < GetDegreesAngle(a2);

        /// <summary>
        /// Indicates whether a specified AngleDegreesMinutesSeconds is less than or equal to another specified AngleDegreesMinutesSeconds.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator <=(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2) =>
            GetDegreesAngle(a1) <= GetDegreesAngle(a2);

        /// <summary>
        /// Indicates whether a specified AngleDegreesMinutesSeconds is greater than another specified AngleDegreesMinutesSeconds.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than the value of a2; otherwise, false.</returns>
        public static bool operator >(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2) =>
            GetDegreesAngle(a1) > GetDegreesAngle(a2);

        /// <summary>
        /// Indicates whether a specified AngleDegreesMinutesSeconds is greater than or equal to another specified AngleDegreesMinutesSeconds.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator >=(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2) =>
            GetDegreesAngle(a1) >= GetDegreesAngle(a2);

        int IComparable<AngleDegreesMinutesSeconds>.CompareTo(AngleDegreesMinutesSeconds other) =>
            Angle.Compare(this, other);

        int IComparable.CompareTo(object obj)
        {
            switch (obj)
            {
                case AngleDegreesMinutesSeconds angle:
                    return Angle.Compare(this, angle);
                default:
                    throw new ArgumentException($"Argument has to be an {nameof(AngleDegreesMinutesSeconds)}.", nameof(obj));
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
            new AngleDegreesMinutesSeconds(-angle.Degrees, angle.Minutes, angle.Seconds);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleDegreesMinutesSeconds operator +(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right)
        {
            var totalSeconds = left.Seconds + right.Seconds;
            var totalMinutes = left.Minutes + right.Minutes + (int)Math.Floor(totalSeconds / 60.0);
            var totalDegrees = left.Degrees + right.Degrees + (int)Math.Floor(totalMinutes / 60.0);
            return new AngleDegreesMinutesSeconds(totalDegrees, totalMinutes % 60, totalSeconds % 60);
        }

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleDegreesMinutesSeconds operator -(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right)
        {
            var totalSeconds = left.Seconds - right.Seconds;
            var totalMinutes = left.Minutes - right.Minutes + (int)Math.Floor(totalSeconds / 60.0);
            var totalDegrees = left.Degrees - right.Degrees + (int)Math.Floor(totalMinutes / 60.0);
            return new AngleDegreesMinutesSeconds(totalDegrees, totalMinutes % 60, totalSeconds % 60);
        }

        /// <summary>
        /// Multiplies a scalar by an angle value. 
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleDegreesMinutesSeconds operator *(double left, in AngleDegreesMinutesSeconds right)
        {
            var totalSeconds = left * right.Seconds;
            var totalMinutes = (int)Math.Floor(left * right.Degrees + totalSeconds / 60.0);
            var totalDegrees = (int)Math.Floor(left * right.Degrees + totalMinutes / 60.0);
            return new AngleDegreesMinutesSeconds(totalDegrees, totalMinutes % 60, totalSeconds % 60.0);
        }

        /// <summary>
        /// Divides a angle by a scalar value. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleDegreesMinutesSeconds operator /(in AngleDegreesMinutesSeconds left, double right)
        {
            var totalSeconds = left.Seconds / right;
            var totalMinutes = (int)Math.Floor(left.Degrees / right + totalSeconds / 60.0);
            var totalDegrees = (int)Math.Floor(left.Degrees / right + totalMinutes / 60.0);
            return new AngleDegreesMinutesSeconds(totalDegrees, totalMinutes % 60, totalSeconds % 60.0);
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
        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case AngleDegreesMinutesSeconds angle:
                    return Equals(angle);
                default:
                    return false;
            }
        }

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
                hash = (hash * HashingMultiplier) + Degrees.GetHashCode();
                hash = (hash * HashingMultiplier) + Minutes.GetHashCode();
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

#if !NET35
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal static int Reduce(int degrees) =>
            Utils.Reduce(degrees, FullAngle);

#if !NET35
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal static Quadrant GetQuadrant(int degrees) =>
            Utils.GetQuadrant(degrees, RightAngle, StraightAngle, FullAngle);

#if !NET35
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal static double GetReference(in AngleDegreesMinutesSeconds angle) =>
            Utils.GetReference(GetDegreesAngle(angle), RightAngle, StraightAngle, FullAngle);

#if !NET35
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal static double GetDegreesAngle(in AngleDegreesMinutesSeconds angle)
        {
            var dec = angle.Minutes / 60.0 + angle.Seconds / 3600.0;
            return Math.Sign(angle.Degrees) < 0 ? angle.Degrees - dec : angle.Degrees + dec;
        }

#if !NET35
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal static bool EqualsReduced(in AngleDegreesMinutesSeconds angle, int degrees)
        {
            var reduced = Reduce(Math.Abs(angle.Degrees));
            return reduced == degrees && angle.Minutes == 0 && angle.Seconds == 0.0;
        }

#if !NET35
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal static bool GreaterThanReduced(in AngleDegreesMinutesSeconds angle, int minDegrees)
        {
            var reduced = Reduce(Math.Abs(angle.Degrees));
            return reduced > minDegrees || 
                reduced == minDegrees && angle.Minutes > 0.0 || 
                reduced == minDegrees && angle.Minutes == 0.0 && angle.Seconds > 0.0;
        }

#if !NET35
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal static bool InRangeReduced(in AngleDegreesMinutesSeconds angle, int minDegrees, int maxDegrees)
        {
            var reduced = Reduce(Math.Abs(angle.Degrees));
            return (reduced > minDegrees || 
                reduced == minDegrees && angle.Minutes > 0.0 || 
                reduced == minDegrees && angle.Minutes == 0 && angle.Seconds > 0.0) && 
                reduced < maxDegrees;
        }
    }

    public static partial class Angle
    {
        /// <summary>
        /// Returns an AngleDegreesMinutesSeconds that represents a specified number of degrees, minutes and seconds.
        /// </summary>
        /// <param name="value">A number of gradians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegreesMinutesSeconds FromDegrees(int degrees, int minutes, double seconds)
        {
            if (minutes < 0 || minutes >= 60)
                throw new ArgumentOutOfRangeException(nameof(minutes), minutes, "Argument must be positive and less than 60.");
            if (seconds < 0.0 || seconds >= 60.0)
                throw new ArgumentOutOfRangeException(nameof(seconds), seconds, "Argument must be positive and less than 60.");

            return new AngleDegreesMinutesSeconds(degrees, minutes, seconds);
        }

        /// <summary>
        /// Returns the absolute value of the AngleDegreesMinutesSeconds.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>
        /// An AngleDegreesMinutesSeconds, x, such that AngleDegreesMinutesSeconds.Zero &lt;= x &lt;= AngleDegreesMinutesSeconds.MaxValue.
        /// </returns>
        public static AngleDegreesMinutesSeconds Abs(in AngleDegreesMinutesSeconds angle) =>
            new AngleDegreesMinutesSeconds(Math.Abs(angle.Degrees), angle.Minutes, angle.Seconds);

        /// <summary>
        /// Returns a value indicating the sign of an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>A number that indicates the sign of value, -1 if value is less than zero, 0 if value equal to zero, 1 if value is grater than zero.</returns>
        public static int Sign(in AngleDegreesMinutesSeconds angle) =>
            Math.Sign(angle.Degrees);

        #region min

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is smaller.</returns>
        public static ref readonly AngleDegreesMinutesSeconds Min(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right) =>
            ref AngleDegreesMinutesSeconds.GetDegreesAngle(left) < AngleDegreesMinutesSeconds.GetDegreesAngle(right) ? 
                ref left : 
                ref right;

        #endregion

        #region max

        /// <summary>
        /// Returns the largest of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is larger.</returns>
        public static ref readonly AngleDegreesMinutesSeconds Max(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right) =>
            ref AngleDegreesMinutesSeconds.GetDegreesAngle(left) < AngleDegreesMinutesSeconds.GetDegreesAngle(right) ?
                ref left :
                ref right;

        #endregion

        #region reduce

        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns></returns>
        public static AngleDegreesMinutesSeconds Reduce(in AngleDegreesMinutesSeconds angle) =>
            new AngleDegreesMinutesSeconds(AngleDegrees.Reduce(AngleDegreesMinutesSeconds.GetDegreesAngle(angle)));

        /// <summary>
        /// Returns the quadrant where the terminal side of the angle is in when in the standard position.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The quadrant where the terminal side of the angle is in when in the standard position.</returns>
        public static Quadrant GetQuadrant(in AngleDegreesMinutesSeconds angle) =>
            AngleDegreesMinutesSeconds.GetQuadrant(angle.Degrees);

        /// <summary>
        /// Returns the reference angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The reference angle.</returns>
        public static AngleDegreesMinutesSeconds GetReference(in AngleDegreesMinutesSeconds angle) =>
            new AngleDegreesMinutesSeconds(AngleDegreesMinutesSeconds.GetReference(angle));

        #endregion

        #region comparison 

        /// <summary>
        /// Compares two AngleDegreesMinutesSeconds values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int Compare(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2) =>
            AngleDegreesMinutesSeconds.GetDegreesAngle(a1).CompareTo(AngleDegreesMinutesSeconds.GetDegreesAngle(a2));

        /// <summary>
        /// Compares two AngleDegreesMinutesSeconds values and returns an integer that indicates whether when both reduced the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int CompareReduced(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2) =>
            Compare(Reduce(a1), Reduce(a2));

        #endregion

        #region types of angles

        /// <summary>
        /// Indicates whether the specified angle is equal to Zero when reduced.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is zero; otherwise false.</returns>
        public static bool IsZero(in AngleDegreesMinutesSeconds angle) =>
            angle.Minutes == 0.0 && angle.Degrees % AngleDegreesMinutesSeconds.FullAngle == 0;

        /// <summary>
        /// Indicates whether the specified angle is acute.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than zero and less than 90 degrees; otherwise false.</returns>
        public static bool IsAcute(in AngleDegreesMinutesSeconds angle) =>
            AngleDegreesMinutesSeconds.InRangeReduced(angle, 0, AngleDegreesMinutesSeconds.RightAngle);

        /// <summary>
        /// Indicates whether the specified angle is right.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 90 degrees; otherwise false.</returns>
        public static bool IsRight(in AngleDegreesMinutesSeconds angle) =>
            AngleDegreesMinutesSeconds.EqualsReduced(angle, AngleDegreesMinutesSeconds.RightAngle);

        /// <summary>
        /// Indicates whether the specified angle is obtuse.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 90 degrees and less than 180 degrees; otherwise false.</returns>
        public static bool IsObtuse(in AngleDegreesMinutesSeconds angle) =>
            AngleDegreesMinutesSeconds.InRangeReduced(angle, AngleDegreesMinutesSeconds.RightAngle, AngleDegreesMinutesSeconds.StraightAngle);

        /// <summary>
        /// Indicates whether the specified angle is straight.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 180 degrees; otherwise false.</returns>
        public static bool IsStraight(in AngleDegreesMinutesSeconds angle) =>
            AngleDegreesMinutesSeconds.EqualsReduced(angle, AngleDegreesMinutesSeconds.StraightAngle);

        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 degrees and less than 360 degrees; otherwise false.</returns>
        public static bool IsReflex(in AngleDegreesMinutesSeconds angle) =>
            AngleDegreesMinutesSeconds.GreaterThanReduced(angle, AngleDegreesMinutesSeconds.StraightAngle);

        /// <summary>
        /// Indicates whether the specified angle is oblique.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the angle is not right or a multiple of a right angle; otherwise false.</returns>
        public static bool IsOblique(in AngleDegreesMinutesSeconds angle) =>
            angle.Minutes != 0.0 || angle.Degrees % AngleDegreesMinutesSeconds.RightAngle != 0.0;

        #endregion

        #region lerp

        /// <summary>
        /// Performs a linear interpolation.
        /// </summary>
        /// <param name="a1">The first angle.</param>
        /// <param name="a2">The second angle.</param>
        /// <param name="t">A value that linearly interpolates between the a1 parameter and the a2 parameter.</param>
        /// <returns>The result of the linear interpolation.</returns>
        public static AngleDegreesMinutesSeconds Lerp(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2, double t) =>
            new AngleDegreesMinutesSeconds(Utils.Lerp(AngleDegreesMinutesSeconds.GetDegreesAngle(a1), AngleDegreesMinutesSeconds.GetDegreesAngle(a2), t));

        #endregion

        #region negation

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleDegreesMinutesSeconds Negate(in AngleDegreesMinutesSeconds angle) =>
            new AngleDegreesMinutesSeconds(-angle.Degrees, angle.Minutes, angle.Seconds);

        #endregion

        #region addition

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleDegreesMinutesSeconds Add(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right)
        {
            var totalSeconds = left.Seconds + right.Seconds;
            var totalMinutes = left.Minutes + right.Minutes + (int)Math.Floor(totalSeconds / 60.0);
            var totalDegrees = left.Degrees + right.Degrees + (int)Math.Floor(totalMinutes / 60.0);
            return new AngleDegreesMinutesSeconds(totalDegrees, totalMinutes % 60, totalSeconds % 60);
        }

        #endregion

        #region subtraction

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleDegreesMinutesSeconds Subtract(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right)
        {
            var totalSeconds = left.Seconds - right.Seconds;
            var totalMinutes = left.Minutes - right.Minutes + (int)Math.Floor(totalSeconds / 60.0);
            var totalDegrees = left.Degrees - right.Degrees + (int)Math.Floor(totalMinutes / 60.0);
            return new AngleDegreesMinutesSeconds(totalDegrees, totalMinutes % 60, totalSeconds % 60);
        }

        #endregion

        #region multiplication

        /// <summary>
        /// Multiplies a angle by a scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleDegreesMinutesSeconds Multiply(double left, in AngleDegreesMinutesSeconds right)
        {
            var totalSeconds = left * right.Seconds;
            var totalMinutes = (int)Math.Floor(left * right.Degrees + totalSeconds / 60.0);
            var totalDegrees = (int)Math.Floor(left * right.Degrees + totalMinutes / 60.0);
            return new AngleDegreesMinutesSeconds(totalDegrees, totalMinutes % 60, totalSeconds % 60.0);
        }

        #endregion

        #region division

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleDegreesMinutesSeconds Divide(in AngleDegreesMinutesSeconds left, double right)
        {
            var totalSeconds = left.Seconds / right;
            var totalMinutes = (int)Math.Floor(left.Degrees / right + totalSeconds / 60.0);
            var totalDegrees = (int)Math.Floor(left.Degrees / right + totalMinutes / 60.0);
            return new AngleDegreesMinutesSeconds(totalDegrees, totalMinutes % 60, totalSeconds % 60.0);
        }

        #endregion
    }
}
