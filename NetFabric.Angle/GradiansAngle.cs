using System;

namespace NetFabric
{
    public struct GradiansAngle
        : IEquatable<GradiansAngle>
        , IComparable
        , IComparable<GradiansAngle>
        , IFormattable
    {
        /// <summary>
        /// Represents the zero GradiansAngle value (0 degrees). This field is read-only.
        /// </summary>
        public static readonly GradiansAngle Zero = new GradiansAngle(0.0);

        /// <summary>
        /// Represents the golden GradiansAngle value (~137.508 degrees). This field is read-only.
        /// </summary>
        public static readonly GradiansAngle Golden = Angle.InGradians(RadiansAngle.Golden);

        /// <summary>
        /// Represents the smallest possible value of a GradiansAngle. This field is read-only.
        /// </summary>
        public static readonly GradiansAngle MinValue = new GradiansAngle(double.MinValue);

        /// <summary>
        /// Represents the largest possible value of a GradiansAngle. This field is read-only.
        /// </summary>
        public static readonly GradiansAngle MaxValue = new GradiansAngle(double.MaxValue);

        /// <summary>
        /// Represents the right GradiansAngle value (90 degrees). This field is read-only.
        /// </summary>
        public static readonly GradiansAngle Right = new GradiansAngle(RightAngle);

        /// <summary>
        /// Represents the straight GradiansAngle value (180 degrees). This field is read-only.
        /// </summary>
        public static readonly GradiansAngle Straight = new GradiansAngle(StraightAngle);

        /// <summary>
        /// Represents the full GradiansAngle value (360 degrees). This field is read-only.
        /// </summary>
        public static readonly GradiansAngle Full = new GradiansAngle(FullAngle);

        /// <summary>
        /// Gets the amplitude of the angle in degrees. This field is read-only.
        /// </summary>
        public readonly double Gradians;

        internal GradiansAngle(double degrees)
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
        public static bool operator ==(GradiansAngle a1, GradiansAngle a2) =>
            a1.Gradians == a2.Gradians;

        /// <summary>
        /// Indicates whether two GradiansAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator !=(GradiansAngle a1, GradiansAngle a2) =>
            a1.Gradians != a2.Gradians;

        /// <summary>
        /// Indicates whether two GradiansAngle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool Equals(GradiansAngle a1, GradiansAngle a2) =>
            a1.Gradians == a2.Gradians;

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified GradiansAngle object.
        /// </summary>
        /// <param name="other">An GradiansAngle to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="GradiansAngle.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public bool Equals(GradiansAngle other) =>
            Gradians == other.Gradians;

        #endregion

        #region comparison implementation

        /// <summary>
        /// Indicates whether a specified GradiansAngle is less than another specified GradiansAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than the value of a2; otherwise, false.</returns>
        public static bool operator <(GradiansAngle a1, GradiansAngle a2) =>
            a1.Gradians < a2.Gradians;

        /// <summary>
        /// Indicates whether a specified GradiansAngle is less than or equal to another specified GradiansAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator <=(GradiansAngle a1, GradiansAngle a2) =>
            a1.Gradians <= a2.Gradians;

        /// <summary>
        /// Indicates whether a specified GradiansAngle is greater than another specified GradiansAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than the value of a2; otherwise, false.</returns>
        public static bool operator >(GradiansAngle a1, GradiansAngle a2) =>
            a1.Gradians > a2.Gradians;

        /// <summary>
        /// Indicates whether a specified GradiansAngle is greater than or equal to another specified GradiansAngle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator >=(GradiansAngle a1, GradiansAngle a2) =>
            a1.Gradians >= a2.Gradians;

        int IComparable<GradiansAngle>.CompareTo(GradiansAngle other) =>
            Gradians.CompareTo(other.Gradians);

        int IComparable.CompareTo(object obj)
        {
            switch (obj)
            {
                case GradiansAngle angle:
                    return Gradians.CompareTo(angle.Gradians);
                default:
                    throw new ArgumentException("Argument has to be an GradiansAngle.", nameof(obj));
            }
        }

        #endregion

        #region math operators

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static GradiansAngle operator -(GradiansAngle angle) =>
            new GradiansAngle(-angle.Gradians);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static GradiansAngle operator +(GradiansAngle left, GradiansAngle right) =>
            new GradiansAngle(left.Gradians + right.Gradians);

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static GradiansAngle operator -(GradiansAngle left, GradiansAngle right) =>
            new GradiansAngle(left.Gradians - right.Gradians);

        /// <summary>
        /// Multiplies a scalar by an angle value. 
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static GradiansAngle operator *(double left, GradiansAngle right) =>
            new GradiansAngle(left * right.Gradians);

        /// <summary>
        /// Divides a angle by a scalar value. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static GradiansAngle operator /(GradiansAngle left, double right) =>
            new GradiansAngle(left.Gradians / right);

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
                case GradiansAngle angle:
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
        /// Returns the absolute value of the GradiansAngle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>
        /// An GradiansAngle, x, such that GradiansAngle.Zero &lt;= x &lt;= GradiansAngle.MaxValue.
        /// </returns>
        public static GradiansAngle Abs(GradiansAngle angle) =>
            new GradiansAngle(Math.Abs(angle.Gradians));

        /// <summary>
        /// Returns a value indicating the sign of an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>A number that indicates the sign of value, -1 if value is less than zero, 0 if value equal to zero, 1 if value is grater than zero.</returns>
        public static int Sign(GradiansAngle angle) =>
            Math.Sign(angle.Gradians);

        #region min

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>Parameter left or right, whichever is smaller.</returns>
        public static GradiansAngle Min(GradiansAngle left, GradiansAngle right) =>
            left.Gradians < right.Gradians ? left : right;

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is smaller.</returns>
        public static ref GradiansAngle Min(ref GradiansAngle left, ref GradiansAngle right)
        {
            if (left.Gradians < right.Gradians)
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
        public static GradiansAngle Max(GradiansAngle left, GradiansAngle right) =>
            left.Gradians > right.Gradians ? left : right;

        /// <summary>
        /// Returns the largest of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns>A reference to parameter left or right, whichever is larger.</returns>
        public static ref GradiansAngle Max(ref GradiansAngle left, ref GradiansAngle right)
        {
            if (left.Gradians > right.Gradians)
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
        public static GradiansAngle Reduce(GradiansAngle angle) =>
            new GradiansAngle(GradiansAngle.Reduce(angle.Gradians));

        /// <summary>
        /// Returns the quadrant where the terminal side of the angle is in when in the standard position.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The quadrant where the terminal side of the angle is in when in the standard position.</returns>
        public static Quadrant GetQuadrant(GradiansAngle angle) =>
            GradiansAngle.GetQuadrant(angle.Gradians);

        /// <summary>
        /// Returns the reference angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The reference angle.</returns>
        public static GradiansAngle GetReference(GradiansAngle angle) =>
            new GradiansAngle(GradiansAngle.GetReference(angle.Gradians));

        #endregion

        #region comparison 

        /// <summary>
        /// Compares two GradiansAngle values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int Compare(GradiansAngle a1, GradiansAngle a2) =>
            a1.Gradians.CompareTo(a2.Gradians);

        /// <summary>
        /// Compares two GradiansAngle values and returns an integer that indicates whether when both reduced the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int CompareReduced(GradiansAngle a1, GradiansAngle a2) =>
            GradiansAngle.Reduce(a1.Gradians).CompareTo(GradiansAngle.Reduce(a2.Gradians));

        #endregion

        #region types of angles

        /// <summary>
        /// Indicates whether the specified angle is equal to Zero when reduced.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is zero; otherwise false.</returns>
        public static bool IsZero(GradiansAngle angle) =>
            angle.Gradians % GradiansAngle.FullAngle == 0.0;

        /// <summary>
        /// Indicates whether the specified angle is acute.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than zero and less than 90 degrees; otherwise false.</returns>
        public static bool IsAcute(GradiansAngle angle)
        {
            var reduced = GradiansAngle.Reduce(Math.Abs(angle.Gradians));
            return reduced > 0.0 && reduced < GradiansAngle.RightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is right.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 90 degrees; otherwise false.</returns>
        public static bool IsRight(GradiansAngle angle) =>
            GradiansAngle.Reduce(Math.Abs(angle.Gradians)) == GradiansAngle.RightAngle;

        /// <summary>
        /// Indicates whether the specified angle is obtuse.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 90 degrees and less than 180 degrees; otherwise false.</returns>
        public static bool IsObtuse(GradiansAngle angle)
        {
            var reduced = GradiansAngle.Reduce(Math.Abs(angle.Gradians));
            return reduced > GradiansAngle.RightAngle && reduced < GradiansAngle.StraightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is straight.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 180 degrees; otherwise false.</returns>
        public static bool IsStraight(GradiansAngle angle) =>
            GradiansAngle.Reduce(Math.Abs(angle.Gradians)) == GradiansAngle.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 degrees and less than 360 degrees; otherwise false.</returns>
        public static bool IsReflex(GradiansAngle angle) =>
            GradiansAngle.Reduce(Math.Abs(angle.Gradians)) > GradiansAngle.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is oblique.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the angle is not right or a multiple of a right angle; otherwise false.</returns>
        public static bool IsOblique(GradiansAngle angle) =>
            angle.Gradians % GradiansAngle.RightAngle != 0.0;

        #endregion

        #region lerp

        /// <summary>
        /// Performs a linear interpolation.
        /// </summary>
        /// <param name="a1">The first angle.</param>
        /// <param name="a2">The second angle.</param>
        /// <param name="t">A value that linearly interpolates between the a1 parameter and the a2 parameter.</param>
        /// <returns>The result of the linear interpolation.</returns>
        public static GradiansAngle Lerp(GradiansAngle a1, GradiansAngle a2, double t) =>
            new GradiansAngle(Utils.Lerp(a1.Gradians, a2.Gradians, t));

        #endregion

        #region negation

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static GradiansAngle Negate(GradiansAngle angle) =>
            new GradiansAngle(-angle.Gradians);

        #endregion

        #region addition

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static GradiansAngle Add(GradiansAngle left, GradiansAngle right) =>
            new GradiansAngle(left.Gradians + right.Gradians);

        #endregion

        #region subtraction

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static GradiansAngle Subtract(GradiansAngle left, GradiansAngle right) =>
            new GradiansAngle(left.Gradians - right.Gradians);

        #endregion

        #region multiplication

        /// <summary>
        /// Multiplies a angle by a scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static GradiansAngle Multiply(double left, GradiansAngle right) =>
            new GradiansAngle(left * right.Gradians);

        #endregion

        #region division

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static GradiansAngle Divide(GradiansAngle left, double right) =>
            new GradiansAngle(left.Gradians / right);

        #endregion

    }
}
