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
        /// Represents a AngleDegreesMinutesSeconds value that is not a number (NaN). This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutesSeconds NaN = new AngleDegreesMinutesSeconds(0, 0, double.NaN);

        /// <summary>
        /// Represents the zero AngleDegreesMinutesSeconds value. This field is read-only.
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

        readonly int degrees;
        readonly int minutes;
        readonly double seconds;

        /// <summary>
        /// Gets the degrees component of the amplitude of the angle. This field is read-only.
        /// </summary>
        public int Degrees => 
            degrees;

        /// <summary>
        /// Gets the minutes component of the amplitude of the angle. This field is read-only.
        /// </summary>
        public int Minutes =>
            Math.Abs(minutes);

        /// <summary>
        /// Gets the seconds component of the amplitude of the angle. This field is read-only.
        /// </summary>
        public double Seconds =>
            Math.Abs(seconds);

        internal AngleDegreesMinutesSeconds(double degrees)
        {
            this.degrees = (int)degrees;
            var decimalMinutes = (degrees - this.degrees) * 60.0;
            this.minutes = (int)decimalMinutes;
            this.seconds = (decimalMinutes - this.minutes) * 60.0;
        }

        internal AngleDegreesMinutesSeconds(int degrees, int minutes, double seconds)
        {
            this.degrees = degrees;
            this.minutes = minutes;
            this.seconds = seconds;
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
            new AngleDegreesMinutesSeconds(-angle.degrees, -angle.minutes, -angle.seconds);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleDegreesMinutesSeconds operator +(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right)
        {
            var seconds = Utils.ToBase60(left.seconds + right.seconds, out var secondsCarry);
            var minutes = Utils.ToBase60(left.minutes + right.minutes + (int)secondsCarry, out var minutesCarry);
            var degrees = left.degrees + right.degrees + minutesCarry;
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
            if (left.seconds >= right.seconds)
            {
                seconds = Utils.ToBase60(left.seconds - right.seconds, out secondsCarry);
            }
            else
            {
                seconds = Utils.ToBase60(60.0 + left.seconds - right.seconds, out secondsCarry);
                secondsCarry -= 1.0;
            }

            int minutes, minutesCarry;
            if (left.minutes >= right.minutes)
            {
                minutes = Utils.ToBase60((int)secondsCarry + left.minutes - right.minutes, out minutesCarry);
            }
            else
            {
                minutes = Utils.ToBase60(60 + (int)secondsCarry + left.minutes - right.minutes, out minutesCarry);
                minutesCarry -= 1;
            }

            var degrees = minutesCarry + left.degrees - right.degrees;
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
            var seconds = Utils.ToBase60(left * right.seconds, out var secondsCarry);
            var minutes = (int)Utils.ToBase60(left * right.minutes + (int)secondsCarry, out var minutesCarry);
            var degrees = (int)(left * right.degrees + minutesCarry);
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

            var seconds = Utils.ToBase60(left.seconds / right, out var secondsCarry);
            var minutes = (int)Utils.ToBase60(left.minutes / right + (int)secondsCarry, out var minutesCarry);
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
        internal static AngleDegreesMinutesSeconds Reduce(in AngleDegreesMinutesSeconds angle)
        {
            var degrees = Utils.Reduce(angle.degrees, FullAngle);
            if (angle.minutes == 0 && angle.seconds == 0)
                return new AngleDegreesMinutesSeconds(degrees, 0, 0.0);

            if (degrees < 0)
                return new AngleDegreesMinutesSeconds(FullAngle + degrees, angle.minutes, angle.seconds);

            return new AngleDegreesMinutesSeconds(degrees, angle.minutes, angle.seconds);
        }

#if !NET35
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal static Quadrant GetQuadrant(int degrees) =>
            Utils.GetQuadrant(degrees, RightAngle, StraightAngle, FullAngle);

#if !NET35
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal static AngleDegreesMinutesSeconds GetReference(in AngleDegreesMinutesSeconds angle)
        {
            var degrees = Utils.GetReference(angle.degrees, RightAngle, StraightAngle, FullAngle);
            if (angle.minutes == 0 && angle.seconds == 0)
                return new AngleDegreesMinutesSeconds(degrees, 0, 0.0);

            if (angle.degrees < 0)
                return new AngleDegreesMinutesSeconds(degrees - 1, angle.minutes + 60, angle.seconds + 60.0);

            return new AngleDegreesMinutesSeconds(degrees, angle.minutes, angle.seconds);
        }

#if !NET35
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal static double GetDegreesAngle(in AngleDegreesMinutesSeconds angle) =>
            angle.degrees + angle.minutes / 60.0 + angle.seconds / 3_600.0;

#if !NET35
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal static bool EqualsReduced(in AngleDegreesMinutesSeconds angle1, in AngleDegreesMinutesSeconds angle2) =>
            AngleDegreesMinutesSeconds.Equals(Reduce(angle1), angle2);

#if !NET35
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal static bool GreaterThanReduced(in AngleDegreesMinutesSeconds angle1, in AngleDegreesMinutesSeconds angle2)
        {
            var reduced = Reduce(angle1);
            return reduced > angle2;
        }

#if !NET35
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal static bool InRangeReduced(in AngleDegreesMinutesSeconds angle, in AngleDegreesMinutesSeconds minAngle, in AngleDegreesMinutesSeconds maxAngle)
        {
            var reduced = Reduce(angle);
            return (reduced > minAngle && reduced < maxAngle); 
        }

#if !NET35
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal static int Compare(in AngleDegreesMinutesSeconds angle1, in AngleDegreesMinutesSeconds angle2)
        {
            if (angle1.degrees > angle2.degrees)
                return 1;
            if (angle1.degrees < angle2.degrees)
                return -1;
            if (angle1.minutes > angle2.minutes)
                return 1;
            if (angle1.minutes < angle2.minutes)
                return -1;
            if (angle1.seconds > angle2.seconds)
                return 1;
            if (angle1.seconds < angle2.seconds)
                return -1;
            return 0;
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
            if (degrees < 0)
                throw new ArgumentOutOfRangeException(nameof(degrees), seconds, "Argument must be greater or equal to 0.");
            if (minutes < 0 || minutes >= 60)
                throw new ArgumentOutOfRangeException(nameof(minutes), minutes, "Argument must be greater or equal to 0 and less than 60.");
            if (seconds < 0.0 || seconds >= 60.0)
                throw new ArgumentOutOfRangeException(nameof(seconds), seconds, "Argument must be greater or equal to 0 and less than 60.");

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
            new AngleDegreesMinutesSeconds(Math.Abs(angle.Degrees), Math.Abs(angle.Minutes), Math.Abs(angle.Seconds));

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
            AngleDegreesMinutesSeconds.Reduce(angle);

        //public static AngleDegreesMinutesSeconds Reduce(in AngleDegreesMinutesSeconds angle) =>
        //    new AngleDegreesMinutesSeconds(AngleDegreesMinutesSeconds.Reduce(angle.Degrees), angle.Minutes, angle.Seconds);

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
            AngleDegreesMinutesSeconds.GetReference(angle);

        #endregion

        #region comparison 

        /// <summary>
        /// Compares two AngleDegreesMinutesSeconds values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int Compare(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2) =>
            AngleDegreesMinutesSeconds.Compare(a1, a2);

        /// <summary>
        /// Compares two AngleDegreesMinutesSeconds values and returns an integer that indicates whether when both reduced the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int CompareReduced(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2) =>
            AngleDegreesMinutesSeconds.Compare(Reduce(a1), Reduce(a2));

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
            AngleDegreesMinutesSeconds.InRangeReduced(Angle.Abs(angle), AngleDegreesMinutesSeconds.Zero, AngleDegreesMinutesSeconds.Right);

        /// <summary>
        /// Indicates whether the specified angle is right.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 90 degrees; otherwise false.</returns>
        public static bool IsRight(in AngleDegreesMinutesSeconds angle) =>
            AngleDegreesMinutesSeconds.EqualsReduced(Angle.Abs(angle), AngleDegreesMinutesSeconds.Right);

        /// <summary>
        /// Indicates whether the specified angle is obtuse.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 90 degrees and less than 180 degrees; otherwise false.</returns>
        public static bool IsObtuse(in AngleDegreesMinutesSeconds angle) =>
            AngleDegreesMinutesSeconds.InRangeReduced(Angle.Abs(angle), AngleDegreesMinutesSeconds.Right, AngleDegreesMinutesSeconds.Straight);

        /// <summary>
        /// Indicates whether the specified angle is straight.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 180 degrees; otherwise false.</returns>
        public static bool IsStraight(in AngleDegreesMinutesSeconds angle) =>
            AngleDegreesMinutesSeconds.EqualsReduced(Angle.Abs(angle), AngleDegreesMinutesSeconds.Straight);

        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 degrees and less than 360 degrees; otherwise false.</returns>
        public static bool IsReflex(in AngleDegreesMinutesSeconds angle) =>
            AngleDegreesMinutesSeconds.GreaterThanReduced(Angle.Abs(angle), AngleDegreesMinutesSeconds.Straight);

        /// <summary>
        /// Indicates whether the specified angle is oblique.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the angle is not right or a multiple of a right angle; otherwise false.</returns>
        public static bool IsOblique(in AngleDegreesMinutesSeconds angle) =>
            angle.Minutes != 0.0 || angle.Seconds != 0.0 || angle.Degrees % AngleDegreesMinutesSeconds.RightAngle != 0.0;

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
            -angle;

        #endregion

        #region addition

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleDegreesMinutesSeconds Add(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right) =>
            left + right;

        #endregion

        #region subtraction

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleDegreesMinutesSeconds Subtract(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right) =>
            left - right;

        #endregion

        #region multiplication

        /// <summary>
        /// Multiplies a angle by a scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleDegreesMinutesSeconds Multiply(double left, in AngleDegreesMinutesSeconds right) =>
            left * right;

        #endregion

        #region division

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleDegreesMinutesSeconds Divide(in AngleDegreesMinutesSeconds left, double right) =>
            left / right;

        #endregion
    }
}
