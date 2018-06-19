using System;
using System.Diagnostics;

namespace NetFabric
{
    public readonly struct AngleRadians
        : IEquatable<AngleRadians>
        , IComparable
        , IComparable<AngleRadians>
        , IFormattable
    {
        /// <summary>
        /// Represents the zero RadiansAngle value (0 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleRadians Zero = new AngleRadians(0.0);

        /// <summary>
        /// Represents the golden RadiansAngle value (~137.508 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleRadians Golden = new AngleRadians(Math.PI * (3.0 - Math.Sqrt(5.0)));

        /// <summary>
        /// Represents the smallest possible value of a RadiansAngle. This field is read-only.
        /// </summary>
        public static readonly AngleRadians MinValue = new AngleRadians(double.MinValue);

        /// <summary>
        /// Represents the largest possible value of a RadiansAngle. This field is read-only.
        /// </summary>
        public static readonly AngleRadians MaxValue = new AngleRadians(double.MaxValue);

        /// <summary>
        /// Represents the right RadiansAngle value (90 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleRadians Right = new AngleRadians(RightAngle);

        /// <summary>
        /// Represents the straight RadiansAngle value (180 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleRadians Straight = new AngleRadians(StraightAngle);

        /// <summary>
        /// Represents the full RadiansAngle value (360 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleRadians Full = new AngleRadians(FullAngle);

        /// <summary>
        /// Gets the amplitude of the angle in radians. This field is read-only.
        /// </summary>
        public readonly double Radians;

        internal AngleRadians(double radians)
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
        public static bool operator ==(AngleRadians a1, AngleRadians a2) =>
            a1.Radians == a2.Radians;

        /// <summary>
        /// Indicates whether two RadiansAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator !=(AngleRadians a1, AngleRadians a2) =>
            a1.Radians != a2.Radians;

        /// <summary>
        /// Indicates whether two RadiansAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool Equals(AngleRadians a1, AngleRadians a2) =>
            a1.Radians == a2.Radians;

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified RadiansAngle object.
        /// </summary>
        /// <param name="other">An RadiansAngle to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="AngleRadians.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public bool Equals(AngleRadians other) =>
            Radians == other.Radians;

        #endregion

        #region comparison implementation

        /// <summary>
        /// Indicates whether a specified RadiansAngle is less than another specified RadiansAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than the value of a2; otherwise, false.</returns>
        public static bool operator <(AngleRadians a1, AngleRadians a2) =>
            a1.Radians < a2.Radians;

        /// <summary>
        /// Indicates whether a specified RadiansAngle is less than or equal to another specified RadiansAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator <=(AngleRadians a1, AngleRadians a2) =>
            a1.Radians <= a2.Radians;

        /// <summary>
        /// Indicates whether a specified RadiansAngle is greater than another specified RadiansAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than the value of a2; otherwise, false.</returns>
        public static bool operator >(AngleRadians a1, AngleRadians a2) =>
            a1.Radians > a2.Radians;

        /// <summary>
        /// Indicates whether a specified RadiansAngle is greater than or equal to another specified RadiansAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator >=(AngleRadians a1, AngleRadians a2) =>
            a1.Radians >= a2.Radians;

        int IComparable<AngleRadians>.CompareTo(AngleRadians other) =>
            Radians.CompareTo(other.Radians);

        int IComparable.CompareTo(object obj)
        {
            switch (obj)
            {
                case AngleRadians angle:
                    return Radians.CompareTo(angle.Radians);
                default:
                    throw new ArgumentException($"Argument has to be an {nameof(AngleRadians)}.", nameof(obj));
            }
        }

        #endregion

        #region math operators

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleRadians operator -(AngleRadians angle) =>
            new AngleRadians(-angle.Radians);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleRadians operator +(AngleRadians left, AngleRadians right) =>
            new AngleRadians(left.Radians + right.Radians);

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleRadians operator -(AngleRadians left, AngleRadians right) =>
            new AngleRadians(left.Radians - right.Radians);

        /// <summary>
        /// Multiplies a scalar by an angle value. 
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleRadians operator *(double left, AngleRadians right) =>
            new AngleRadians(left * right.Radians);

        /// <summary>
        /// Divides a angle by a scalar value. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleRadians operator /(AngleRadians left, double right) =>
            new AngleRadians(left.Radians / right);

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
                case AngleRadians angle:
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
        /// Returns an RadiansAngle that represents a angle with the specified number of radians.
        /// </summary>
        /// <param name="radians">A number of radians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRadians FromRadians(double radians) =>
            new AngleRadians(radians);

        /// <summary>
        /// Returns the absolute value of the RadiansAngle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>
        /// An RadiansAngle, x, such that RadiansAngle.Zero &lt;= x &lt;= RadiansAngle.MaxValue.
        /// </returns>
        public static AngleRadians Abs(AngleRadians angle) =>
            new AngleRadians(Math.Abs(angle.Radians));

        /// <summary>
        /// Returns a value indicating the sign of an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>A number that indicates the sign of value, -1 if value is less than zero, 0 if value equal to zero, 1 if value is grater than zero.</returns>
        public static int Sign(AngleRadians angle) =>
            Math.Sign(angle.Radians);

        #region min

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is smaller.</returns>
        public static ref readonly AngleRadians Min(in AngleRadians left, in AngleRadians right)
        {
            if (left.Radians < right.Radians)
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
        public static ref readonly AngleRadians Max(in AngleRadians left, in AngleRadians right)
        {
            if (left.Radians > right.Radians)
                return ref left;

            return ref right;
        }

        #endregion

        #region reduce

        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns></returns>
        public static AngleRadians Reduce(AngleRadians angle) =>
            new AngleRadians(AngleRadians.Reduce(angle.Radians));

        /// <summary>
        /// Returns the quadrant where the terminal side of the angle is in when in the standard position.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The quadrant where the terminal side of the angle is in when in the standard position.</returns>
        public static Quadrant GetQuadrant(AngleRadians angle) =>
            AngleRadians.GetQuadrant(angle.Radians);

        /// <summary>
        /// Returns the reference angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The reference angle.</returns>
        public static AngleRadians GetReference(AngleRadians angle) =>
            new AngleRadians(AngleRadians.GetReference(angle.Radians));

        #endregion

        #region comparison 

        /// <summary>
        /// Compares two RadiansAngle values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int Compare(AngleRadians a1, AngleRadians a2) =>
            a1.Radians.CompareTo(a2.Radians);

        /// <summary>
        /// Compares two RadiansAngle values and returns an integer that indicates whether when both reduced the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int CompareReduced(AngleRadians a1, AngleRadians a2) =>
            AngleRadians.Reduce(a1.Radians).CompareTo(AngleRadians.Reduce(a2.Radians));

        #endregion

        #region types of angles

        /// <summary>
        /// Indicates whether the specified angle is equal to Zero when reduced.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is zero; otherwise false.</returns>
        public static bool IsZero(AngleRadians angle) =>
            angle.Radians % AngleRadians.FullAngle == 0.0;

        /// <summary>
        /// Indicates whether the specified angle is acute.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than zero and less than 90 degrees; otherwise false.</returns>
        public static bool IsAcute(AngleRadians angle)
        {
            var reduced = AngleRadians.Reduce(Math.Abs(angle.Radians));
            return reduced > 0.0 && reduced < AngleRadians.RightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is right.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 90 degrees; otherwise false.</returns>
        public static bool IsRight(AngleRadians angle) =>
            AngleRadians.Reduce(Math.Abs(angle.Radians)) == AngleRadians.RightAngle;

        /// <summary>
        /// Indicates whether the specified angle is obtuse.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 90 degrees and less than 180 degrees; otherwise false.</returns>
        public static bool IsObtuse(AngleRadians angle)
        {
            var reduced = AngleRadians.Reduce(Math.Abs(angle.Radians));
            return reduced > AngleRadians.RightAngle && reduced < AngleRadians.StraightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is straight.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 180 degrees; otherwise false.</returns>
        public static bool IsStraight(AngleRadians angle) =>
            AngleRadians.Reduce(Math.Abs(angle.Radians)) == AngleRadians.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 degrees and less than 360 degrees; otherwise false.</returns>
        public static bool IsReflex(AngleRadians angle) =>
            AngleRadians.Reduce(Math.Abs(angle.Radians)) > AngleRadians.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is oblique.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the angle is not right or a multiple of a right angle; otherwise false.</returns>
        public static bool IsOblique(AngleRadians angle) =>
            angle.Radians % AngleRadians.RightAngle != 0.0;

        #endregion

        #region lerp

        /// <summary>
        /// Performs a linear interpolation.
        /// </summary>
        /// <param name="a1">The first angle.</param>
        /// <param name="a2">The second angle.</param>
        /// <param name="t">A value that linearly interpolates between the a1 parameter and the a2 parameter.</param>
        /// <returns>The result of the linear interpolation.</returns>
        public static AngleRadians Lerp(AngleRadians a1, AngleRadians a2, double t) =>
            new AngleRadians(Utils.Lerp(a1.Radians, a2.Radians, t));

        #endregion

        #region trigonometric functions

        /// <summary>
        /// Return the sine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The sine of the specified angle. If angle is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</returns>
        public static double Sin(AngleRadians angle) =>
            Math.Sin(angle.Radians);

        /// <summary>
        /// Return the sine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <param name="result">The sine of the specified angle. If angle is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</param>
        public static void Sin(ref AngleRadians angle, out double result)
        {
            result = Math.Sin(angle.Radians);
        }

        /// <summary>
        /// Returns the hyperbolic sine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The hyperbolic sine of value. If value is equal to NegativeInfinity, PositiveInfinity, or NaN, this method returns an RadiansAngle equal to value.</returns>
        public static double Sinh(AngleRadians angle) =>
             Math.Sinh(angle.Radians);

        /// <summary>
        /// Returns the hyperbolic sine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <param name="result">The hyperbolic sine of value. If value is equal to NegativeInfinity, PositiveInfinity, or NaN, this method returns an RadiansAngle equal to value.</param>
        public static void Sinh(ref AngleRadians angle, out double result)
        {
            result = Math.Sinh(angle.Radians);
        }

        /// <summary>
        /// Returns the angle whose sine is the specified number.
        /// </summary>
        /// <param name="value">A number representing a sine, where value must be greater than or equal to -1, but less than or equal to 1.</param>
        /// <returns>The angle whose sine is the specified number.</returns>
        public static AngleRadians Asin(double value)
        {
            if (value < -1.0 || value > 1.0)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Argument must be greater or equal to -1.0 and less or equal to 1.0.");

            return new AngleRadians(Math.Asin(value));
        }

        /// <summary>
        /// Return the cosine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The cosine of the specified angle. If angle is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</returns>
        public static double Cos(AngleRadians angle) =>
            Math.Cos(angle.Radians);

        /// <summary>
        /// Returns the hyperbolic cosine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The hyperbolic cosine of value. If value is equal to NegativeInfinity, PositiveInfinity, or NaN, this method returns an RadiansAngle equal to value.</returns>
        public static double Cosh(AngleRadians angle) =>
            Math.Cosh(angle.Radians);

        /// <summary>
        /// Returns the angle whose cosine is the specified number.
        /// </summary>
        /// <param name="value">A number representing a cosine, where value must be greater than or equal to -1, but less than or equal to 1.</param>
        /// <returns>The angle whose cosine is the specified number.</returns>
        public static AngleRadians Acos(double value)
        {
            if (value < -1.0 || value > 1.0)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Argument must be greater or equal to -1.0 and less or equal to 1.0.");

            return new AngleRadians(Math.Acos(value));
        }

        /// <summary>
        /// Returns the tangent of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The tangent of the specified angle. If angle is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</returns>
        public static double Tan(AngleRadians angle) =>
            Math.Tan(angle.Radians);

        /// <summary>
        /// Returns the angle whose tangent is the specified number.
        /// </summary>
        /// <param name="value">A number representing a tangent.</param>
        /// <returns>The angle whose tangent is the specified number.</returns>
        public static AngleRadians Atan(double value) =>
            new AngleRadians(Math.Atan(value));

        /// <summary>
        /// Returns the angle whose tangent is the quotient of two specified numbers.
        /// </summary>
        /// <param name="x">The y coordinate of a point.</param>
        /// <param name="y">The x coordinate of a point.</param>
        /// <returns>The angle whose tangent is the quotient of two specified numbers.</returns>
        public static AngleRadians Atan2(double y, double x) =>
            new AngleRadians(Math.Atan2(y, x));

        #endregion

        #region negation

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleRadians Negate(AngleRadians angle) =>
            new AngleRadians(-angle.Radians);

        #endregion

        #region addition

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleRadians Add(AngleRadians left, AngleRadians right) =>
            new AngleRadians(left.Radians + right.Radians);

        #endregion

        #region subtraction

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleRadians Subtract(AngleRadians left, AngleRadians right) =>
            new AngleRadians(left.Radians - right.Radians);

        #endregion

        #region multiplication

        /// <summary>
        /// Multiplies a angle by a scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleRadians Multiply(double left, AngleRadians right) =>
            new AngleRadians(left * right.Radians);

        #endregion

        #region division

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleRadians Divide(AngleRadians left, double right) =>
            new AngleRadians(left.Radians / right);

        #endregion

    }
}
