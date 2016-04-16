using System;
using System.Diagnostics;

namespace NetFabric
{
    public struct Angle
        : IEquatable<Angle>
        , IComparable
        , IComparable<Angle>
    {
        public enum Quadrant
        {
            First,
            Second,
            Third,
            Fourth
        }

        double radians;

        const double RightAngle = System.Math.PI * 0.5;
        const double StraightAngle = System.Math.PI;
        const double FullAngle = System.Math.PI * 2.0;

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
        public static Angle FromRadians(double value)
        {
            return new Angle(value);
        }

        /// <summary>
        /// Returns an Angle that represents a specified number of degrees.
        /// </summary>
        /// <param name="value">A number of degrees.</param>
        /// <returns>An object that represents value.</returns>
        public static Angle FromDegrees(double value)
        {
            return new Angle(value / DegreesByRadians);
        }

        /// <summary>
        /// Returns an Angle that represents a specified number of degrees and minutes.
        /// </summary>
        /// <param name="degrees">The degrees parcel of the angle value.</param>
        /// <param name="minutes">The minutes parcel of the angle value.</param>
        /// <returns>An object that represents value.</returns>
        public static Angle FromDegrees(int degrees, double minutes)
        {
            if (minutes < 0.0 || minutes >= 60.0)
                throw new ArgumentOutOfRangeException("minutes", minutes, "Argument must be positive and less than 60.");

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
                throw new ArgumentOutOfRangeException("minutes", minutes, "Argument must be positive and less than 60.");
            if (seconds < 0.0 || seconds >= 60.0)
                throw new ArgumentOutOfRangeException("seconds", seconds, "Argument must be positive and less than 60.");

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
        public static Angle FromGradians(double value)
        {
            return new Angle(value / GradiansByRadians);
        }

        /// <summary>
        /// Gets the value of the current Angle structure expressed in whole and fractional radians.
        /// </summary
        public double ToRadians()
        {
            return radians;
        }

        /// <summary>
        /// Gets the value of the current Angle structure expressed in whole and fractional degrees.
        /// </summary>
        public double ToDegrees()
        {
            return radians * DegreesByRadians;
        }

        /// <summary>
        /// Gets the value of the current Angle structure expressed in degrees and minutes.
        /// </summary>
        /// <param name="degress"></param>
        /// <param name="minutes"></param>
        public void ToDegrees(out int degress, out double minutes)
        {
            var decimalDegrees = radians * DegreesByRadians;
            degress = (int)decimalDegrees;
            minutes = Math.Abs(decimalDegrees - degress) * 60.0;
        }

        /// <summary>
        /// Gets the value of the current Angle structure expressed in degrees, minutes and seconds.
        /// </summary>
        /// <param name="degress"></param>
        /// <param name="minutes"></param>
        public void ToDegrees(out int degress, out int minutes, out double seconds)
        {
            var decimalDegrees = radians * DegreesByRadians;
            degress = (int)decimalDegrees;
            var decimalMinutes = Math.Abs(decimalDegrees - degress) * 60.0;
            minutes = (int)decimalMinutes;
            seconds = (decimalMinutes - minutes) * 60.0;
        }

        /// <summary>
        /// Gets the value of the current Angle structure expressed in whole and fractional gradians.
        /// </summary>
        public double ToGradians()
        {
            return radians * GradiansByRadians;
        }

        /// <summary>
        /// Returns the absolute value of the Angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>
        /// An Angle, x, such that Angle.Zero <= x <= Angle.MaxValue.
        /// </returns>
        public static Angle Abs(Angle angle)
        {
            return new Angle(Math.Abs(angle.radians));
        }

        /// <summary>
        /// Returns a value indicating the sign of an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>A number that indicates the sign of value, -1 if value is less than zero, 0 if value equal to zero, 1 if value is grater than zero.</returns>
        public static int Sign(Angle angle)
        {
            return Math.Sign(angle.radians);
        }

        /// <summary>
        /// Returns the smaller of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns></returns>
        public static Angle Min(Angle left, Angle right)
        {
            return left.radians < right.radians ? left : right;
        }

        /// <summary>
        /// Returns the largest of two angles.
        /// </summary>
        /// <param name="left">The first of two angles to compare.</param>
        /// <param name="right">The second of two angles to compare.</param>
        /// <returns></returns>
        public static Angle Max(Angle left, Angle right)
        {
            return left.radians > right.radians ? left : right;
        }

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
        public static bool IsRight(Angle angle)
        {
            return Reduce(Math.Abs(angle.radians)) == RightAngle;
        }

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
        public static bool IsStraight(Angle angle)
        {
            return Reduce(Math.Abs(angle.radians)) == StraightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 degrees and less than 360 degrees; otherwise false.</returns>
        public static bool IsReflex(Angle angle)
        {
            return Reduce(Math.Abs(angle.radians)) > StraightAngle;
        }

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
        /// Returns the quadrant the angle is in.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>The quadrant the angle is in.</returns>
        public static Quadrant GetQuadrant(Angle angle)
        {
            return GetQuadrant(Reduce(angle.radians));
        }

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
        public static double Sin(Angle angle)
        {
            return System.Math.Sin(angle.radians);
        }

        /// <summary>
        /// Returns the hyperbolic sine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The hyperbolic sine of value. If value is equal to NegativeInfinity, PositiveInfinity, or NaN, this method returns an Angle equal to value.</returns>
        public static double Sinh(Angle angle)
        {
            return System.Math.Sinh(angle.radians);
        }

        /// <summary>
        /// Returns the angle whose sine is the specified number.
        /// </summary>
        /// <param name="value">A number representing a sine, where value must be greater than or equal to -1, but less than or equal to 1.</param>
        /// <returns>The angle whose sine is the specified number.</returns>
        public static Angle Asin(double value)
        {
            if (value < -1.0 || value > 1.0)
                throw new ArgumentOutOfRangeException("value", value, "Argument must be greater or equal to -1.0 and less or equal to 1.0.");

            return new Angle(System.Math.Asin(value));
        }

        /// <summary>
        /// Return the cosine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The cosine of the specified angle. If angle is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</returns>
        public static double Cos(Angle angle)
        {
            return System.Math.Cos(angle.radians);
        }

        /// <summary>
        /// Returns the hyperbolic cosine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The hyperbolic cosine of value. If value is equal to NegativeInfinity, PositiveInfinity, or NaN, this method returns an Angle equal to value.</returns>
        public static double Cosh(Angle angle)
        {
            return System.Math.Cosh(angle.radians);
        }

        /// <summary>
        /// Returns the angle whose cosine is the specified number.
        /// </summary>
        /// <param name="value">A number representing a cosine, where value must be greater than or equal to -1, but less than or equal to 1.</param>
        /// <returns>The angle whose cosine is the specified number.</returns>
        public static Angle Acos(double value)
        {
            if (value < -1.0 || value > 1.0)
                throw new ArgumentOutOfRangeException("value", value, "Argument must be greater or equal to -1.0 and less or equal to 1.0.");

            return new Angle(System.Math.Acos(value));
        }

        /// <summary>
        /// Returns the tangent of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The tangent of the specified angle. If angle is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</returns>
        public static double Tan(Angle angle)
        {
            return System.Math.Tan(angle.radians);
        }

        /// <summary>
        /// Returns the angle whose tangent is the specified number.
        /// </summary>
        /// <param name="value">A number representing a tangent.</param>
        /// <returns>The angle whose tangent is the specified number.</returns>
        public static Angle Atan(double value)
        {
            return new Angle(System.Math.Atan(value));
        }

        /// <summary>
        /// Returns the angle whose tangent is the quotient of two specified numbers.
        /// </summary>
        /// <param name="x">The y coordinate of a point.</param>
        /// <param name="y">The x coordinate of a point.</param>
        /// <returns>The angle whose tangent is the quotient of two specified numbers.</returns>
        public static Angle Atan2(double y, double x)
        {
            return new Angle(System.Math.Atan2(y, x));
        }

#endregion

#region equality implementation

        /// <summary>
        /// Indicates whether two Angle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator ==(Angle a1, Angle a2)
        {
            return a1.radians == a2.radians;
        }

        /// <summary>
        /// Indicates whether two Angle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool operator !=(Angle a1, Angle a2)
        {
            return a1.radians != a2.radians;
        }

        /// <summary>
        /// Indicates whether two Angle instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool Equals(Angle a1, Angle a2)
        {
            return a1.radians == a2.radians;
        }

        /// <summary>
        /// Indicates whether whether this instance is equal to a specified Angle object.
        /// </summary>
        /// <param name="obj">An Angle to compare with this instance.</param>
        /// <returns>true if obj represents the same angle as this instance; otherwise, false.</returns>
        /// <remarks>This method implements the <see cref="System.IEquatable<T>"/> interface, and performs slightly better than <see cref="Angle.Equals(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public bool Equals(Angle obj)
        {
            return radians == obj.radians;
        }

#endregion

#region comparison implementation

        /// <summary>
        /// Indicates whether a specified Angle is less than another specified Angle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than the value of a2; otherwise, false.</returns>
        public static bool operator <(Angle a1, Angle a2)
        {
            return a1.radians < a2.radians;
        }

        /// <summary>
        /// Indicates whether a specified Angle is less than or equal to another specified Angle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is less than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator <=(Angle a1, Angle a2)
        {
            return a1.radians <= a2.radians;
        }

        /// <summary>
        /// Indicates whether a specified Angle is greater than another specified Angle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than the value of a2; otherwise, false.</returns>
        public static bool operator >(Angle a1, Angle a2)
        {
            return a1.radians > a2.radians;
        }

        /// <summary>
        /// Indicates whether a specified Angle is greater than or equal to another specified Angle.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the value of a1 is greater than or equal to the value of a2; otherwise, false.</returns>
        public static bool operator >=(Angle a1, Angle a2)
        {
            return a1.radians >= a2.radians;
        }

        /// <summary>
        /// Compares two Angle values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int Compare(Angle a1, Angle a2)
        {
            return a1.radians.CompareTo(a2.radians);
        }

        /// <summary>
        /// Compares two Angle values and returns an integer that indicates whether when both reduced the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int CompareReduced(Angle a1, Angle a2)
        {
            return Reduce(a1.radians).CompareTo(Reduce(a2.radians));
        }

        /// <summary>
        /// Compares this instance to a specified Angle object and returns an integer that indicates whether this instance is shorter than, equal to, or longer than the Angle object.
        /// </summary>
        /// <param name="value">An object to compare to this instance.</param>
        /// <returns>-1 if a1 is smaller than a2; 0 if a1 equals to a2; 1 if a1 is larger than a2.</returns>
        /// <remarks>This method implements the <see cref="System.IComparable<T>"/> interface, and performs slightly better than <see cref="Angle.CompareTo(object)"/> because it does not have to convert the obj parameter to an object.</remarks>
        public int CompareTo(Angle value)
        {
            return radians.CompareTo(value.radians);
        }

        /// <summary>
        /// Compares this instance to a specified Angle object and returns an integer that indicates whether this instance is shorter than, equal to, or longer than the Angle object.
        /// </summary>
        /// <param name="value">An object to compare to this instance.</param>
        /// <returns>-1 if a1 is smaller than a2; 0 if a1 equals to a2; 1 if a1 is larger than a2.</returns>
        /// <exception cref="ArgumentException">value is not an Angle.</exception>
        public int CompareTo(object obj)
        {
            if (!(obj is Angle))
                throw new ArgumentException("Argument has to be an Angle.", "value");
            return this.CompareTo((Angle)obj);
        }

#endregion

#region negation

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static Angle operator -(Angle angle)
        {
            return new Angle(-angle.radians);
        }

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
        public static Angle Negate(Angle angle)
        {
            return new Angle(-angle.radians);
        }


#endregion

#region addition

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static Angle operator +(Angle left, Angle right)
        {
            return new Angle(left.radians + right.radians);
        }

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
        public static Angle Add(Angle left, Angle right)
        {
            return new Angle(left.radians + right.radians);
        }

#endregion

#region subtraction

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static Angle operator -(Angle left, Angle right)
        {
            return new Angle(left.radians - right.radians);
        }

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
        public static Angle Subtract(Angle left, Angle right)
        {
            return new Angle(left.radians - right.radians);
        }

#endregion

#region multiplication

        /// <summary>
        /// Multiplies a scalar by an angle value. 
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static Angle operator *(double left, Angle right)
        {
            return new Angle(left * right.radians);
        }

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
        public static Angle Multiply(double left, Angle right)
        {
            return new Angle(left * right.radians);
        }

#endregion

#region division

        /// <summary>
        /// Divides a angle by a scalar value. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static Angle operator /(Angle left, double right)
        {
            return new Angle(left.radians / right);
        }

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
        public static Angle Divide(Angle left, double right)
        {
            return new Angle(left.radians / right);
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
            if (!(obj is Angle))
                return false;
            return this.Equals((Angle)obj);
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
            return radians.ToString();
        }

#endregion
    }
}
