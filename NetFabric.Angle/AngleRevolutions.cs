using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace NetFabric
{
    [DebuggerDisplay("{Revolutions} revolutions")]
    [DebuggerTypeProxy(typeof(AngleRevolutionsDebugView))]
    [Serializable]
    public readonly struct AngleRevolutions
        : IEquatable<AngleRevolutions>
        , IComparable
        , IComparable<AngleRevolutions>
        , IFormattable
    {
        /// <summary>
        /// Represents the zero RevolutionsAngle value (0 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions Zero = new AngleRevolutions(0.0);

        /// <summary>
        /// Represents the smallest possible value of a RevolutionsAngle. This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions MinValue = new AngleRevolutions(double.MinValue);

        /// <summary>
        /// Represents the largest possible value of a RevolutionsAngle. This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions MaxValue = new AngleRevolutions(double.MaxValue);

        /// <summary>
        /// Represents the right RevolutionsAngle value (90 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions Right = new AngleRevolutions(RightAngle);

        /// <summary>
        /// Represents the straight RevolutionsAngle value (180 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions Straight = new AngleRevolutions(StraightAngle);

        /// <summary>
        /// Represents the full RevolutionsAngle value (360 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleRevolutions Full = new AngleRevolutions(FullAngle);

        /// <summary>
        /// Gets the amplitude of the angle degrees. This field is read-only.
        /// </summary>
        public readonly double Revolutions;

        internal AngleRevolutions(double degrees)
        {
            Revolutions = degrees;
        }

        #region equality implementation

        /// <summary>
        /// Indicates whether two RevolutionsAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        [Pure]
        public static bool operator ==(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions == a2.Revolutions;

        /// <summary>
        /// Indicates whether two RevolutionsAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        [Pure]
        public static bool operator !=(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions != a2.Revolutions;

        /// <summary>
        /// Indicates whether two RevolutionsAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        [Pure]
        public static bool Equals(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions == a2.Revolutions;

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified RevolutionsAngle object.
        /// </summary>
        /// <param name="other">An RevolutionsAngle to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="AngleRevolutions.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        [Pure]
        public readonly bool Equals(AngleRevolutions other) =>
            Revolutions == other.Revolutions;

        #endregion

        #region comparison implementation

        /// <summary>
        /// Indicates whether a specified RevolutionsAngle is less than another specified RevolutionsAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than the value of a2; otherwise, false.</returns>
        [Pure]
        public static bool operator <(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions < a2.Revolutions;

        /// <summary>
        /// Indicates whether a specified RevolutionsAngle is less than or equal to another specified RevolutionsAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than or equal to the value of a2; otherwise, false.</returns>
        [Pure]
        public static bool operator <=(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions <= a2.Revolutions;

        /// <summary>
        /// Indicates whether a specified RevolutionsAngle is greater than another specified RevolutionsAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than the value of a2; otherwise, false.</returns>
        [Pure]
        public static bool operator >(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions > a2.Revolutions;

        /// <summary>
        /// Indicates whether a specified RevolutionsAngle is greater than or equal to another specified RevolutionsAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than or equal to the value of a2; otherwise, false.</returns>
        [Pure]
        public static bool operator >=(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions >= a2.Revolutions;

        [Pure]
        readonly int IComparable<AngleRevolutions>.CompareTo(AngleRevolutions other) =>
            Revolutions.CompareTo(other.Revolutions);

        [Pure]
        readonly int IComparable.CompareTo(object obj) 
            => obj switch
            {
                AngleRevolutions angle => Revolutions.CompareTo(angle.Revolutions),
                _ => Throw.ArgumentException<int>($"Argument has to be an {nameof(AngleRevolutions)}.", nameof(obj)),
            };

        #endregion

        #region math operators

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        [Pure]
        public static AngleRevolutions operator -(AngleRevolutions angle) =>
            new AngleRevolutions(-angle.Revolutions);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        [Pure]
        public static AngleRevolutions operator +(AngleRevolutions left, AngleRevolutions right) =>
            new AngleRevolutions(left.Revolutions + right.Revolutions);

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        [Pure]
        public static AngleRevolutions operator -(AngleRevolutions left, AngleRevolutions right) =>
            new AngleRevolutions(left.Revolutions - right.Revolutions);

        /// <summary>
        /// Multiplies a scalar by an angle value. 
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        [Pure]
        public static AngleRevolutions operator *(double left, AngleRevolutions right) =>
            new AngleRevolutions(left * right.Revolutions);

        /// <summary>
        /// Divides a angle by a scalar value. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        [Pure]
        public static AngleRevolutions operator /(AngleRevolutions left, double right) =>
            new AngleRevolutions(left.Revolutions / right);

        #endregion

        #region string format

        /// <summary>
        /// Converts the value of the current RevolutionsAngle object to its equivalent string representation, using a specified format.
        /// </summary>
        /// <param name="format">A string that specifies the format to be used for the returned string.</param>
        /// <returns>A string representation of the value of the current RevolutionsAngle object, the specified format.</returns>
        [Pure]
        public readonly string ToString(string format) =>
            Revolutions.ToString(format);

        /// <summary>
        /// Converts the value of the current RevolutionsAngle object to its equivalent string representation using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current RevolutionsAngle object as specified by format and provider.</returns>
        [Pure]
        public readonly string ToString(string format, IFormatProvider formatProvider) =>
            Revolutions.ToString(format, formatProvider);

        #endregion

        #region object overrides

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>true if value is a RevolutionsAngle object that represents the same angle as the current RevolutionsAngle structure; otherwise, false.</returns>
        [Pure]
        public override readonly bool Equals(object obj) 
            => obj switch
            {
                AngleRevolutions angle => Equals(angle),
                _ => false,
            };

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        [Pure]
        public override readonly int GetHashCode() =>
            Revolutions.GetHashCode();

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        [Pure]
        public override readonly string ToString() =>
            Revolutions.ToString();

        #endregion

        internal const double RightAngle = 0.25;
        internal const double StraightAngle = 0.5;
        internal const double FullAngle = 1.0;

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
        /// Returns an RevolutionssAngle that represents a specified number of revolutions.
        /// </summary>
        /// <param name="value">A number of revolutions.</param>
        /// <returns>An object that represents value.</returns>
        [Pure]
        public static AngleRevolutions FromRevolutions(double value) =>
            new AngleRevolutions(value);

        /// <summary>
        /// Returns the absolute value of the RevolutionsAngle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>
        /// An RevolutionsAngle, x, such that RevolutionsAngle.Zero &lt;= x &lt;= RevolutionsAngle.MaxValue.
        /// </returns>
        [Pure]
        public static AngleRevolutions Abs(AngleRevolutions angle) =>
            new AngleRevolutions(Math.Abs(angle.Revolutions));

        /// <summary>
        /// Returns a value indicating the sign of an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>A number that indicates the sign of value, -1 if value is less than zero, 0 if value equal to zero, 1 if value is grater than zero.</returns>
        [Pure]
        public static int Sign(AngleRevolutions angle) =>
            Math.Sign(angle.Revolutions);

        #region min

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is smaller.</returns>
        [Pure]
        public static AngleRevolutions Min(AngleRevolutions left, AngleRevolutions right)
        {
            if (left.Revolutions < right.Revolutions)
                return left;

            return right;
        }

        #endregion

        #region max

        /// <summary>
        /// Returns the largest of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is larger.</returns>
        [Pure]
        public static AngleRevolutions Max(AngleRevolutions left, AngleRevolutions right)
        {
            if (left.Revolutions > right.Revolutions)
                return left;

            return right;
        }

        #endregion

        #region reduce

        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns></returns>
        [Pure]
        public static AngleRevolutions Reduce(AngleRevolutions angle) =>
            new AngleRevolutions(AngleRevolutions.Reduce(angle.Revolutions));

        /// <summary>
        /// Returns the quadrant where the terminal side of the angle is when the standard position.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The quadrant where the terminal side of the angle is when the standard position.</returns>
        [Pure]
        public static Quadrant GetQuadrant(AngleRevolutions angle) =>
            AngleRevolutions.GetQuadrant(angle.Revolutions);

        /// <summary>
        /// Returns the reference angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The reference angle.</returns>
        [Pure]
        public static AngleRevolutions GetReference(AngleRevolutions angle) =>
            new AngleRevolutions(AngleRevolutions.GetReference(angle.Revolutions));

        #endregion

        #region comparison 

        /// <summary>
        /// Compares two RevolutionsAngle values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        [Pure]
        public static int Compare(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions.CompareTo(a2.Revolutions);

        /// <summary>
        /// Compares two RevolutionsAngle values and returns an integer that indicates whether when both reduced the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        [Pure]
        public static int CompareReduced(AngleRevolutions a1, AngleRevolutions a2) =>
            AngleRevolutions.Reduce(a1.Revolutions).CompareTo(AngleRevolutions.Reduce(a2.Revolutions));

        #endregion

        #region types of angles

        /// <summary>
        /// Indicates whether the specified angle is equal to Zero when reduced.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is zero; otherwise false.</returns>
        [Pure]
        public static bool IsZero(AngleRevolutions angle) =>
            angle.Revolutions % AngleRevolutions.FullAngle == 0.0;

        /// <summary>
        /// Indicates whether the specified angle is acute.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than zero and less than 90 degrees; otherwise false.</returns>
        [Pure]
        public static bool IsAcute(AngleRevolutions angle)
        {
            var reduced = AngleRevolutions.Reduce(Math.Abs(angle.Revolutions));
            return reduced > 0.0 && reduced < AngleRevolutions.RightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is right.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 90 degrees; otherwise false.</returns>
        [Pure]
        public static bool IsRight(AngleRevolutions angle) =>
            AngleRevolutions.Reduce(Math.Abs(angle.Revolutions)) == AngleRevolutions.RightAngle;

        /// <summary>
        /// Indicates whether the specified angle is obtuse.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 90 degrees and less than 180 degrees; otherwise false.</returns>
        [Pure]
        public static bool IsObtuse(AngleRevolutions angle)
        {
            var reduced = AngleRevolutions.Reduce(Math.Abs(angle.Revolutions));
            return reduced > AngleRevolutions.RightAngle && reduced < AngleRevolutions.StraightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is straight.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 180 degrees; otherwise false.</returns>
        [Pure]
        public static bool IsStraight(AngleRevolutions angle) =>
            AngleRevolutions.Reduce(Math.Abs(angle.Revolutions)) == AngleRevolutions.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 degrees and less than 360 degrees; otherwise false.</returns>
        [Pure]
        public static bool IsReflex(AngleRevolutions angle) =>
            AngleRevolutions.Reduce(Math.Abs(angle.Revolutions)) > AngleRevolutions.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is oblique.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the angle is not right or a multiple of a right angle; otherwise false.</returns>
        [Pure]
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
        [Pure]
        public static AngleRevolutions Lerp(AngleRevolutions a1, AngleRevolutions a2, double t) =>
            new AngleRevolutions(Utils.Lerp(a1.Revolutions, a2.Revolutions, t));

        #endregion

        #region negation

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        [Pure]
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
        [Pure]
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
        [Pure]
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
        [Pure]
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
        [Pure]
        public static AngleRevolutions Divide(AngleRevolutions left, double right) =>
            new AngleRevolutions(left.Revolutions / right);

        #endregion

    }
}
