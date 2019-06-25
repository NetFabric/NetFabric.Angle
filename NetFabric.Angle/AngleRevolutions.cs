using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    public readonly partial struct AngleRevolutions
        : IEquatable<AngleRevolutions>
        , IComparable
        , IComparable<AngleRevolutions>
        , IFormattable
    {
        /// <summary>
        /// Represents a AngleRevolutions value that is not a number (NaN). This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions NaN = new AngleRevolutions(double.NaN);

        /// <summary>
        /// Represents the zero AngleRevolutions value (zero revolutions). This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions Zero = new AngleRevolutions(0.0);

        /// <summary>
        /// Represents the smallest possible value of a AngleRevolutions. This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions MinValue = new AngleRevolutions(double.MinValue);

        /// <summary>
        /// Represents the largest possible value of a AngleRevolutions. This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions MaxValue = new AngleRevolutions(double.MaxValue);

        /// <summary>
        /// Represents the right AngleRevolutions value (quarter revolution). This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions Right = new AngleRevolutions(RightAngle);

        /// <summary>
        /// Represents the straight AngleRevolutions value (half revolution). This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions Straight = new AngleRevolutions(StraightAngle);

        /// <summary>
        /// Represents the full AngleRevolutions value (one revolutions). This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions Full = new AngleRevolutions(FullAngle);

        /// <summary>
        /// Gets the amplitude of the angle in revolutions. This field is read-only.
        /// </summary>
        public readonly double Revolutions;

        internal AngleRevolutions(double revolutions)
        {
            Revolutions = revolutions;
        }

        #region equality implementation

        /// <summary>
        /// Indicates whether two AngleRevolutions instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator ==(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions == a2.Revolutions;

        /// <summary>
        /// Indicates whether two AngleRevolutions instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator !=(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions != a2.Revolutions;

        /// <summary>
        /// Indicates whether two AngleRevolutions instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool Equals(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions == a2.Revolutions;

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified AngleRevolutions object.
        /// </summary>
        /// <param name="other">An AngleRevolutions to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="AngleRevolutions.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public bool Equals(AngleRevolutions other) =>
            Revolutions == other.Revolutions;

        #endregion

        #region comparison implementation

        /// <summary>
        /// Indicates whether a specified AngleRevolutions is less than another specified AngleRevolutions.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than the value of a2; otherwise, false.</returns>
        public static bool operator <(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions < a2.Revolutions;

        /// <summary>
        /// Indicates whether a specified AngleRevolutions is less than or equal to another specified AngleRevolutions.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator <=(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions <= a2.Revolutions;

        /// <summary>
        /// Indicates whether a specified AngleRevolutions is greater than another specified AngleRevolutions.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than the value of a2; otherwise, false.</returns>
        public static bool operator >(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions > a2.Revolutions;

        /// <summary>
        /// Indicates whether a specified AngleRevolutions is greater than or equal to another specified AngleRevolutions.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator >=(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions >= a2.Revolutions;

        int IComparable<AngleRevolutions>.CompareTo(AngleRevolutions other) =>
            Revolutions.CompareTo(other.Revolutions);

        int IComparable.CompareTo(object obj)
        {
            switch (obj)
            {
                case AngleRevolutions angle:
                    return Revolutions.CompareTo(angle.Revolutions);
                default:
                    throw new ArgumentException($"Argument has to be an {nameof(AngleRevolutions)}.", nameof(obj));
            }
        }

        #endregion

        #region math operators

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleRevolutions operator -(AngleRevolutions angle) =>
            new AngleRevolutions(-angle.Revolutions);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleRevolutions operator +(AngleRevolutions left, AngleRevolutions right) =>
            new AngleRevolutions(left.Revolutions + right.Revolutions);

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleRevolutions operator -(AngleRevolutions left, AngleRevolutions right) =>
            new AngleRevolutions(left.Revolutions - right.Revolutions);

        /// <summary>
        /// Multiplies a scalar by an angle value. 
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleRevolutions operator *(double left, AngleRevolutions right) =>
            new AngleRevolutions(left * right.Revolutions);

        /// <summary>
        /// Divides a angle by a scalar value. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleRevolutions operator /(AngleRevolutions left, double right) =>
            new AngleRevolutions(left.Revolutions / right);

        #endregion

        #region string format

        /// <summary>
        /// Converts the value of the current AngleRevolutions object to its equivalent string representation, using a specified format.
        /// </summary>
        /// <param name="format">A string that specifies the format to be used for the returned string.</param>
        /// <returns>A string representation of the value of the current AngleRevolutions object, in the specified format.</returns>
        public string ToString(string format) =>
            Revolutions.ToString(format);

        /// <summary>
        /// Converts the value of the current AngleRevolutions object to its equivalent string representation using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current AngleRevolutions object as specified by format and provider.</returns>
        public string ToString(string format, IFormatProvider formatProvider) =>
            Revolutions.ToString(format, formatProvider);

        #endregion

        #region object overrides

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>true if value is a AngleRevolutions object that represents the same angle as the current AngleRevolutions structure; otherwise, false.</returns>
        public override bool Equals(object obj) =>
            obj is AngleRevolutions angle && Equals(angle);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() =>
            Revolutions.GetHashCode();

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() =>
            Revolutions.ToString();

        #endregion

        internal const double RightAngle = 0.25;
        internal const double StraightAngle = 0.5;
        internal const double FullAngle = 1.0;

        internal static double Reduce(double revolutions)
        {
            var trunc = Math.Truncate(revolutions);
            if (trunc == revolutions)
                return 0.0;

            if (revolutions < 0)
                return FullAngle + revolutions - trunc;

            return revolutions - trunc;
        }

        internal static Quadrant GetQuadrant(double revolutions) =>
            Utils.GetQuadrant(revolutions, RightAngle, StraightAngle, FullAngle);

        internal static double GetReference(double revolutions) =>
            Utils.GetReference(revolutions, RightAngle, StraightAngle, FullAngle);

    }

    public static partial class Angle
    {
        /// <summary>
        /// Returns an RevolutionssAngle that represents a specified number of revolutions.
        /// </summary>
        /// <param name="value">A number of revolutions.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRevolutions FromRevolutions(double value) =>
            new AngleRevolutions(value);

        /// <summary>
        /// Returns the absolute value of the AngleRevolutions.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>
        /// An AngleRevolutions, x, such that AngleRevolutions.Zero &lt;= x &lt;= AngleRevolutions.MaxValue.
        /// </returns>
        public static AngleRevolutions Abs(AngleRevolutions angle) =>
            new AngleRevolutions(Math.Abs(angle.Revolutions));

        /// <summary>
        /// Returns a value indicating the sign of an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>A number that indicates the sign of value, -1 if value is less than zero, 0 if value equal to zero, 1 if value is grater than zero.</returns>
        public static int Sign(AngleRevolutions angle) =>
            Math.Sign(angle.Revolutions);

        #region min

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is smaller.</returns>
        public static AngleRevolutions Min(AngleRevolutions left, AngleRevolutions right) =>
            left.Revolutions < right.Revolutions ? left: right;

        #endregion

        #region max

        /// <summary>
        /// Returns the largest of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is larger.</returns>
        public static AngleRevolutions Max(AngleRevolutions left, AngleRevolutions right) =>
            left.Revolutions > right.Revolutions ? left: right;

        #endregion

        #region reduce

        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns></returns>
        public static AngleRevolutions Reduce(AngleRevolutions angle) =>
            new AngleRevolutions(AngleRevolutions.Reduce(angle.Revolutions));

        /// <summary>
        /// Returns the quadrant where the terminal side of the angle is in when in the standard position.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The quadrant where the terminal side of the angle is in when in the standard position.</returns>
        public static Quadrant GetQuadrant(AngleRevolutions angle) =>
            AngleRevolutions.GetQuadrant(angle.Revolutions);

        /// <summary>
        /// Returns the reference angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The reference angle.</returns>
        public static AngleRevolutions GetReference(AngleRevolutions angle) =>
            new AngleRevolutions(AngleRevolutions.GetReference(angle.Revolutions));

        #endregion

        #region comparison 

        /// <summary>
        /// Compares two AngleRevolutions values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int Compare(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions.CompareTo(a2.Revolutions);

        /// <summary>
        /// Compares two AngleRevolutions values and returns an integer that indicates whether when both reduced the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int CompareReduced(AngleRevolutions a1, AngleRevolutions a2) =>
            AngleRevolutions.Reduce(a1.Revolutions).CompareTo(AngleRevolutions.Reduce(a2.Revolutions));

        #endregion

        #region types of angles

        /// <summary>
        /// Indicates whether the specified angle is equal to Zero when reduced.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is zero; otherwise false.</returns>
        public static bool IsZero(AngleRevolutions angle) =>
            angle.Revolutions % AngleRevolutions.FullAngle == 0.0;

        /// <summary>
        /// Indicates whether the specified angle is acute.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than zero and less than 90 revolutions; otherwise false.</returns>
        public static bool IsAcute(AngleRevolutions angle)
        {
            var reduced = AngleRevolutions.Reduce(Math.Abs(angle.Revolutions));
            return reduced > 0.0 && reduced < AngleRevolutions.RightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is right.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 90 revolutions; otherwise false.</returns>
        public static bool IsRight(AngleRevolutions angle) =>
            AngleRevolutions.Reduce(Math.Abs(angle.Revolutions)) == AngleRevolutions.RightAngle;

        /// <summary>
        /// Indicates whether the specified angle is obtuse.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 90 revolutions and less than 180 revolutions; otherwise false.</returns>
        public static bool IsObtuse(AngleRevolutions angle)
        {
            var reduced = AngleRevolutions.Reduce(Math.Abs(angle.Revolutions));
            return reduced > AngleRevolutions.RightAngle && reduced < AngleRevolutions.StraightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is straight.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 180 revolutions; otherwise false.</returns>
        public static bool IsStraight(AngleRevolutions angle) =>
            AngleRevolutions.Reduce(Math.Abs(angle.Revolutions)) == AngleRevolutions.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 revolutions and less than 360 revolutions; otherwise false.</returns>
        public static bool IsReflex(AngleRevolutions angle) =>
            AngleRevolutions.Reduce(Math.Abs(angle.Revolutions)) > AngleRevolutions.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is oblique.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the angle is not right or a multiple of a right angle; otherwise false.</returns>
        public static bool IsOblique(AngleRevolutions angle) =>
            angle.Revolutions % AngleRevolutions.RightAngle != 0.0;

        #endregion

        #region lerp

        /// <summary>
        /// Performs a linear interpolation.
        /// </summary>
        /// <param name="a1">The first angle.</param>
        /// <param name="a2">The second angle.</param>
        /// <param name="t">A value that linearly interpolates between the a1 parameter and the a2 parameter.</param>
        /// <returns>The result of the linear interpolation.</returns>
        public static AngleRevolutions Lerp(AngleRevolutions a1, AngleRevolutions a2, double t) =>
            new AngleRevolutions(Utils.Lerp(a1.Revolutions, a2.Revolutions, t));

        #endregion

        #region negation

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleRevolutions Negate(AngleRevolutions angle) =>
            new AngleRevolutions(-angle.Revolutions);

        #endregion

        #region addition

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleRevolutions Add(AngleRevolutions left, AngleRevolutions right) =>
            new AngleRevolutions(left.Revolutions + right.Revolutions);

        #endregion

        #region subtraction

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleRevolutions Subtract(AngleRevolutions left, AngleRevolutions right) =>
            new AngleRevolutions(left.Revolutions - right.Revolutions);

        #endregion

        #region multiplication

        /// <summary>
        /// Multiplies a angle by a scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleRevolutions Multiply(double left, AngleRevolutions right) =>
            new AngleRevolutions(left * right.Revolutions);

        #endregion

        #region division

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleRevolutions Divide(AngleRevolutions left, double right) =>
            new AngleRevolutions(left.Revolutions / right);

        #endregion

    }
}
