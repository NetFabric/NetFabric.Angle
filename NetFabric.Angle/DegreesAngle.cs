using System;

namespace NetFabric
{
    public struct DegreesAngle
        : IEquatable<DegreesAngle>
        , IComparable
        , IComparable<DegreesAngle>
        , IFormattable
    {
        /// <summary>
        /// Represents the zero DegreesAngle value (0 degrees). This field is read-only.
        /// </summary>
        public static readonly DegreesAngle Zero = new DegreesAngle(0.0);

        /// <summary>
        /// Represents the golden DegreesAngle value (~137.508 degrees). This field is read-only.
        /// </summary>
        public static readonly DegreesAngle Golden = Angle.InDegrees(RadiansAngle.Golden);

        /// <summary>
        /// Represents the smallest possible value of a DegreesAngle. This field is read-only.
        /// </summary>
        public static readonly DegreesAngle MinValue = new DegreesAngle(double.MinValue);

        /// <summary>
        /// Represents the largest possible value of a DegreesAngle. This field is read-only.
        /// </summary>
        public static readonly DegreesAngle MaxValue = new DegreesAngle(double.MaxValue);

        /// <summary>
        /// Represents the right DegreesAngle value (90 degrees). This field is read-only.
        /// </summary>
        public static readonly DegreesAngle Right = new DegreesAngle(RightAngle);

        /// <summary>
        /// Represents the straight DegreesAngle value (180 degrees). This field is read-only.
        /// </summary>
        public static readonly DegreesAngle Straight = new DegreesAngle(StraightAngle);

        /// <summary>
        /// Represents the full DegreesAngle value (360 degrees). This field is read-only.
        /// </summary>
        public static readonly DegreesAngle Full = new DegreesAngle(FullAngle);

        /// <summary>
        /// Gets the amplitude of the angle in degrees. This field is read-only.
        /// </summary>
        public readonly double Degrees;

        internal DegreesAngle(double degrees)
        {
            Degrees = degrees;
        }

        #region equality implementation

        /// <summary>
        /// Indicates whether two DegreesAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator ==(DegreesAngle a1, DegreesAngle a2) =>
            a1.Degrees == a2.Degrees;

        /// <summary>
        /// Indicates whether two DegreesAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator !=(DegreesAngle a1, DegreesAngle a2) =>
            a1.Degrees != a2.Degrees;

        /// <summary>
        /// Indicates whether two DegreesAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool Equals(DegreesAngle a1, DegreesAngle a2) =>
            a1.Degrees == a2.Degrees;

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified DegreesAngle object.
        /// </summary>
        /// <param name="obj">An DegreesAngle to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="DegreesAngle.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public bool Equals(DegreesAngle obj) =>
            Degrees == obj.Degrees;

        #endregion

        #region comparison implementation

        /// <summary>
        /// Indicates whether a specified DegreesAngle is less than another specified DegreesAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than the value of a2; otherwise, false.</returns>
        public static bool operator <(DegreesAngle a1, DegreesAngle a2) =>
            a1.Degrees < a2.Degrees;

        /// <summary>
        /// Indicates whether a specified DegreesAngle is less than or equal to another specified DegreesAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator <=(DegreesAngle a1, DegreesAngle a2) =>
            a1.Degrees <= a2.Degrees;

        /// <summary>
        /// Indicates whether a specified DegreesAngle is greater than another specified DegreesAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than the value of a2; otherwise, false.</returns>
        public static bool operator >(DegreesAngle a1, DegreesAngle a2) =>
            a1.Degrees > a2.Degrees;

        /// <summary>
        /// Indicates whether a specified DegreesAngle is greater than or equal to another specified DegreesAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator >=(DegreesAngle a1, DegreesAngle a2) =>
            a1.Degrees >= a2.Degrees;

        int IComparable<DegreesAngle>.CompareTo(DegreesAngle value) =>
            Degrees.CompareTo(value.Degrees);

        int IComparable.CompareTo(object obj)
        {
            switch (obj)
            {
                case DegreesAngle angle:
                    return Degrees.CompareTo(angle.Degrees);
                default:
                    throw new ArgumentException("Argument has to be an DegreesAngle.", nameof(obj));
            }
        }

        #endregion

        #region math operators

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static DegreesAngle operator -(DegreesAngle angle) =>
            new DegreesAngle(-angle.Degrees);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static DegreesAngle operator +(DegreesAngle left, DegreesAngle right) =>
            new DegreesAngle(left.Degrees + right.Degrees);

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static DegreesAngle operator -(DegreesAngle left, DegreesAngle right) =>
            new DegreesAngle(left.Degrees - right.Degrees);

        /// <summary>
        /// Multiplies a scalar by an angle value. 
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static DegreesAngle operator *(double left, DegreesAngle right) =>
            new DegreesAngle(left * right.Degrees);

        /// <summary>
        /// Divides a angle by a scalar value. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static DegreesAngle operator /(DegreesAngle left, double right) =>
            new DegreesAngle(left.Degrees / right);

        #endregion

        #region string format

        /// <summary>
        /// Converts the value of the current DegreesAngle object to its equivalent string representation, using a specified format.
        /// </summary>
        /// <param name="format">A string that specifies the format to be used for the returned string.</param>
        /// <returns>A string representation of the value of the current DegreesAngle object, in the specified format.</returns>
        public string ToString(string format) =>
            Degrees.ToString(format);

        /// <summary>
        /// Converts the value of the current DegreesAngle object to its equivalent string representation using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current DegreesAngle object as specified by format and provider.</returns>
        public string ToString(string format, IFormatProvider formatProvider) =>
            Degrees.ToString(format, formatProvider);

        #endregion

        #region object overrides

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>true if value is a DegreesAngle object that represents the same angle as the current DegreesAngle structure; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case DegreesAngle angle:
                    return Equals(angle);
                default:
                    return false;
            }
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
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

    }

    public static partial class Angle
    {
        /// <summary>
        /// Returns the absolute value of the DegreesAngle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>
        /// An DegreesAngle, x, such that DegreesAngle.Zero &lt;= x &lt;= DegreesAngle.MaxValue.
        /// </returns>
        public static DegreesAngle Abs(DegreesAngle angle) =>
            new DegreesAngle(Math.Abs(angle.Degrees));

        /// <summary>
        /// Returns a value indicating the sign of an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>A number that indicates the sign of value, -1 if value is less than zero, 0 if value equal to zero, 1 if value is grater than zero.</returns>
        public static int Sign(DegreesAngle angle) =>
            Math.Sign(angle.Degrees);

        #region min

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>Parameter left or right, whichever is smaller.</returns>
        public static DegreesAngle Min(DegreesAngle left, DegreesAngle right) =>
            left.Degrees < right.Degrees ? left : right;

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is smaller.</returns>
        public static ref DegreesAngle Min(ref DegreesAngle left, ref DegreesAngle right)
        {
            if (left.Degrees < right.Degrees)
                return ref left;
            else
                return ref right;
        }

        #endregion

        #region max

        /// <summary>
        /// Returns the largest of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>Parameter left or right, whichever is larger.</returns>
        public static DegreesAngle Max(DegreesAngle left, DegreesAngle right) =>
            left.Degrees > right.Degrees ? left : right;

        /// <summary>
        /// Returns the largest of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is larger.</returns>
        public static ref DegreesAngle Max(ref DegreesAngle left, ref DegreesAngle right)
        {
            if (left.Degrees > right.Degrees)
                return ref left;
            else
                return ref right;
        }

        #endregion

        #region reduce

        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns></returns>
        public static DegreesAngle Reduce(DegreesAngle angle) =>
            new DegreesAngle(DegreesAngle.Reduce(angle.Degrees));

        /// <summary>
        /// Returns the quadrant where the terminal side of the angle is in when in the standard position.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The quadrant where the terminal side of the angle is in when in the standard position.</returns>
        public static Quadrant GetQuadrant(DegreesAngle angle) =>
            DegreesAngle.GetQuadrant(angle.Degrees);

        /// <summary>
        /// Returns the reference angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The reference angle.</returns>
        public static DegreesAngle GetReference(DegreesAngle angle) =>
            new DegreesAngle(DegreesAngle.GetReference(angle.Degrees));

        #endregion

        #region comparison 

        /// <summary>
        /// Compares two DegreesAngle values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int Compare(DegreesAngle a1, DegreesAngle a2) =>
            a1.Degrees.CompareTo(a2.Degrees);

        /// <summary>
        /// Compares two DegreesAngle values and returns an integer that indicates whether when both reduced the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int CompareReduced(DegreesAngle a1, DegreesAngle a2) =>
            DegreesAngle.Reduce(a1.Degrees).CompareTo(DegreesAngle.Reduce(a2.Degrees));

        #endregion

        #region types of angles

        /// <summary>
        /// Indicates whether the specified angle is acute.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than zero and less than 90 degrees; otherwise false.</returns>
        public static bool IsAcute(DegreesAngle angle)
        {
            var reduced = DegreesAngle.Reduce(Math.Abs(angle.Degrees));
            return reduced < DegreesAngle.RightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is right.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 90 degrees; otherwise false.</returns>
        public static bool IsRight(DegreesAngle angle) =>
            DegreesAngle.Reduce(Math.Abs(angle.Degrees)) == DegreesAngle.FullAngle;

        /// <summary>
        /// Indicates whether the specified angle is obtuse.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 90 degrees and less than 180 degrees; otherwise false.</returns>
        public static bool IsObtuse(DegreesAngle angle)
        {
            var reduced = DegreesAngle.Reduce(Math.Abs(angle.Degrees));
            return reduced > DegreesAngle.RightAngle && reduced < DegreesAngle.StraightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is straight.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 180 degrees; otherwise false.</returns>
        public static bool IsStraight(DegreesAngle angle) =>
            DegreesAngle.Reduce(Math.Abs(angle.Degrees)) == DegreesAngle.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 degrees and less than 360 degrees; otherwise false.</returns>
        public static bool IsReflex(DegreesAngle angle) =>
            DegreesAngle.Reduce(Math.Abs(angle.Degrees)) > DegreesAngle.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is oblique.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the angle is not right or a multiple of a right angle; otherwise false.</returns>
        public static bool IsOblique(DegreesAngle angle) =>
            angle.Degrees % DegreesAngle.RightAngle != 0.0;

        #endregion

        #region lerp

        /// <summary>
        /// Performs a linear interpolation.
        /// </summary>
        /// <param name="a1">The first angle.</param>
        /// <param name="a2">The second angle.</param>
        /// <param name="t">A value that linearly interpolates between the a1 parameter and the a2 parameter.</param>
        /// <returns>The result of the linear interpolation.</returns>
        public static DegreesAngle Lerp(DegreesAngle a1, DegreesAngle a2, double t) =>
            new DegreesAngle(Utils.Lerp(a1.Degrees, a2.Degrees, t));

        #endregion

        #region negation

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static DegreesAngle Negate(DegreesAngle angle) =>
            new DegreesAngle(-angle.Degrees);

        #endregion

        #region addition

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static DegreesAngle Add(DegreesAngle left, DegreesAngle right) =>
            new DegreesAngle(left.Degrees + right.Degrees);

        #endregion

        #region subtraction

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static DegreesAngle Subtract(DegreesAngle left, DegreesAngle right) =>
            new DegreesAngle(left.Degrees - right.Degrees);

        #endregion

        #region multiplication

        /// <summary>
        /// Multiplies a angle by a scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static DegreesAngle Multiply(double left, DegreesAngle right) =>
            new DegreesAngle(left * right.Degrees);

        #endregion

        #region division

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static DegreesAngle Divide(DegreesAngle left, double right) =>
            new DegreesAngle(left.Degrees / right);

        #endregion

    }
}
