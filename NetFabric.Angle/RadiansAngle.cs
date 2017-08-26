using System;
using System.Diagnostics;

namespace NetFabric
{
    public struct RadiansAngle
        : IEquatable<RadiansAngle>
        , IComparable
        , IComparable<RadiansAngle>
        , IFormattable
    {
        /// <summary>
        /// Represents the zero RadiansAngle value (0 degrees). This field is read-only.
        /// </summary>
        public static readonly RadiansAngle Zero = new RadiansAngle(0.0);

        /// <summary>
        /// Represents the golden RadiansAngle value (~137.508 degrees). This field is read-only.
        /// </summary>
        public static readonly RadiansAngle Golden = new RadiansAngle(Math.PI * (3.0 - Math.Sqrt(5.0)));

        /// <summary>
        /// Represents the smallest possible value of a RadiansAngle. This field is read-only.
        /// </summary>
        public static readonly RadiansAngle MinValue = new RadiansAngle(double.MinValue);

        /// <summary>
        /// Represents the largest possible value of a RadiansAngle. This field is read-only.
        /// </summary>
        public static readonly RadiansAngle MaxValue = new RadiansAngle(double.MaxValue);

        /// <summary>
        /// Represents the right RadiansAngle value (90 degrees). This field is read-only.
        /// </summary>
        public static readonly RadiansAngle Right = new RadiansAngle(RightAngle);

        /// <summary>
        /// Represents the straight RadiansAngle value (180 degrees). This field is read-only.
        /// </summary>
        public static readonly RadiansAngle Straight = new RadiansAngle(StraightAngle);

        /// <summary>
        /// Represents the full RadiansAngle value (360 degrees). This field is read-only.
        /// </summary>
        public static readonly RadiansAngle Full = new RadiansAngle(FullAngle);

        /// <summary>
        /// Gets the amplitude of the angle in radians. This field is read-only.
        /// </summary>
        public readonly double Radians;

        internal RadiansAngle(double radians)
        {
            Radians = radians;
        }

        #region equality implementation

        /// <summary>
        /// Indicates whether two RadiansAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator ==(RadiansAngle a1, RadiansAngle a2) =>
            a1.Radians == a2.Radians;

        /// <summary>
        /// Indicates whether two RadiansAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator !=(RadiansAngle a1, RadiansAngle a2) =>
            a1.Radians != a2.Radians;

        /// <summary>
        /// Indicates whether two RadiansAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool Equals(RadiansAngle a1, RadiansAngle a2) =>
            a1.Radians == a2.Radians;

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified RadiansAngle object.
        /// </summary>
        /// <param name="obj">An RadiansAngle to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="RadiansAngle.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public bool Equals(RadiansAngle obj) =>
            Radians == obj.Radians;

        #endregion

        #region comparison implementation

        /// <summary>
        /// Indicates whether a specified RadiansAngle is less than another specified RadiansAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than the value of a2; otherwise, false.</returns>
        public static bool operator <(RadiansAngle a1, RadiansAngle a2) =>
            a1.Radians < a2.Radians;

        /// <summary>
        /// Indicates whether a specified RadiansAngle is less than or equal to another specified RadiansAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator <=(RadiansAngle a1, RadiansAngle a2) =>
            a1.Radians <= a2.Radians;

        /// <summary>
        /// Indicates whether a specified RadiansAngle is greater than another specified RadiansAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than the value of a2; otherwise, false.</returns>
        public static bool operator >(RadiansAngle a1, RadiansAngle a2) =>
            a1.Radians > a2.Radians;

        /// <summary>
        /// Indicates whether a specified RadiansAngle is greater than or equal to another specified RadiansAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator >=(RadiansAngle a1, RadiansAngle a2) =>
            a1.Radians >= a2.Radians;

        int IComparable<RadiansAngle>.CompareTo(RadiansAngle value) =>
            Radians.CompareTo(value.Radians);

        int IComparable.CompareTo(object obj)
        {
            switch (obj)
            {
                case RadiansAngle angle:
                    return Radians.CompareTo(angle.Radians);
                default:
                    throw new ArgumentException("Argument has to be an RadiansAngle.", nameof(obj));
            }
        }

        #endregion

        #region math operators

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static RadiansAngle operator -(RadiansAngle angle) =>
            new RadiansAngle(-angle.Radians);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static RadiansAngle operator +(RadiansAngle left, RadiansAngle right) =>
            new RadiansAngle(left.Radians + right.Radians);

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static RadiansAngle operator -(RadiansAngle left, RadiansAngle right) =>
            new RadiansAngle(left.Radians - right.Radians);

        /// <summary>
        /// Multiplies a scalar by an angle value. 
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static RadiansAngle operator *(double left, RadiansAngle right) =>
            new RadiansAngle(left * right.Radians);

        /// <summary>
        /// Divides a angle by a scalar value. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static RadiansAngle operator /(RadiansAngle left, double right) =>
            new RadiansAngle(left.Radians / right);

        #endregion        
        
        #region string format

        /// <summary>
        /// Converts the value of the current RadiansAngle object to its equivalent string representation, using a specified format.
        /// </summary>
        /// <param name="format">A string that specifies the format to be used for the returned string.</param>
        /// <returns>A string representation of the value of the current RadiansAngle object, in the specified format.</returns>
        public string ToString(string format) =>
            Radians.ToString(format);

        /// <summary>
        /// Converts the value of the current RadiansAngle object to its equivalent string representation using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current RadiansAngle object as specified by format and provider.</returns>
        public string ToString(string format, IFormatProvider formatProvider) =>
            Radians.ToString(format, formatProvider);

        #endregion

        #region object overrides

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>true if value is a RadiansAngle object that represents the same angle as the current RadiansAngle structure; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case RadiansAngle angle:
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
            Radians.GetHashCode();

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() =>
            Radians.ToString();

        #endregion

        internal const double RightAngle = Math.PI * 0.5;
        internal const double StraightAngle = Math.PI;
        internal const double FullAngle = Math.PI * 2.0;

        internal static double Reduce(double radians) =>
            Utils.Reduce(radians, FullAngle);

        internal static Quadrant GetQuadrant(double radians) =>
            Utils.GetQuadrant(radians, RightAngle, StraightAngle, FullAngle);

        internal static double GetReference(double radians) =>
            Utils.GetReference(radians, RightAngle, StraightAngle, FullAngle);

    }

