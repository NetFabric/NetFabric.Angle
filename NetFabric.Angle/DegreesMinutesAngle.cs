using System;

namespace NetFabric
{
    public struct DegreesMinutesAngle
        : IEquatable<DegreesMinutesAngle>
        , IComparable
        , IComparable<DegreesMinutesAngle>
        , IFormattable
    {
        /// <summary>
        /// Represents the zero DegreesMinutesAngle value (0 degrees). This field is read-only.
        /// </summary>
        public static readonly DegreesMinutesAngle Zero = new DegreesMinutesAngle(0, 0.0);

        /// <summary>
        /// Represents the golden DegreesMinutesAngle value (~137.508 degrees). This field is read-only.
        /// </summary>
        public static readonly DegreesMinutesAngle Golden = Angle.InDegreesMinutes(RadiansAngle.Golden);

        /// <summary>
        /// Represents the smallest possible value of a DegreesMinutesAngle. This field is read-only.
        /// </summary>
        public static readonly DegreesMinutesAngle MinValue = new DegreesMinutesAngle(int.MinValue, 60.0 - double.Epsilon);

        /// <summary>
        /// Represents the largest possible value of a DegreesMinutesAngle. This field is read-only.
        /// </summary>
        public static readonly DegreesMinutesAngle MaxValue = new DegreesMinutesAngle(int.MaxValue, 60.0 - double.Epsilon);

        /// <summary>
        /// Represents the right DegreesMinutesAngle value (90 degrees). This field is read-only.
        /// </summary>
        public static readonly DegreesMinutesAngle Right = new DegreesMinutesAngle(RightAngle, 0.0);

        /// <summary>
        /// Represents the straight DegreesMinutesAngle value (180 degrees). This field is read-only.
        /// </summary>
        public static readonly DegreesMinutesAngle Straight = new DegreesMinutesAngle(StraightAngle, 0.0);

        /// <summary>
        /// Represents the full DegreesMinutesAngle value (360 degrees). This field is read-only.
        /// </summary>
        public static readonly DegreesMinutesAngle Full = new DegreesMinutesAngle(FullAngle, 0.0);

        /// <summary>
        /// Gets the degrees component of the amplitude of the angle. This field is read-only.
        /// </summary>
        public readonly int Degrees;

        /// <summary>
        /// Gets the minutes component of the amplitude of the angle. This field is read-only.
        /// </summary>
        public readonly double Minutes;

        internal DegreesMinutesAngle(double degrees)
        {
            Degrees = (int)degrees;
            Minutes = Math.Abs(degrees - Degrees) * 60.0;
        }

        internal DegreesMinutesAngle(int degrees, double minutes)
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
        public static bool operator ==(DegreesMinutesAngle a1, DegreesMinutesAngle a2) =>
            a1.Degrees == a2.Degrees && a1.Minutes == a2.Minutes;

        /// <summary>
        /// Indicates whether two DegreesMinutesAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator !=(DegreesMinutesAngle a1, DegreesMinutesAngle a2) =>
            a1.Degrees != a2.Degrees || a1.Minutes != a2.Minutes;

        /// <summary>
        /// Indicates whether two DegreesMinutesAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool Equals(DegreesMinutesAngle a1, DegreesMinutesAngle a2) =>
            a1.Degrees == a2.Degrees && a1.Minutes == a2.Minutes;

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified DegreesMinutesAngle object.
        /// </summary>
        /// <param name="other">An DegreesMinutesAngle to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="DegreesMinutesAngle.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public bool Equals(DegreesMinutesAngle other) =>
            Degrees == other.Degrees && Minutes == other.Minutes;

        #endregion

        #region comparison implementation

        /// <summary>
        /// Indicates whether a specified DegreesMinutesAngle is less than another specified DegreesMinutesAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than the value of a2; otherwise, false.</returns>
        public static bool operator <(DegreesMinutesAngle a1, DegreesMinutesAngle a2) =>
            a1.Degrees == a2.Degrees ? a1.Minutes < a2.Minutes : a1.Degrees < a2.Degrees;

        /// <summary>
        /// Indicates whether a specified DegreesMinutesAngle is less than or equal to another specified DegreesMinutesAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator <=(DegreesMinutesAngle a1, DegreesMinutesAngle a2) =>
            a1.Degrees == a2.Degrees ? a1.Minutes <= a2.Minutes : a1.Degrees < a2.Degrees;

        /// <summary>
        /// Indicates whether a specified DegreesMinutesAngle is greater than another specified DegreesMinutesAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than the value of a2; otherwise, false.</returns>
        public static bool operator >(DegreesMinutesAngle a1, DegreesMinutesAngle a2) =>
            a1.Degrees == a2.Degrees ? a1.Minutes > a2.Minutes : a1.Degrees > a2.Degrees;

        /// <summary>
        /// Indicates whether a specified DegreesMinutesAngle is greater than or equal to another specified DegreesMinutesAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator >=(DegreesMinutesAngle a1, DegreesMinutesAngle a2) =>
            a1.Degrees == a2.Degrees ? a1.Minutes >= a2.Minutes : a1.Degrees > a2.Degrees;

        int IComparable<DegreesMinutesAngle>.CompareTo(DegreesMinutesAngle other) =>
            Angle.Compare(this, other);

        int IComparable.CompareTo(object obj)
        {
            switch (obj)
            {
                case DegreesMinutesAngle angle:
                    return Angle.Compare(this, angle);
                default:
                    throw new ArgumentException("Argument has to be of type DegreesMinutesAngle.", nameof(obj));
            }
        }

        #endregion

        #region math operators

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static DegreesMinutesAngle operator -(DegreesMinutesAngle angle) =>
            new DegreesMinutesAngle(-angle.Degrees, angle.Minutes);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static DegreesMinutesAngle operator +(DegreesMinutesAngle left, DegreesMinutesAngle right) =>
            new DegreesMinutesAngle(left.DegreesMinutes + right.DegreesMinutes);

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static DegreesMinutesAngle operator -(DegreesMinutesAngle left, DegreesMinutesAngle right) =>
            new DegreesMinutesAngle(left.DegreesMinutes - right.DegreesMinutes);

        /// <summary>
        /// Multiplies a scalar by an angle value. 
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static DegreesMinutesAngle operator *(double left, DegreesMinutesAngle right) =>
            new DegreesMinutesAngle(left * right.DegreesMinutes);

        /// <summary>
        /// Divides a angle by a scalar value. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static DegreesMinutesAngle operator /(DegreesMinutesAngle left, double right) =>
            new DegreesMinutesAngle(left.DegreesMinutes / right);

        #endregion

        #region string format

        /// <summary>
        /// Converts the value of the current DegreesMinutesAngle object to its equivalent string representation, using a specified format.
        /// </summary>
        /// <param name="format">A string that specifies the format to be used for the returned string.</param>
        /// <returns>A string representation of the value of the current DegreesMinutesAngle object, in the specified format.</returns>
        public string ToString(string format) =>
            DegreesMinutes.ToString(format);

        /// <summary>
        /// Converts the value of the current DegreesMinutesAngle object to its equivalent string representation using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current DegreesMinutesAngle object as specified by format and provider.</returns>
        public string ToString(string format, IFormatProvider formatProvider) =>
            DegreesMinutes.ToString(format, formatProvider);

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
                case DegreesMinutesAngle angle:
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

        internal static double Reduce(int degrees, double minutes) =>
            Utils.Reduce(degrees, FullAngle);

        internal static Quadrant GetQuadrant(int degrees, double minutes) =>
            Utils.GetQuadrant(degrees, RightAngle, StraightAngle, FullAngle);

        internal static double GetReference(int degrees, double minutes) =>
            Utils.GetReference(degrees, RightAngle, StraightAngle, FullAngle);

        internal static double GetDegreesAngle(int degrees, double minutes) =>
            Math.Sign(degrees) < 0 ? degrees - minutes / 60.0 : degrees + minutes / 60.0;
    }

