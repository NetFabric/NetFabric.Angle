using System;

namespace NetFabric
{
    public readonly struct AngleDegreesMinutes
        : IEquatable<AngleDegreesMinutes>
        , IComparable
        , IComparable<AngleDegreesMinutes>
        , IFormattable
    {
        /// <summary>
        /// Represents the zero DegreesMinutesAngle value (0 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutes Zero = new AngleDegreesMinutes(0, 0.0);

        /// <summary>
        /// Represents the smallest possible value of a DegreesMinutesAngle. This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutes MinValue = new AngleDegreesMinutes(int.MinValue, 60.0 - double.Epsilon);

        /// <summary>
        /// Represents the largest possible value of a DegreesMinutesAngle. This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutes MaxValue = new AngleDegreesMinutes(int.MaxValue, 60.0 - double.Epsilon);

        /// <summary>
        /// Represents the right DegreesMinutesAngle value (90 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutes Right = new AngleDegreesMinutes(RightAngle, 0.0);

        /// <summary>
        /// Represents the straight DegreesMinutesAngle value (180 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegreesMinutes Straight = new AngleDegreesMinutes(StraightAngle, 0.0);

        /// <summary>
        /// Represents the full DegreesMinutesAngle value (360 degrees). This field is read-only.
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

        internal AngleDegreesMinutes(double degrees)
        {
            Degrees = (int)Math.Floor(degrees);
            Minutes = Math.Abs(degrees - Degrees) * 60.0;
        }

        internal AngleDegreesMinutes(int degrees, double minutes)
        {
            Degrees = degrees;
            Minutes = minutes;
        }

        #region equality implementation

        /// <summary>
        /// Indicates whether two DegreesMinutesAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator ==(AngleDegreesMinutes a1, AngleDegreesMinutes a2) =>
            a1.Degrees == a2.Degrees && a1.Minutes == a2.Minutes;

        /// <summary>
        /// Indicates whether two DegreesMinutesAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator !=(AngleDegreesMinutes a1, AngleDegreesMinutes a2) =>
            a1.Degrees != a2.Degrees || a1.Minutes != a2.Minutes;

        /// <summary>
        /// Indicates whether two DegreesMinutesAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool Equals(AngleDegreesMinutes a1, AngleDegreesMinutes a2) =>
            a1.Degrees == a2.Degrees && a1.Minutes == a2.Minutes;

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified DegreesMinutesAngle object.
        /// </summary>
        /// <param name="other">An DegreesMinutesAngle to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="AngleDegreesMinutes.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public bool Equals(AngleDegreesMinutes other) =>
            Degrees == other.Degrees && Minutes == other.Minutes;

        #endregion

        #region comparison implementation

        /// <summary>
        /// Indicates whether a specified DegreesMinutesAngle is less than another specified DegreesMinutesAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than the value of a2; otherwise, false.</returns>
        public static bool operator <(AngleDegreesMinutes a1, AngleDegreesMinutes a2) =>
            a1.Degrees == a2.Degrees ? a1.Minutes < a2.Minutes : a1.Degrees < a2.Degrees;

        /// <summary>
        /// Indicates whether a specified DegreesMinutesAngle is less than or equal to another specified DegreesMinutesAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator <=(AngleDegreesMinutes a1, AngleDegreesMinutes a2) =>
            a1.Degrees == a2.Degrees ? a1.Minutes <= a2.Minutes : a1.Degrees < a2.Degrees;

        /// <summary>
        /// Indicates whether a specified DegreesMinutesAngle is greater than another specified DegreesMinutesAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than the value of a2; otherwise, false.</returns>
        public static bool operator >(AngleDegreesMinutes a1, AngleDegreesMinutes a2) =>
            a1.Degrees == a2.Degrees ? a1.Minutes > a2.Minutes : a1.Degrees > a2.Degrees;

        /// <summary>
        /// Indicates whether a specified DegreesMinutesAngle is greater than or equal to another specified DegreesMinutesAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator >=(AngleDegreesMinutes a1, AngleDegreesMinutes a2) =>
            a1.Degrees == a2.Degrees ? a1.Minutes >= a2.Minutes : a1.Degrees > a2.Degrees;

        int IComparable<AngleDegreesMinutes>.CompareTo(AngleDegreesMinutes other) =>
            Angle.Compare(this, other);

        int IComparable.CompareTo(object obj)
        {
            switch (obj)
            {
                case AngleDegreesMinutes angle:
                    return Angle.Compare(this, angle);
                default:
                    throw new ArgumentException($"Argument has to be an {nameof(AngleDegreesMinutes)}.", nameof(obj));
            }
        }

        #endregion

        #region math operators

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleDegreesMinutes operator -(AngleDegreesMinutes angle) =>
            new AngleDegreesMinutes(-angle.Degrees, angle.Minutes);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleDegreesMinutes operator +(AngleDegreesMinutes left, AngleDegreesMinutes right)
        {
            var totalMinutes = left.Minutes + right.Minutes;
            return new AngleDegreesMinutes(left.Degrees + right.Degrees + (int)Math.Floor(totalMinutes / 60.0), totalMinutes % 60.0);
        }

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleDegreesMinutes operator -(AngleDegreesMinutes left, AngleDegreesMinutes right)
        {
            var totalMinutes = left.Minutes - right.Minutes;
            return new AngleDegreesMinutes(left.Degrees - right.Degrees + (int)Math.Floor(totalMinutes / 60.0), totalMinutes % 60.0);
        }

        /// <summary>
        /// Multiplies a scalar by an angle value. 
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleDegreesMinutes operator *(double left, AngleDegreesMinutes right)
        {
            var totalMinutes = left * right.Minutes;
            return new AngleDegreesMinutes((int)Math.Floor(left * right.Degrees + totalMinutes / 60.0), totalMinutes % 60.0);
        }

        /// <summary>
        /// Divides a angle by a scalar value. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleDegreesMinutes operator /(AngleDegreesMinutes left, double right)
        {
            var totalMinutes = left.Minutes / right;
            return new AngleDegreesMinutes((int)Math.Floor(left.Degrees / right + totalMinutes / 60.0), totalMinutes % 60.0);
        }

        #endregion

        #region string format

        /// <summary>
        /// Converts the value of the current DegreesMinutesAngle object to its equivalent string representation, using a specified format.
        /// </summary>
        /// <param name="format">A string that specifies the format to be used for the returned string.</param>
        /// <returns>A string representation of the value of the current DegreesMinutesAngle object, in the specified format.</returns>
        public string ToString(string format) =>
            $"{Degrees}° {Minutes.ToString(format)}'";

        /// <summary>
        /// Converts the value of the current DegreesMinutesAngle object to its equivalent string representation using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current DegreesMinutesAngle object as specified by format and provider.</returns>
        public string ToString(string format, IFormatProvider formatProvider) =>
            $"{Degrees}° {Minutes.ToString(format, formatProvider)}'";

        #endregion

        #region object overrides

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>true if value is a DegreesMinutesAngle object that represents the same angle as the current DegreesMinutesAngle structure; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case AngleDegreesMinutes angle:
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
                return hash;
            }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() =>
            $"{Degrees}° {Minutes}'";

