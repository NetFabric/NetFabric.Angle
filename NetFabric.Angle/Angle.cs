using System;
using System.Diagnostics;

namespace NetFabric
{
    /// <summary>
    /// Represents an angle. 
    /// </summary>
#if !NETSTANDARD1_0
    [Serializable]
#endif
    [DebuggerDisplay("{ToDegrees()}°")]
    [DebuggerTypeProxy(typeof(AngleDebugView))]
    public partial struct Angle
        : IEquatable<Angle>
        , IComparable
        , IComparable<Angle>
        , IFormattable
    {
        readonly double radians;

        /// <summary>
        /// The four regions divided by the x and y axis.
        /// </summary>
        public enum Quadrant
        {
            /// <summary>
            /// The region where x and y are positive.
            /// </summary>
            First,
            /// <summary>
            /// The region where x is negative and y is positive.
            /// </summary>
            Second,
            /// <summary>
            /// The region where x and y are negative.
            /// </summary>
            Third,
            /// <summary>
            /// The region where x is positive and y is negative.
            /// </summary>
            Fourth
        }

        const double RightAngle = Math.PI * 0.5;
        const double StraightAngle = Math.PI;
        const double FullAngle = Math.PI * 2.0;

        const double DegreesByRadians = 360.0 / FullAngle;
        const double GradiansByRadians = 400.0 / FullAngle;

        /// <summary>
        /// Represents the zero Angle value (0 degrees). This field is read-only.
        /// </summary>
        public static readonly Angle Zero = new Angle(0.0);

        /// <summary>
        /// Represents the smallest possible value of a Double. This field is read-only.
        /// </summary>
        public static readonly Angle MinValue = new Angle(double.MinValue);

        /// <summary>
        /// Represents the largest possible value of a Double. This field is read-only.
        /// </summary>
        public static readonly Angle MaxValue = new Angle(double.MaxValue);

        /// <summary>
        /// Represents the right Angle value (90 degrees). This field is read-only.
        /// </summary>
        public static readonly Angle Right = new Angle(RightAngle);

        /// <summary>
        /// Represents the straight Angle value (180 degrees). This field is read-only.
        /// </summary>
        public static readonly Angle Straight = new Angle(StraightAngle);

        /// <summary>
        /// Represents the full Angle value (360 degrees). This field is read-only.
        /// </summary>
        public static readonly Angle Full = new Angle(FullAngle);

        private Angle(double radians)
        {
            this.radians = radians;
        }

        /// <summary>
        /// Returns an Angle that represents a specified number of radians.
        /// </summary>
        /// <param name="value">A number of radians.</param>
        /// <returns>An object that represents value.</returns>
        public static Angle FromRadians(double value) => 
            new Angle(value);

        /// <summary>
        /// Returns an Angle that represents a specified number of degrees.
        /// </summary>
        /// <param name="value">A number of degrees.</param>
        /// <returns>An object that represents value.</returns>
        public static Angle FromDegrees(double value) => 
            new Angle(value / DegreesByRadians);

        /// <summary>
        /// Returns an Angle that represents a specified number of degrees and minutes.
        /// </summary>
        /// <param name="degrees">The degrees parcel of the angle value.</param>
        /// <param name="minutes">The minutes parcel of the angle value.</param>
        /// <returns>An object that represents value.</returns>
        public static Angle FromDegrees(int degrees, double minutes)
        {
            if (minutes < 0.0 || minutes >= 60.0)
                throw new ArgumentOutOfRangeException(nameof(minutes), minutes, "Argument must be positive and less than 60.");

            if (Math.Sign(degrees) < 0)
                return new Angle((degrees - minutes / 60.0) / DegreesByRadians);
            else
                return new Angle((degrees + minutes / 60.0) / DegreesByRadians);
        }

        /// <summary>
        /// Returns an Angle that represents a specified number of degrees, minutes and seconds.
        /// </summary>
        /// <param name="degrees">The degrees parcel of the angle value.</param>
        /// <param name="minutes">The minutes parcel of the angle value.</param>
        /// <param name="seconds">The seconds parcel of the angle value.</param>
        /// <returns>An object that represents value.</returns>
        public static Angle FromDegrees(int degrees, int minutes, double seconds)
        {
            if (minutes < 0.0 || minutes >= 60.0)
                throw new ArgumentOutOfRangeException(nameof(minutes), minutes, "Argument must be positive and less than 60.");
            if (seconds < 0.0 || seconds >= 60.0)
                throw new ArgumentOutOfRangeException(nameof(seconds), seconds, "Argument must be positive and less than 60.");

            if (Math.Sign(degrees) < 0)
                return new Angle((degrees - minutes / 60.0 - seconds / 3600.0) / DegreesByRadians);
            else
                return new Angle((degrees + minutes / 60.0 + seconds / 3600.0) / DegreesByRadians);
        }

        /// <summary>
        /// Returns an Angle that represents a specified number of gradians.
        /// </summary>
        /// <param name="value">A number of gradians.</param>
        /// <returns>An object that represents value.</returns>
        public static Angle FromGradians(double value) => 
            new Angle(value / GradiansByRadians);

        /// <summary>
        /// Gets the value of the current Angle structure expressed in whole and fractional radians.
        /// </summary>
        public double ToRadians() => 
            radians;

        /// <summary>
        /// Gets the value of the current Angle structure expressed in whole and fractional degrees.
        /// </summary>
        public double ToDegrees() => 
            radians * DegreesByRadians;

        /// <summary>
        /// Gets the value of the current Angle structure expressed in degrees and minutes.
        /// </summary>
        /// <param name="degress">The degrees component.</param>
        /// <param name="minutes">The arcminutes component.</param>
        public void ToDegrees(out int degress, out double minutes)
        {
            var decimalDegrees = radians * DegreesByRadians;
            degress = (int)decimalDegrees;
            minutes = Math.Abs(decimalDegrees - degress) * 60.0;
        }

        /// <summary>
        /// Gets the value of the current Angle structure expressed in degrees, minutes and seconds.
        /// </summary>
        /// <param name="degress">The degrees component.</param>
        /// <param name="minutes">The arcminutes component.</param>
        /// <param name="seconds">The arcseconds component.</param>
        public void ToDegrees(out int degress, out int minutes, out double seconds)
        {
            var decimalDegrees = radians * DegreesByRadians;
            degress = (int)decimalDegrees;
            var decimalMinutes = Math.Abs(decimalDegrees - degress) * 60.0;
            minutes = (int)decimalMinutes;
            seconds = (decimalMinutes - minutes) * 60.0;
        }

#if !NET35

        /// <summary>
        /// Gets the value of the current Angle structure expressed in degrees and minutes.
        /// </summary>
        /// <returns>The degrees and minutes components of the Angle.</returns>
        public (int degress, double minutes) ToDegreesMinutes()
        {
            var decimalDegrees = radians * DegreesByRadians;
            var degress = (int)decimalDegrees;
            var minutes = Math.Abs(decimalDegrees - degress) * 60.0;
            return (degress, minutes);
        }

        /// <summary>
        /// Gets the value of the current Angle structure expressed in degrees, minutes and seconds.
        /// </summary>
        /// <returns>The degrees, minutes and seconds components of the Angle.</returns>
        public (int degress, int minutes, double seconds) ToDegreesMinutesSeconds()
        {
            var decimalDegrees = radians * DegreesByRadians;
            var degress = (int)decimalDegrees;
            var decimalMinutes = Math.Abs(decimalDegrees - degress) * 60.0;
            var minutes = (int)decimalMinutes;
            var seconds = (decimalMinutes - minutes) * 60.0;
            return (degress, minutes, seconds);
        }

#endif

        /// <summary>
        /// Gets the value of the current Angle structure expressed in whole and fractional gradians.
        /// </summary>
        public double ToGradians() => 
            radians * GradiansByRadians;

        /// <summary>
        /// Returns the absolute value of the Angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>
        /// An Angle, x, such that Angle.Zero &lt;= x &lt;= Angle.MaxValue.
        /// </returns>
        public static Angle Abs(Angle angle) => 
            new Angle(Math.Abs(angle.radians));

        /// <summary>
        /// Returns a value indicating the sign of an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>A number that indicates the sign of value, -1 if value is less than zero, 0 if value equal to zero, 1 if value is grater than zero.</returns>
        public static int Sign(Angle angle) => 
            Math.Sign(angle.radians);

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns></returns>
        public static Angle Min(Angle left, Angle right) => 
            left.radians < right.radians ? left : right;

        /// <summary>
        /// Returns the largest of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns></returns>
        public static Angle Max(Angle left, Angle right) => 
            left.radians > right.radians ? left : right;

        /// <summary>
        /// Performs a linear interpolation.
        /// </summary>
        /// <param name="a1">The first angle.</param>
        /// <param name="a2">The second angle.</param>
        /// <param name="t">A value that linearly interpolates between the a1 parameter and the a2 parameter.</param>
        /// <returns>The result of the linear interpolation.</returns>
        public static Angle Lerp(Angle a1, Angle a2, double t) => 
            (1 - t) * a1 + t * a2;

#region types of angles

        /// <summary>
        /// Indicates whether the specified angle is acute.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>true if the reduction of the absolute angle is greater than zero and less than 90 degrees; otherwise false.</returns>
        public static bool IsAcute(Angle angle)
        {
            var reduced = Reduce(Math.Abs(angle.radians));
            return reduced > 0.0 && reduced < RightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is right.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>true if the reduction of the absolute angle is 90 degrees; otherwise false.</returns>
        public static bool IsRight(Angle angle) => 
            Reduce(Math.Abs(angle.radians)) == RightAngle;

        /// <summary>
        /// Indicates whether the specified angle is right within a certain variance.
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="acceptableVariance">The acceptable variance.</param>
        /// <returns>true if the reduction of the absolute angle is approximately 90 degrees; otherwise false.</returns>
        public static bool IsRight(Angle angle, Angle acceptableVariance) =>
            AproximatelyEquals(Reduce(Math.Abs(angle.radians)), RightAngle, acceptableVariance.radians);

        /// <summary>
        /// Indicates whether the specified angle is obtuse.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>true if the reduction of the absolute angle is greater than 90 degrees and less than 180 degrees; otherwise false.</returns>
        public static bool IsObtuse(Angle angle)
        {
            var reduced = Reduce(Math.Abs(angle.radians));
            return reduced > RightAngle && reduced < StraightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is straight.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>true if the reduction of the absolute angle is 180 degrees; otherwise false.</returns>
        public static bool IsStraight(Angle angle) =>
            Reduce(Math.Abs(angle.radians)) == StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is straight within a certain variance.
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="acceptableVariance">The acceptable variance.</param>
        /// <returns>true if the reduction of the absolute angle is approximately 180 degrees; otherwise false.</returns>
        public static bool IsStraight(Angle angle, Angle acceptableVariance) =>
            AproximatelyEquals(Reduce(Math.Abs(angle.radians)), StraightAngle, acceptableVariance.radians);

        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 degrees and less than 360 degrees; otherwise false.</returns>
        public static bool IsReflex(Angle angle) => 
            Reduce(Math.Abs(angle.radians)) > StraightAngle;

#endregion

#region reduce

        static double Reduce(double radians)
        {
            var reduced = radians % FullAngle;
            return reduced >= 0 ? reduced : reduced + FullAngle;
        }

        static Quadrant GetQuadrant(double radians)
        {
            if (radians < RightAngle)
                return Quadrant.First;
            if (radians < StraightAngle)
                return Quadrant.Second;
            if (radians < StraightAngle + RightAngle)
                return Quadrant.Third;
            return Quadrant.Fourth;
        }

        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static Angle Reduce(Angle angle)
        {
            var reduced = Reduce(angle.radians);
            return new Angle(reduced);
        }

        /// <summary>
        /// Returns the quadrant where the terminal side of the angle is in when in the standard position.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>The quadrant where the terminal side of the angle is in when in the standard position.</returns>
        public static Quadrant GetQuadrant(Angle angle) =>
            GetQuadrant(Reduce(angle.radians));

        /// <summary>
        /// Returns the reference angle.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>The reference angle.</returns>
        public static Angle GetReference(Angle angle)
        {
            var reduced = Reduce(angle.radians);
            switch(GetQuadrant(reduced))
            {
                case Quadrant.First:
                    return new Angle(reduced);
                case Quadrant.Second:
                    return new Angle(StraightAngle - reduced);
                case Quadrant.Third:
                    return new Angle(reduced - StraightAngle);
                case Quadrant.Fourth:
                    return new Angle(FullAngle - reduced);
                default:
                    throw new InvalidOperationException();
            }
        }

#endregion

#region trigonometric functions

        /// <summary>
        /// Return the sine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The sine of the specified angle. If angle is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</returns>
        public static double Sin(Angle angle) =>
            Math.Sin(angle.radians);

        /// <summary>
        /// Returns the hyperbolic sine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The hyperbolic sine of value. If value is equal to NegativeInfinity, PositiveInfinity, or NaN, this method returns an Angle equal to value.</returns>
        public static double Sinh(Angle angle) =>
             Math.Sinh(angle.radians);

        /// <summary>
        /// Returns the angle whose sine is the specified number.
        /// </summary>
        /// <param name="value">A number representing a sine, where value must be greater than or equal to -1, but less than or equal to 1.</param>
        /// <returns>The angle whose sine is the specified number.</returns>
        public static Angle Asin(double value)
        {
            if (value < -1.0 || value > 1.0)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Argument must be greater or equal to -1.0 and less or equal to 1.0.");

            return new Angle(Math.Asin(value));
        }

        /// <summary>
        /// Return the cosine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The cosine of the specified angle. If angle is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</returns>
        public static double Cos(Angle angle) =>
            Math.Cos(angle.radians);

        /// <summary>
        /// Returns the hyperbolic cosine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The hyperbolic cosine of value. If value is equal to NegativeInfinity, PositiveInfinity, or NaN, this method returns an Angle equal to value.</returns>
        public static double Cosh(Angle angle) =>
            Math.Cosh(angle.radians);

        /// <summary>
        /// Returns the angle whose cosine is the specified number.
        /// </summary>
        /// <param name="value">A number representing a cosine, where value must be greater than or equal to -1, but less than or equal to 1.</param>
        /// <returns>The angle whose cosine is the specified number.</returns>
        public static Angle Acos(double value)
        {
            if (value < -1.0 || value > 1.0)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Argument must be greater or equal to -1.0 and less or equal to 1.0.");

            return new Angle(Math.Acos(value));
        }

        /// <summary>
        /// Returns the tangent of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The tangent of the specified angle. If angle is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</returns>
        public static double Tan(Angle angle) =>
            Math.Tan(angle.radians);

        /// <summary>
        /// Returns the angle whose tangent is the specified number.
        /// </summary>
        /// <param name="value">A number representing a tangent.</param>
        /// <returns>The angle whose tangent is the specified number.</returns>
        public static Angle Atan(double value) =>
            new Angle(Math.Atan(value));

        /// <summary>
        /// Returns the angle whose tangent is the quotient of two specified numbers.
        /// </summary>
        /// <param name="x">The y coordinate of a point.</param>
        /// <param name="y">The x coordinate of a point.</param>
        /// <returns>The angle whose tangent is the quotient of two specified numbers.</returns>
        public static Angle Atan2(double y, double x) =>
            new Angle(Math.Atan2(y, x));

#endregion

#region equality implementation

        /// <summary>
        /// Indicates whether two Angle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator ==(Angle a1, Angle a2) =>
            a1.radians == a2.radians;

        /// <summary>
        /// Indicates whether two Angle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator !=(Angle a1, Angle a2) =>
            a1.radians != a2.radians;

        /// <summary>
        /// Indicates whether two Angle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool Equals(Angle a1, Angle a2) =>
            a1.radians == a2.radians;

        /// <summary>
        /// Indicates whether two Angle instances are approximately equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <param name="acceptableVariance">The acceptable variance.</param>
        /// <returns>true if the difference between a1 and a2 is less than acceptableVariance; otherwise, false.</returns>
        public static bool Equals(Angle a1, Angle a2, Angle acceptableVariance) =>
            AproximatelyEquals(a1.radians, a2.radians, acceptableVariance.radians);

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified Angle object.
        /// </summary>
        /// <param name="obj">An Angle to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the System.IEquatable&lt;T&gt; interface, and performs slightly better than <see cref="Angle.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public bool Equals(Angle obj) =>
            radians == obj.radians;

#endregion

#region comparison implementation

        /// <summary>
        /// Indicates whether a specified Angle is less than another specified Angle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than the value of a2; otherwise, false.</returns>
        public static bool operator <(Angle a1, Angle a2) =>
            a1.radians < a2.radians;

        /// <summary>
        /// Indicates whether a specified Angle is less than or equal to another specified Angle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator <=(Angle a1, Angle a2) =>
            a1.radians <= a2.radians;

        /// <summary>
        /// Indicates whether a specified Angle is greater than another specified Angle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than the value of a2; otherwise, false.</returns>
        public static bool operator >(Angle a1, Angle a2) =>
            a1.radians > a2.radians;

        /// <summary>
        /// Indicates whether a specified Angle is greater than or equal to another specified Angle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator >=(Angle a1, Angle a2) =>
            a1.radians >= a2.radians;

        /// <summary>
        /// Compares two Angle values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int Compare(Angle a1, Angle a2) =>
            Compare(a1.radians, a2.radians);

        /// <summary>
        /// Compares two Angle values and returns an integer that indicates whether when both reduced the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int CompareReduced(Angle a1, Angle a2) =>
            Compare(Reduce(a1.radians), Reduce(a2.radians));

        /// <summary>
        /// Compares this instance to a specified Angle object and returns an integer that indicates whether this instance is shorter than, equal to, or longer than the Angle object.
        /// </summary>
        /// <param name="value">An object to compare to this instance.</param>
        /// <returns>-1 if a1 is smaller than a2; 0 if a1 equals to a2; 1 if a1 is larger than a2.</returns>
        /// <remarks>This method implements the System.IComparable&lt;T&gt; interface, and performs slightly better than <see cref="Angle.CompareTo(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public int CompareTo(Angle value) => 
            radians.CompareTo(value.radians);

        /// <summary>
        /// Compares this instance to a specified Angle object and returns an integer that indicates whether this instance is shorter than, equal to, or longer than the Angle object.
        /// </summary>
        /// <param name="obj">An object to compare to this instance.</param>
        /// <returns>-1 if a1 is smaller than a2; 0 if a1 equals to a2; 1 if a1 is larger than a2.</returns>
        /// <exception cref="ArgumentException">value is not an Angle.</exception>
        public int CompareTo(object obj)
        {
            switch (obj)
            {
                case Angle angle:
                    return this.CompareTo(angle);
                default:
                    throw new ArgumentException("Argument has to be an Angle.", nameof(obj));
            }
        }

        static int Compare(double d1, double d2) => 
            d1.CompareTo(d2);

#endregion

        #region negation

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static Angle operator -(Angle angle) =>
            new Angle(-angle.radians);

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <param name="result"></param>
        public static void Negate(ref Angle angle, out Angle result)
        {
            result = new Angle(-angle.radians);
        }

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static Angle Negate(Angle angle) =>
            new Angle(-angle.radians);

#endregion

#region addition

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static Angle operator +(Angle left, Angle right) =>
            new Angle(left.radians + right.radians);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <param name="result">Result of the addition.</param>
        public static void Add(ref Angle left, ref Angle right, out Angle result)
        {
            result = new Angle(left.radians + right.radians);
        }

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static Angle Add(Angle left, Angle right) =>
            new Angle(left.radians + right.radians);

#endregion

#region subtraction

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static Angle operator -(Angle left, Angle right) =>
            new Angle(left.radians - right.radians);

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <param name="result">Result of the subtraction.</param>
        public static void Subtract(ref Angle left, ref Angle right, out Angle result)
        {
            result = new Angle(left.radians - right.radians);
        }

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static Angle Subtract(Angle left, Angle right) =>
            new Angle(left.radians - right.radians);

#endregion

#region multiplication

        /// <summary>
        /// Multiplies a scalar by an angle value. 
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static Angle operator *(double left, Angle right) =>
            new Angle(left * right.radians);

        /// <summary>
        /// Multiplies a angle by a scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <param name="result">Result of the multiplication.</param>
        public static void Multiply(ref double left, ref Angle right, out Angle result)
        {
            result = new Angle(left * right.radians);
        }

        /// <summary>
        /// Multiplies a angle by a scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static Angle Multiply(double left, Angle right) =>
            new Angle(left * right.radians);

#endregion

#region division

        /// <summary>
        /// Divides a angle by a scalar value. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static Angle operator /(Angle left, double right) =>
            new Angle(left.radians / right);

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <param name="result">Result of the division.</param>
        public static void Divide(ref Angle left, ref double right, out Angle result)
        {
            result = new Angle(left.radians / right);
        }

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static Angle Divide(Angle left, double right) =>
            new Angle(left.radians / right);

#endregion

#region string format

        /// <summary>
        /// Converts the value of the current Angle object to its equivalent string representation, using a specified format.
        /// </summary>
        /// <param name="format">A string that specifies the format to be used for the returned string.</param>
        /// <returns>A string representation of the value of the current Angle object, in the specified format.</returns>
        public string ToString(string format)
        {
            return FormatString(format, null);
        }

        /// <summary>
        /// Converts the value of the current Angle object to its equivalent string representation using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current Angle object as specified by format and provider.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return FormatString(format, formatProvider);
        }

        string FormatString(string format, IFormatProvider formatProvider)
        {
            if (format == null || format.Length == 0)
                format = "R";

            format = format.Trim().ToUpper();

            var doubleFormat = "G";
            if (format.Length > 1)
                doubleFormat = "N" + format.Substring(1);

            switch (format[0])
            {
                case 'R':
                    return ToRadians().ToString(doubleFormat, formatProvider);
                case 'D':
                    return ToDegrees().ToString(doubleFormat, formatProvider) + "°";
                case 'M':
                    {
                        ToDegrees(out int degrees, out double minutes);
                        return degrees.ToString("G", formatProvider) + "° " +
                            minutes.ToString(doubleFormat, formatProvider) + "'";
                    }
                case 'S':
                    {
                        ToDegrees(out int degrees, out int minutes, out double seconds);
                        return degrees.ToString("G", formatProvider) + "° " +
                            minutes.ToString("G", formatProvider) + "' " +
                            seconds.ToString(doubleFormat, formatProvider) + "\"";
                    }
                case 'G':
                    return ToGradians().ToString(doubleFormat, formatProvider);
                default:
                    throw new FormatException("The '" + format + "' format string is not supported.");
            }
            throw new InvalidOperationException();
        }

#endregion

#region object overrides

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>true if value is a Angle object that represents the same angle as the current Angle structure; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            switch(obj)
            {
                case Angle angle:
                    return this.Equals(angle);
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
            return radians.GetHashCode();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return ToString(null);
        }

#endregion

        static bool AproximatelyEquals(double x, double y, double acceptableVariance) =>
            Math.Abs(x - y) < acceptableVariance;

    }
}