    public static partial class Angle
    {
        /// <summary>
        /// Returns the absolute value of the DegreesMinutesAngle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>
        /// An DegreesMinutesAngle, x, such that DegreesMinutesAngle.Zero &lt;= x &lt;= DegreesMinutesAngle.MaxValue.
        /// </returns>
        public static DegreesMinutesAngle Abs(DegreesMinutesAngle angle) =>
            new DegreesMinutesAngle(Math.Abs(angle.Degrees), angle.Minutes);

        /// <summary>
        /// Returns a value indicating the sign of an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>A number that indicates the sign of value, -1 if value is less than zero, 0 if value equal to zero, 1 if value is grater than zero.</returns>
        public static int Sign(DegreesMinutesAngle angle) =>
            Math.Sign(angle.Degrees);

        #region min

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>Parameter left or right, whichever is smaller.</returns>
        public static DegreesMinutesAngle Min(DegreesMinutesAngle left, DegreesMinutesAngle right)
        {
            if (left.Degrees == right.Degrees)
            {
                if (left.Minutes < right.Minutes)
                {
                    return left;
                }
                else
                {
                    return right;
                }
            }
            else
            {
                if (left.Degrees < right.Degrees)
                {
                    return left;
                }
                else
                {
                    return right;
                }
            }
        }

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is smaller.</returns>
        public static ref DegreesMinutesAngle Min(ref DegreesMinutesAngle left, ref DegreesMinutesAngle right)
        {
            if (left.Degrees == right.Degrees)
            {
                if (left.Minutes < right.Minutes)
                {
                    return ref left;
                }
                else
                {
                    return ref right;
                }
            }
            else
            {
                if (left.Degrees < right.Degrees)
                {
                    return ref left;
                }
                else
                {
                    return ref right;
                }
            }
        }

