using System;

namespace NetFabric
{
    public readonly struct AngleDegrees
        : IEquatable<AngleDegrees>
        , IComparable
        , IComparable<AngleDegrees>
        , IFormattable
    {
        /// <summary>
        /// Represents the zero DegreesAngle value (0 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegrees Zero = new AngleDegrees(0.0);

        /// <summary>
        /// Represents the smallest possible value of a DegreesAngle. This field is read-only.
        /// </summary>
        public static readonly AngleDegrees MinValue = new AngleDegrees(double.MinValue);

        /// <summary>
        /// Represents the largest possible value of a DegreesAngle. This field is read-only.
        /// </summary>
        public static readonly AngleDegrees MaxValue = new AngleDegrees(double.MaxValue);

        /// <summary>
        /// Represents the right DegreesAngle value (90 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegrees Right = new AngleDegrees(RightAngle);

        /// <summary>
        /// Represents the straight DegreesAngle value (180 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegrees Straight = new AngleDegrees(StraightAngle);

        /// <summary>
        /// Represents the full DegreesAngle value (360 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleDegrees Full = new AngleDegrees(FullAngle);

        /// <summary>
        /// Gets the amplitude of the angle in degrees. This field is read-only.
        /// </summary>
        public readonly double Degrees;

        internal AngleDegrees(double degrees)
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
        public static bool operator ==(AngleDegrees a1, AngleDegrees a2) =>
            a1.Degrees == a2.Degrees;

        /// <summary>
        /// Indicates whether two DegreesAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator !=(AngleDegrees a1, AngleDegrees a2) =>
            a1.Degrees != a2.Degrees;

        /// <summary>
        /// Indicates whether two DegreesAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool Equals(AngleDegrees a1, AngleDegrees a2) =>
            a1.Degrees == a2.Degrees;

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified DegreesAngle object.
        /// </summary>
        /// <param name="other">An DegreesAngle to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="AngleDegrees.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public bool Equals(AngleDegrees other) =>
            Degrees == other.Degrees;

        #endregion

        #region comparison implementation

        /// <summary>
        /// Indicates whether a specified DegreesAngle is less than another specified DegreesAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than the value of a2; otherwise, false.</returns>
        public static bool operator <(AngleDegrees a1, AngleDegrees a2) =>
            a1.Degrees < a2.Degrees;

        /// <summary>
        /// Indicates whether a specified DegreesAngle is less than or equal to another specified DegreesAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator <=(AngleDegrees a1, AngleDegrees a2) =>
            a1.Degrees <= a2.Degrees;

        /// <summary>
        /// Indicates whether a specified DegreesAngle is greater than another specified DegreesAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than the value of a2; otherwise, false.</returns>
        public static bool operator >(AngleDegrees a1, AngleDegrees a2) =>
            a1.Degrees > a2.Degrees;

        /// <summary>
        /// Indicates whether a specified DegreesAngle is greater than or equal to another specified DegreesAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator >=(AngleDegrees a1, AngleDegrees a2) =>
            a1.Degrees >= a2.Degrees;

        int IComparable<AngleDegrees>.CompareTo(AngleDegrees other) =>
            Degrees.CompareTo(other.Degrees);

        int IComparable.CompareTo(object obj)
        {
            switch (obj)
            {
                case AngleDegrees angle:
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
        public static AngleDegrees operator -(AngleDegrees angle) =>
            new AngleDegrees(-angle.Degrees);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleDegrees operator +(AngleDegrees left, AngleDegrees right) =>
            new AngleDegrees(left.Degrees + right.Degrees);

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleDegrees operator -(AngleDegrees left, AngleDegrees right) =>
            new AngleDegrees(left.Degrees - right.Degrees);

        /// <summary>
        /// Multiplies a scalar by an angle value. 
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleDegrees operator *(double left, AngleDegrees right) =>
            new AngleDegrees(left * right.Degrees);

        /// <summary>
        /// Divides a angle by a scalar value. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleDegrees operator /(AngleDegrees left, double right) =>
            new AngleDegrees(left.Degrees / right);

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
                case AngleDegrees angle:
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
        /// Returns an DegreessAngle that represents a specified number of degrees.
        /// </summary>
        /// <param name="value">A number of degrees.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegrees FromDegrees(double value) =>
            new AngleDegrees(value);

        /// <summary>
        /// Returns the absolute value of the DegreesAngle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>
        /// An DegreesAngle, x, such that DegreesAngle.Zero &lt;= x &lt;= DegreesAngle.MaxValue.
        /// </returns>
        public static AngleDegrees Abs(AngleDegrees angle) =>
            new AngleDegrees(Math.Abs(angle.Degrees));

        /// <summary>
        /// Returns a value indicating the sign of an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>A number that indicates the sign of value, -1 if value is less than zero, 0 if value equal to zero, 1 if value is grater than zero.</returns>
        public static int Sign(AngleDegrees angle) =>
            Math.Sign(angle.Degrees);

        #region min

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is smaller.</returns>
        public static ref readonly AngleDegrees Min(in AngleDegrees left, in AngleDegrees right)
        {
            if (left.Degrees < right.Degrees)
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
        public static ref readonly AngleDegrees Max(in AngleDegrees left, in AngleDegrees right)
        {
            if (left.Degrees > right.Degrees)
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
        public static AngleDegrees Reduce(AngleDegrees angle) =>
            new AngleDegrees(AngleDegrees.Reduce(angle.Degrees));

        /// <summary>
        /// Returns the quadrant where the terminal side of the angle is in when in the standard position.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The quadrant where the terminal side of the angle is in when in the standard position.</returns>
        public static Quadrant GetQuadrant(AngleDegrees angle) =>
            AngleDegrees.GetQuadrant(angle.Degrees);

        /// <summary>
        /// Returns the reference angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The reference angle.</returns>
        public static AngleDegrees GetReference(AngleDegrees angle) =>
            new AngleDegrees(AngleDegrees.GetReference(angle.Degrees));

        #endregion

        #region comparison 

        /// <summary>
        /// Compares two DegreesAngle values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int Compare(AngleDegrees a1, AngleDegrees a2) =>
            a1.Degrees.CompareTo(a2.Degrees);

        /// <summary>
        /// Compares two DegreesAngle values and returns an integer that indicates whether when both reduced the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int CompareReduced(AngleDegrees a1, AngleDegrees a2) =>
            AngleDegrees.Reduce(a1.Degrees).CompareTo(AngleDegrees.Reduce(a2.Degrees));

        #endregion

        #region types of angles

        /// <summary>
        /// Indicates whether the specified angle is equal to Zero when reduced.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is zero; otherwise false.</returns>
        public static bool IsZero(AngleDegrees angle) =>
            angle.Degrees % AngleDegrees.FullAngle == 0.0;

        /// <summary>
        /// Indicates whether the specified angle is acute.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than zero and less than 90 degrees; otherwise false.</returns>
        public static bool IsAcute(AngleDegrees angle)
        {
            var reduced = AngleDegrees.Reduce(Math.Abs(angle.Degrees));
            return reduced > 0.0 && reduced < AngleDegrees.RightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is right.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 90 degrees; otherwise false.</returns>
        public static bool IsRight(AngleDegrees angle) =>
            AngleDegrees.Reduce(Math.Abs(angle.Degrees)) == AngleDegrees.RightAngle;

        /// <summary>
        /// Indicates whether the specified angle is obtuse.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 90 degrees and less than 180 degrees; otherwise false.</returns>
        public static bool IsObtuse(AngleDegrees angle)
        {
            var reduced = AngleDegrees.Reduce(Math.Abs(angle.Degrees));
            return reduced > AngleDegrees.RightAngle && reduced < AngleDegrees.StraightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is straight.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 180 degrees; otherwise false.</returns>
        public static bool IsStraight(AngleDegrees angle) =>
            AngleDegrees.Reduce(Math.Abs(angle.Degrees)) == AngleDegrees.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 degrees and less than 360 degrees; otherwise false.</returns>
        public static bool IsReflex(AngleDegrees angle) =>
            AngleDegrees.Reduce(Math.Abs(angle.Degrees)) > AngleDegrees.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is oblique.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the angle is not right or a multiple of a right angle; otherwise false.</returns>
        public static bool IsOblique(AngleDegrees angle) =>
            angle.Degrees % AngleDegrees.RightAngle != 0.0;

        #endregion

        #region lerp

        /// <summary>
        /// Performs a linear interpolation.
        /// </summary>
        /// <param name="a1">The first angle.</param>
        /// <param name="a2">The second angle.</param>
        /// <param name="t">A value that linearly interpolates between the a1 parameter and the a2 parameter.</param>
        /// <returns>The result of the linear interpolation.</returns>
        public static AngleDegrees Lerp(AngleDegrees a1, AngleDegrees a2, double t) =>
            new AngleDegrees(Utils.Lerp(a1.Degrees, a2.Degrees, t));

        #endregion

        #region negation

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleDegrees Negate(AngleDegrees angle) =>
            new AngleDegrees(-angle.Degrees);

        #endregion

        #region addition

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleDegrees Add(AngleDegrees left, AngleDegrees right) =>
            new AngleDegrees(left.Degrees + right.Degrees);

        #endregion

        #region subtraction

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleDegrees Subtract(AngleDegrees left, AngleDegrees right) =>
            new AngleDegrees(left.Degrees - right.Degrees);

        #endregion

        #region multiplication

        /// <summary>
        /// Multiplies a angle by a scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleDegrees Multiply(double left, AngleDegrees right) =>
            new AngleDegrees(left * right.Degrees);

        #endregion

        #region division

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleDegrees Divide(AngleDegrees left, double right) =>
            new AngleDegrees(left.Degrees / right);

        #endregion

    }
}