        #endregion

        internal const int RightAngle = 90;
        internal const int StraightAngle = 180;
        internal const int FullAngle = 360;

        internal static int Reduce(int degrees) =>
            Utils.Reduce(degrees, FullAngle);

        internal static Quadrant GetQuadrant(int degrees) =>
            Utils.GetQuadrant(degrees, RightAngle, StraightAngle, FullAngle);

        internal static double GetReference(int degrees, double minutes) =>
            Utils.GetReference(GetDegreesAngle(degrees, minutes), RightAngle, StraightAngle, FullAngle);

        internal static double GetDegreesAngle(int degrees, double minutes) =>
            Math.Sign(degrees) < 0 ? degrees - minutes / 60.0 : degrees + minutes / 60.0;
    }

    public static partial class Angle
    {
        /// <summary>
        /// Returns an GradianssAngle that represents a specified number of degrees and minutes.
        /// </summary>
        /// <param name="value">A number of gradians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegreesMinutes FromDegreesMinutes(int degrees, double minutes)
        {
            if (minutes < 0.0 || minutes >= 60.0)
                throw new ArgumentOutOfRangeException(nameof(minutes), minutes, "Argument must be positive and less than 60.");

            return new AngleDegreesMinutes(degrees, minutes);
        }

        /// <summary>
        /// Returns the absolute value of the DegreesMinutesAngle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>
        /// An DegreesMinutesAngle, x, such that DegreesMinutesAngle.Zero &lt;= x &lt;= DegreesMinutesAngle.MaxValue.
        /// </returns>
        public static AngleDegreesMinutes Abs(AngleDegreesMinutes angle) =>
            new AngleDegreesMinutes(Math.Abs(angle.Degrees), angle.Minutes);

        /// <summary>
        /// Returns a value indicating the sign of an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>A number that indicates the sign of value, -1 if value is less than zero, 0 if value equal to zero, 1 if value is grater than zero.</returns>
        public static int Sign(AngleDegreesMinutes angle) =>
            Math.Sign(angle.Degrees);

        #region min

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is smaller.</returns>
        public static ref readonly AngleDegreesMinutes Min(in AngleDegreesMinutes left, in AngleDegreesMinutes right)
        {
            // compare degrees component

            if (left.Degrees < right.Degrees)
                return ref left;

            if (left.Degrees > right.Degrees)
                return ref right;

            // degrees components are equal, compare minutes component

            if (left.Minutes < right.Minutes)
                return ref left;

            return ref right;
        }

        #endregion

        #region max

        /// <summary>
        /// Returns the largest of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is larger.</returns>
        public static ref readonly AngleDegreesMinutes Max(in AngleDegreesMinutes left, in AngleDegreesMinutes right)
        {
            // compare degrees component

            if (left.Degrees < right.Degrees)
                return ref right;

            if (left.Degrees > right.Degrees)
                return ref left;

            // degrees components are equal, compare minutes component

            if (left.Minutes < right.Minutes)
                return ref right;

            return ref left;
        }

        #endregion

        #region reduce

        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns></returns>
        public static AngleDegreesMinutes Reduce(AngleDegreesMinutes angle) =>
            new AngleDegreesMinutes(AngleDegreesMinutes.Reduce(angle.Degrees), angle.Minutes);

        /// <summary>
        /// Returns the quadrant where the terminal side of the angle is in when in the standard position.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The quadrant where the terminal side of the angle is in when in the standard position.</returns>
        public static Quadrant GetQuadrant(AngleDegreesMinutes angle) =>
            AngleDegreesMinutes.GetQuadrant(angle.Degrees);

        /// <summary>
        /// Returns the reference angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The reference angle.</returns>
        public static AngleDegreesMinutes GetReference(AngleDegreesMinutes angle) =>
            new AngleDegreesMinutes(AngleDegreesMinutes.GetReference(angle.Degrees, angle.Minutes));

        #endregion

        #region comparison 

        /// <summary>
        /// Compares two DegreesMinutesAngle values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int Compare(AngleDegreesMinutes a1, AngleDegreesMinutes a2)
        {
            if (a1.Degrees == a2.Degrees)
            {
                if (a1.Minutes == a2.Minutes)
                {
                    return 0;
                }
                else if (a1.Minutes > a2.Minutes)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else if (a1.Degrees > a2.Degrees)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Compares two DegreesMinutesAngle values and returns an integer that indicates whether when both reduced the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int CompareReduced(AngleDegreesMinutes a1, AngleDegreesMinutes a2) =>
            Compare(Reduce(a1), Reduce(a2));

        #endregion

        #region types of angles

        /// <summary>
        /// Indicates whether the specified angle is equal to Zero when reduced.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is zero; otherwise false.</returns>
        public static bool IsZero(AngleDegreesMinutes angle) =>
            angle.Degrees % AngleDegreesMinutes.FullAngle == 0 && angle.Minutes == 0.0;

        /// <summary>
        /// Indicates whether the specified angle is acute.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than zero and less than 90 degrees; otherwise false.</returns>
        public static bool IsAcute(AngleDegreesMinutes angle)
        {
            var reduced = AngleDegreesMinutes.Reduce(Math.Abs(angle.Degrees));
            return reduced > 0.0 && reduced < AngleDegreesMinutes.RightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is right.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 90 degrees; otherwise false.</returns>
        public static bool IsRight(AngleDegreesMinutes angle) =>
            Math.Abs(AngleDegreesMinutes.Reduce(angle.Degrees)) == AngleDegreesMinutes.RightAngle && angle.Minutes == 0.0;

        /// <summary>
        /// Indicates whether the specified angle is obtuse.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 90 degrees and less than 180 degrees; otherwise false.</returns>
        public static bool IsObtuse(AngleDegreesMinutes angle)
        {
            var reduced = AngleDegreesMinutes.Reduce(Math.Abs(angle.Degrees), angle.Minutes);
            return reduced > AngleDegreesMinutes.RightAngle && reduced < AngleDegreesMinutes.StraightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is straight.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 180 degrees; otherwise false.</returns>
        public static bool IsStraight(AngleDegreesMinutes angle) =>
            AngleDegreesMinutes.Reduce(Math.Abs(angle.Degrees), angle.Minutes) == AngleDegreesMinutes.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 degrees and less than 360 degrees; otherwise false.</returns>
        public static bool IsReflex(AngleDegreesMinutes angle) =>
            AngleDegreesMinutes.Reduce(Math.Abs(angle.Degrees), angle.Minutes) > AngleDegreesMinutes.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is oblique.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the angle is not right or a multiple of a right angle; otherwise false.</returns>
        public static bool IsOblique(AngleDegreesMinutes angle) =>
            angle.Degrees % AngleDegreesMinutes.RightAngle != 0.0;

        #endregion

        #region lerp

        /// <summary>
        /// Performs a linear interpolation.
        /// </summary>
        /// <param name="a1">The first angle.</param>
        /// <param name="a2">The second angle.</param>
        /// <param name="t">A value that linearly interpolates between the a1 parameter and the a2 parameter.</param>
        /// <returns>The result of the linear interpolation.</returns>
        public static AngleDegreesMinutes Lerp(AngleDegreesMinutes a1, AngleDegreesMinutes a2, double t) =>
            new AngleDegreesMinutes(Utils.Lerp(AngleDegreesMinutes.GetDegreesAngle(a1.Degrees, a1.Minutes), AngleDegreesMinutes.GetDegreesAngle(a2.Degrees, a2.Minutes), t));

        #endregion

        #region negation

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleDegreesMinutes Negate(AngleDegreesMinutes angle) =>
            new AngleDegreesMinutes(-angle.Degrees, angle.Minutes);

        #endregion

        #region addition

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleDegreesMinutes Add(AngleDegreesMinutes left, AngleDegreesMinutes right)
        {
            var totalMinutes = left.Minutes + right.Minutes;
            return new AngleDegreesMinutes(left.Degrees + right.Degrees + (int)Math.Floor(totalMinutes / 60.0), totalMinutes % 60.0);
        }

        #endregion

        #region subtraction

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleDegreesMinutes Subtract(AngleDegreesMinutes left, AngleDegreesMinutes right)
        {
            var totalMinutes = left.Minutes - right.Minutes;
            return new AngleDegreesMinutes(left.Degrees - right.Degrees + (int)Math.Floor(totalMinutes / 60.0), totalMinutes % 60.0);
        }

        #endregion

        #region multiplication

        /// <summary>
        /// Multiplies a angle by a scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleDegreesMinutes Multiply(double left, AngleDegreesMinutes right)
        {
            var totalMinutes = left * right.Minutes;
            return new AngleDegreesMinutes((int)Math.Floor(left * right.Degrees + totalMinutes / 60.0), totalMinutes % 60.0);
        }

        #endregion

        #region division

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleDegreesMinutes Divide(AngleDegreesMinutes left, double right)
        {
            var totalMinutes = left.Minutes / right;
            return new AngleDegreesMinutes((int)Math.Floor(left.Degrees / right + totalMinutes / 60.0), totalMinutes % 60.0);
        }

        #endregion

    }
}