        #endregion

        #region max

        /// <summary>
        /// Returns the largest of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>Parameter left or right, whichever is larger.</returns>
        public static DegreesMinutesAngle Max(DegreesMinutesAngle left, DegreesMinutesAngle right)
        {
            if (left.Degrees == right.Degrees)
            {
                if (left.Minutes > right.Minutes)
                {
                    return left;
                }
                else
                {
                    return right;
                }
            }
            else
            {
                if (left.Degrees > right.Degrees)
                {
                    return left;
                }
                else
                {
                    return right;
                }
            }
        }

        /// <summary>
        /// Returns the largest of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is larger.</returns>
        public static ref DegreesMinutesAngle Max(ref DegreesMinutesAngle left, ref DegreesMinutesAngle right)
        {
            if (left.Degrees == right.Degrees)
            {
                if (left.Minutes > right.Minutes)
                {
                    return ref left;
                }
                else
                {
                    return ref right;
                }
            }
            else
            {
                if (left.Degrees > right.Degrees)
                {
                    return ref left;
                }
                else
                {
                    return ref right;
                }
            }
        }

        #endregion

        #region reduce

        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns></returns>
        public static DegreesMinutesAngle Reduce(DegreesMinutesAngle angle) =>
            new DegreesMinutesAngle(DegreesMinutesAngle.Reduce(angle.DegreesMinutes));

        /// <summary>
        /// Returns the quadrant where the terminal side of the angle is in when in the standard position.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The quadrant where the terminal side of the angle is in when in the standard position.</returns>
        public static Quadrant GetQuadrant(DegreesMinutesAngle angle) =>
            DegreesMinutesAngle.GetQuadrant(angle.DegreesMinutes);

        /// <summary>
        /// Returns the reference angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The reference angle.</returns>
        public static DegreesMinutesAngle GetReference(DegreesMinutesAngle angle) =>
            new DegreesMinutesAngle(DegreesMinutesAngle.GetReference(angle.DegreesMinutes));

