using System;

namespace NetFabric
{
    public readonly partial struct AngleGradians
        : IEquatable<AngleGradians>
        , IComparable
        , IComparable<AngleGradians>
        , IFormattable
    {
        /// <summary>
        /// Represents the zero GradiansAngle value (0 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleGradians Zero = new AngleGradians(0.0);

        /// <summary>
        /// Represents the golden GradiansAngle value (~137.508 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleGradians Golden = Angle.ToGradians(AngleRadians.Golden);

        /// <summary>
        /// Represents the smallest possible value of a GradiansAngle. This field is read-only.
        /// </summary>
        public static readonly AngleGradians MinValue = new AngleGradians(double.MinValue);

        /// <summary>
        /// Represents the largest possible value of a GradiansAngle. This field is read-only.
        /// </summary>
        public static readonly AngleGradians MaxValue = new AngleGradians(double.MaxValue);

        /// <summary>
        /// Represents the right GradiansAngle value (90 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleGradians Right = new AngleGradians(RightAngle);

        /// <summary>
        /// Represents the straight GradiansAngle value (180 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleGradians Straight = new AngleGradians(StraightAngle);

        /// <summary>
        /// Represents the full GradiansAngle value (360 degrees). This field is read-only.
        /// </summary>
        public static readonly AngleGradians Full = new AngleGradians(FullAngle);

        /// <summary>
        /// Gets the amplitude of the angle in degrees. This field is read-only.
        /// </summary>
        public readonly double Gradians;

        internal AngleGradians(double degrees)
        {
            Gradians = degrees;
        }

        #region equality implementation

        /// <summary>
        /// Indicates whether two GradiansAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator ==(AngleGradians a1, AngleGradians a2) =>
            a1.Gradians == a2.Gradians;

        /// <summary>
        /// Indicates whether two GradiansAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator !=(AngleGradians a1, AngleGradians a2) =>
            a1.Gradians != a2.Gradians;

        /// <summary>
        /// Indicates whether two GradiansAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool Equals(AngleGradians a1, AngleGradians a2) =>
            a1.Gradians == a2.Gradians;

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified GradiansAngle object.
        /// </summary>
        /// <param name="other">An GradiansAngle to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="AngleGradians.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public bool Equals(AngleGradians other) =>
            Gradians == other.Gradians;

        #endregion

        #region comparison implementation

        /// <summary>
        /// Indicates whether a specified GradiansAngle is less than another specified GradiansAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than the value of a2; otherwise, false.</returns>
        public static bool operator <(AngleGradians a1, AngleGradians a2) =>
            a1.Gradians < a2.Gradians;

        /// <summary>
        /// Indicates whether a specified GradiansAngle is less than or equal to another specified GradiansAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator <=(AngleGradians a1, AngleGradians a2) =>
            a1.Gradians <= a2.Gradians;

        /// <summary>
        /// Indicates whether a specified GradiansAngle is greater than another specified GradiansAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than the value of a2; otherwise, false.</returns>
        public static bool operator >(AngleGradians a1, AngleGradians a2) =>
            a1.Gradians > a2.Gradians;

        /// <summary>
        /// Indicates whether a specified GradiansAngle is greater than or equal to another specified GradiansAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator >=(AngleGradians a1, AngleGradians a2) =>
            a1.Gradians >= a2.Gradians;

        int IComparable<AngleGradians>.CompareTo(AngleGradians other) =>
            Gradians.CompareTo(other.Gradians);

        int IComparable.CompareTo(object obj)
        {
            switch (obj)
            {
                case AngleGradians angle:
                    return Gradians.CompareTo(angle.Gradians);
                default:
                    throw new ArgumentException($"Argument has to be an {nameof(AngleGradians)}.", nameof(obj));
            }
        }

        #endregion

        #region math operators

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleGradians operator -(AngleGradians angle) =>
            new AngleGradians(-angle.Gradians);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleGradians operator +(AngleGradians left, AngleGradians right) =>
            new AngleGradians(left.Gradians + right.Gradians);

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleGradians operator -(AngleGradians left, AngleGradians right) =>
            new AngleGradians(left.Gradians - right.Gradians);

        /// <summary>
        /// Multiplies a scalar by an angle value. 
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleGradians operator *(double left, AngleGradians right) =>
            new AngleGradians(left * right.Gradians);

        /// <summary>
        /// Divides a angle by a scalar value. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleGradians operator /(AngleGradians left, double right) =>
            new AngleGradians(left.Gradians / right);

        #endregion

        #region string format

        /// <summary>
        /// Converts the value of the current GradiansAngle object to its equivalent string representation, using a specified format.
        /// </summary>
        /// <param name="format">A string that specifies the format to be used for the returned string.</param>
        /// <returns>A string representation of the value of the current GradiansAngle object, in the specified format.</returns>
        public string ToString(string format) =>
            Gradians.ToString(format);

        /// <summary>
        /// Converts the value of the current GradiansAngle object to its equivalent string representation using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current GradiansAngle object as specified by format and provider.</returns>
        public string ToString(string format, IFormatProvider formatProvider) =>
            Gradians.ToString(format, formatProvider);

        #endregion

        #region object overrides

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>true if value is a GradiansAngle object that represents the same angle as the current GradiansAngle structure; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case AngleGradians angle:
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
            Gradians.GetHashCode();

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() =>
            Gradians.ToString();

        #endregion

        internal const double RightAngle = 100.0;
        internal const double StraightAngle = 200.0;
        internal const double FullAngle = 400.0;

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
        /// Returns an GradianssAngle that represents a specified number of gradians.
        /// </summary>
        /// <param name="value">A number of gradians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleGradians FromGradians(double value) =>
            new AngleGradians(value);

        /// <summary>
        /// Returns the absolute value of the GradiansAngle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>
        /// An GradiansAngle, x, such that GradiansAngle.Zero &lt;= x &lt;= GradiansAngle.MaxValue.
        /// </returns>
        public static AngleGradians Abs(AngleGradians angle) =>
            new AngleGradians(Math.Abs(angle.Gradians));

        /// <summary>
        /// Returns a value indicating the sign of an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>A number that indicates the sign of value, -1 if value is less than zero, 0 if value equal to zero, 1 if value is grater than zero.</returns>
        public static int Sign(AngleGradians angle) =>
            Math.Sign(angle.Gradians);

        #region min

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is smaller.</returns>
        public static ref readonly AngleGradians Min(in AngleGradians left, in AngleGradians right)
        {
            if (left.Gradians < right.Gradians)
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
        public static ref readonly AngleGradians Max(in AngleGradians left, in AngleGradians right)
        {
            if (left.Gradians > right.Gradians)
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
        public static AngleGradians Reduce(AngleGradians angle) =>
            new AngleGradians(AngleGradians.Reduce(angle.Gradians));

        /// <summary>
        /// Returns the quadrant where the terminal side of the angle is in when in the standard position.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The quadrant where the terminal side of the angle is in when in the standard position.</returns>
        public static Quadrant GetQuadrant(AngleGradians angle) =>
            AngleGradians.GetQuadrant(angle.Gradians);

        /// <summary>
        /// Returns the reference angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The reference angle.</returns>
        public static AngleGradians GetReference(AngleGradians angle) =>
            new AngleGradians(AngleGradians.GetReference(angle.Gradians));

        #endregion

        #region comparison 

        /// <summary>
        /// Compares two GradiansAngle values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int Compare(AngleGradians a1, AngleGradians a2) =>
            a1.Gradians.CompareTo(a2.Gradians);

        /// <summary>
        /// Compares two GradiansAngle values and returns an integer that indicates whether when both reduced the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int CompareReduced(AngleGradians a1, AngleGradians a2) =>
            AngleGradians.Reduce(a1.Gradians).CompareTo(AngleGradians.Reduce(a2.Gradians));

        #endregion

        #region types of angles

        /// <summary>
        /// Indicates whether the specified angle is equal to Zero when reduced.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is zero; otherwise false.</returns>
        public static bool IsZero(AngleGradians angle) =>
            angle.Gradians % AngleGradians.FullAngle == 0.0;

        /// <summary>
        /// Indicates whether the specified angle is acute.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than zero and less than 90 degrees; otherwise false.</returns>
        public static bool IsAcute(AngleGradians angle)
        {
            var reduced = AngleGradians.Reduce(Math.Abs(angle.Gradians));
            return reduced > 0.0 && reduced < AngleGradians.RightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is right.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 90 degrees; otherwise false.</returns>
        public static bool IsRight(AngleGradians angle) =>
            AngleGradians.Reduce(Math.Abs(angle.Gradians)) == AngleGradians.RightAngle;

        /// <summary>
        /// Indicates whether the specified angle is obtuse.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 90 degrees and less than 180 degrees; otherwise false.</returns>
        public static bool IsObtuse(AngleGradians angle)
        {
            var reduced = AngleGradians.Reduce(Math.Abs(angle.Gradians));
            return reduced > AngleGradians.RightAngle && reduced < AngleGradians.StraightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is straight.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 180 degrees; otherwise false.</returns>
        public static bool IsStraight(AngleGradians angle) =>
            AngleGradians.Reduce(Math.Abs(angle.Gradians)) == AngleGradians.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 degrees and less than 360 degrees; otherwise false.</returns>
        public static bool IsReflex(AngleGradians angle) =>
            AngleGradians.Reduce(Math.Abs(angle.Gradians)) > AngleGradians.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is oblique.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the angle is not right or a multiple of a right angle; otherwise false.</returns>
        public static bool IsOblique(AngleGradians angle) =>
            angle.Gradians % AngleGradians.RightAngle != 0.0;

        #endregion

        #region lerp

        /// <summary>
        /// Performs a linear interpolation.
        /// </summary>
        /// <param name="a1">The first angle.</param>
        /// <param name="a2">The second angle.</param>
        /// <param name="t">A value that linearly interpolates between the a1 parameter and the a2 parameter.</param>
        /// <returns>The result of the linear interpolation.</returns>
        public static AngleGradians Lerp(AngleGradians a1, AngleGradians a2, double t) =>
            new AngleGradians(Utils.Lerp(a1.Gradians, a2.Gradians, t));

        #endregion

        #region negation

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleGradians Negate(AngleGradians angle) =>
            new AngleGradians(-angle.Gradians);

        #endregion

        #region addition

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleGradians Add(AngleGradians left, AngleGradians right) =>
            new AngleGradians(left.Gradians + right.Gradians);

        #endregion

        #region subtraction

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleGradians Subtract(AngleGradians left, AngleGradians right) =>
            new AngleGradians(left.Gradians - right.Gradians);

        #endregion

        #region multiplication

        /// <summary>
        /// Multiplies a angle by a scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleGradians Multiply(double left, AngleGradians right) =>
            new AngleGradians(left * right.Gradians);

        #endregion

        #region division

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleGradians Divide(AngleGradians left, double right) =>
            new AngleGradians(left.Gradians / right);

        #endregion

    }
}