    public static partial class Angle
    {
        /// <summary>
        /// Returns the absolute value of the RadiansAngle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>
        /// An RadiansAngle, x, such that RadiansAngle.Zero &lt;= x &lt;= RadiansAngle.MaxValue.
        /// </returns>
        public static RadiansAngle Abs(RadiansAngle angle) =>
            new RadiansAngle(Math.Abs(angle.Radians));

        /// <summary>
        /// Returns a value indicating the sign of an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>A number that indicates the sign of value, -1 if value is less than zero, 0 if value equal to zero, 1 if value is grater than zero.</returns>
        public static int Sign(RadiansAngle angle) =>
            Math.Sign(angle.Radians);

        #region min

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>Parameter left or right, whichever is smaller.</returns>
        public static RadiansAngle Min(RadiansAngle left, RadiansAngle right) =>
            left.Radians < right.Radians ? left : right;

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is smaller.</returns>
        public static ref RadiansAngle Min(ref RadiansAngle left, ref RadiansAngle right)
        {
            if (left.Radians < right.Radians)
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
        public static RadiansAngle Max(RadiansAngle left, RadiansAngle right) =>
            left.Radians > right.Radians ? left : right;

        /// <summary>
        /// Returns the largest of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is larger.</returns>
        public static ref RadiansAngle Max(ref RadiansAngle left, ref RadiansAngle right)
        {
            if (left.Radians > right.Radians)
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
        public static RadiansAngle Reduce(RadiansAngle angle) =>
            new RadiansAngle(RadiansAngle.Reduce(angle.Radians));

        /// <summary>
        /// Returns the quadrant where the terminal side of the angle is in when in the standard position.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The quadrant where the terminal side of the angle is in when in the standard position.</returns>
        public static Quadrant GetQuadrant(RadiansAngle angle) =>
            RadiansAngle.GetQuadrant(angle.Radians);

        /// <summary>
        /// Returns the reference angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The reference angle.</returns>
        public static RadiansAngle GetReference(RadiansAngle angle) =>
            new RadiansAngle(RadiansAngle.GetReference(angle.Radians));

        #endregion

        #region comparison 

        /// <summary>
        /// Compares two RadiansAngle values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int Compare(RadiansAngle a1, RadiansAngle a2) =>
            a1.Radians.CompareTo(a2.Radians);

        /// <summary>
        /// Compares two RadiansAngle values and returns an integer that indicates whether when both reduced the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int CompareReduced(RadiansAngle a1, RadiansAngle a2) =>
            RadiansAngle.Reduce(a1.Radians).CompareTo(RadiansAngle.Reduce(a2.Radians));

        #endregion

        #region types of angles

        /// <summary>
        /// Indicates whether the specified angle is acute.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than zero and less than 90 degrees; otherwise false.</returns>
        public static bool IsAcute(RadiansAngle angle)
        {
            var reduced = RadiansAngle.Reduce(Math.Abs(angle.Radians));
            return reduced < RadiansAngle.RightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is right.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 90 degrees; otherwise false.</returns>
        public static bool IsRight(RadiansAngle angle) =>
            RadiansAngle.Reduce(Math.Abs(angle.Radians)) == RadiansAngle.FullAngle;

        /// <summary>
        /// Indicates whether the specified angle is obtuse.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 90 degrees and less than 180 degrees; otherwise false.</returns>
        public static bool IsObtuse(RadiansAngle angle)
        {
            var reduced = RadiansAngle.Reduce(Math.Abs(angle.Radians));
            return reduced > RadiansAngle.RightAngle && reduced < RadiansAngle.StraightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is straight.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 180 degrees; otherwise false.</returns>
        public static bool IsStraight(RadiansAngle angle) =>
            RadiansAngle.Reduce(Math.Abs(angle.Radians)) == RadiansAngle.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 degrees and less than 360 degrees; otherwise false.</returns>
        public static bool IsReflex(RadiansAngle angle) =>
            RadiansAngle.Reduce(Math.Abs(angle.Radians)) > RadiansAngle.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is oblique.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the angle is not right or a multiple of a right angle; otherwise false.</returns>
        public static bool IsOblique(RadiansAngle angle) =>
            angle.Radians % RadiansAngle.RightAngle != 0.0;

        #endregion

        #region lerp

        /// <summary>
        /// Performs a linear interpolation.
        /// </summary>
        /// <param name="a1">The first angle.</param>
        /// <param name="a2">The second angle.</param>
        /// <param name="t">A value that linearly interpolates between the a1 parameter and the a2 parameter.</param>
        /// <returns>The result of the linear interpolation.</returns>
        public static RadiansAngle Lerp(RadiansAngle a1, RadiansAngle a2, double t) =>
            new RadiansAngle(Utils.Lerp(a1.Radians, a2.Radians, t));

        #endregion

        #region trigonometric functions

        /// <summary>
        /// Return the sine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The sine of the specified angle. If angle is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</returns>
        public static double Sin(RadiansAngle angle) =>
            Math.Sin(angle.Radians);

        /// <summary>
        /// Return the sine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <param name="result">The sine of the specified angle. If angle is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</param>
        public static void Sin(ref RadiansAngle angle, out double result)
        {
            result = Math.Sin(angle.Radians);
        }

        /// <summary>
        /// Returns the hyperbolic sine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The hyperbolic sine of value. If value is equal to NegativeInfinity, PositiveInfinity, or NaN, this method returns an RadiansAngle equal to value.</returns>
        public static double Sinh(RadiansAngle angle) =>
             Math.Sinh(angle.Radians);

        /// <summary>
        /// Returns the hyperbolic sine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <param name="result">The hyperbolic sine of value. If value is equal to NegativeInfinity, PositiveInfinity, or NaN, this method returns an RadiansAngle equal to value.</param>
        public static void Sinh(ref RadiansAngle angle, out double result)
        {
            result = Math.Sinh(angle.Radians);
        }

        /// <summary>
        /// Returns the angle whose sine is the specified number.
        /// </summary>
        /// <param name="value">A number representing a sine, where value must be greater than or equal to -1, but less than or equal to 1.</param>
        /// <returns>The angle whose sine is the specified number.</returns>
        public static RadiansAngle Asin(double value)
        {
            if (value < -1.0 || value > 1.0)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Argument must be greater or equal to -1.0 and less or equal to 1.0.");

            return new RadiansAngle(Math.Asin(value));
        }

        /// <summary>
        /// Return the cosine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The cosine of the specified angle. If angle is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</returns>
        public static double Cos(RadiansAngle angle) =>
            Math.Cos(angle.Radians);

        /// <summary>
        /// Returns the hyperbolic cosine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The hyperbolic cosine of value. If value is equal to NegativeInfinity, PositiveInfinity, or NaN, this method returns an RadiansAngle equal to value.</returns>
        public static double Cosh(RadiansAngle angle) =>
            Math.Cosh(angle.Radians);

        /// <summary>
        /// Returns the angle whose cosine is the specified number.
        /// </summary>
        /// <param name="value">A number representing a cosine, where value must be greater than or equal to -1, but less than or equal to 1.</param>
        /// <returns>The angle whose cosine is the specified number.</returns>
        public static RadiansAngle Acos(double value)
        {
            if (value < -1.0 || value > 1.0)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Argument must be greater or equal to -1.0 and less or equal to 1.0.");

            return new RadiansAngle(Math.Acos(value));
        }

        /// <summary>
        /// Returns the tangent of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The tangent of the specified angle. If angle is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</returns>
        public static double Tan(RadiansAngle angle) =>
            Math.Tan(angle.Radians);

        /// <summary>
        /// Returns the angle whose tangent is the specified number.
        /// </summary>
        /// <param name="value">A number representing a tangent.</param>
        /// <returns>The angle whose tangent is the specified number.</returns>
        public static RadiansAngle Atan(double value) =>
            new RadiansAngle(Math.Atan(value));

        /// <summary>
        /// Returns the angle whose tangent is the quotient of two specified numbers.
        /// </summary>
        /// <param name="x">The y coordinate of a point.</param>
        /// <param name="y">The x coordinate of a point.</param>
        /// <returns>The angle whose tangent is the quotient of two specified numbers.</returns>
        public static RadiansAngle Atan2(double y, double x) =>
            new RadiansAngle(Math.Atan2(y, x));

        #endregion

        #region negation

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static RadiansAngle Negate(RadiansAngle angle) =>
            new RadiansAngle(-angle.Radians);

        #endregion

        #region addition

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static RadiansAngle Add(RadiansAngle left, RadiansAngle right) =>
            new RadiansAngle(left.Radians + right.Radians);

        #endregion

        #region subtraction

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static RadiansAngle Subtract(RadiansAngle left, RadiansAngle right) =>
            new RadiansAngle(left.Radians - right.Radians);

        #endregion

        #region multiplication

        /// <summary>
        /// Multiplies a angle by a scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static RadiansAngle Multiply(double left, RadiansAngle right) =>
            new RadiansAngle(left * right.Radians);

        #endregion

        #region division

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static RadiansAngle Divide(RadiansAngle left, double right) =>
            new RadiansAngle(left.Radians / right);

        #endregion

    }
}