        #endregion

        #region comparison 

        /// <summary>
        /// Compares two DegreesMinutesAngle values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int Compare(DegreesMinutesAngle a1, DegreesMinutesAngle a2)
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
        public static int CompareReduced(DegreesMinutesAngle a1, DegreesMinutesAngle a2) =>
            DegreesMinutesAngle.Reduce(a1.DegreesMinutes).CompareTo(DegreesMinutesAngle.Reduce(a2.DegreesMinutes));

        #endregion

        #region types of angles

        /// <summary>
        /// Indicates whether the specified angle is equal to Zero when reduced.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is zero; otherwise false.</returns>
        public static bool IsZero(DegreesMinutesAngle angle) =>
            angle.Degrees % DegreesMinutesAngle.FullAngle == 0 && angle.Minutes == 0.0;

        /// <summary>
        /// Indicates whether the specified angle is acute.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than zero and less than 90 degrees; otherwise false.</returns>
        public static bool IsAcute(DegreesMinutesAngle angle)
        {
            var reduced = DegreesMinutesAngle.Reduce(Math.Abs(angle.DegreesMinutes));
            return reduced > 0.0 && reduced < DegreesMinutesAngle.RightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is right.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 90 degrees; otherwise false.</returns>
        public static bool IsRight(DegreesMinutesAngle angle) =>
            DegreesMinutesAngle.Reduce(Math.Abs(angle.DegreesMinutes)) == DegreesMinutesAngle.RightAngle;

        /// <summary>
        /// Indicates whether the specified angle is obtuse.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 90 degrees and less than 180 degrees; otherwise false.</returns>
        public static bool IsObtuse(DegreesMinutesAngle angle)
        {
            var reduced = DegreesMinutesAngle.Reduce(Math.Abs(angle.DegreesMinutes));
            return reduced > DegreesMinutesAngle.RightAngle && reduced < DegreesMinutesAngle.StraightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is straight.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 180 degrees; otherwise false.</returns>
        public static bool IsStraight(DegreesMinutesAngle angle) =>
            DegreesMinutesAngle.Reduce(Math.Abs(angle.DegreesMinutes)) == DegreesMinutesAngle.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 degrees and less than 360 degrees; otherwise false.</returns>
        public static bool IsReflex(DegreesMinutesAngle angle) =>
            DegreesMinutesAngle.Reduce(Math.Abs(angle.DegreesMinutes)) > DegreesMinutesAngle.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is oblique.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the angle is not right or a multiple of a right angle; otherwise false.</returns>
        public static bool IsOblique(DegreesMinutesAngle angle) =>
            angle.DegreesMinutes % DegreesMinutesAngle.RightAngle != 0.0;

        #endregion

        #region negation

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static DegreesMinutesAngle Negate(DegreesMinutesAngle angle) =>
            new DegreesMinutesAngle(-angle.Degrees, angle.Minutes);

        #endregion

        #region addition

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static DegreesMinutesAngle Add(DegreesMinutesAngle left, DegreesMinutesAngle right) =>
            new DegreesMinutesAngle(left.DegreesMinutes + right.DegreesMinutes);

        #endregion

        #region subtraction

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static DegreesMinutesAngle Subtract(DegreesMinutesAngle left, DegreesMinutesAngle right) =>
            new DegreesMinutesAngle(left.DegreesMinutes - right.DegreesMinutes);

        #endregion

        #region multiplication

        /// <summary>
        /// Multiplies a angle by a scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static DegreesMinutesAngle Multiply(double left, DegreesMinutesAngle right) =>
            new DegreesMinutesAngle(left * right.DegreesMinutes);

        #endregion

        #region division

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static DegreesMinutesAngle Divide(DegreesMinutesAngle left, double right) =>
            new DegreesMinutesAngle(left.DegreesMinutes / right);

        #endregion

    }
}
