using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace NetFabric
{
    [DebuggerDisplay("Degrees = {TotalDegrees}")]
    public struct Angle
        : IEquatable<Angle>
        , IComparable
        , IComparable<Angle>
    {
        double radians;

        const double RightAngle = System.Math.PI * 0.5;
        const double StraightAngle = System.Math.PI;
        const double FullAngle = System.Math.PI * 2.0;

        const double ToDegrees = 360.0 / FullAngle;
        const double ToGradians = 400.0 / FullAngle;

        /// <summary>
        /// Represents the zero Angle value (0 degrees). This field is read-only.
        /// </summary>
        public static readonly Angle Zero = new Angle(0.0);

        /// <summary>
        /// Represents the a2 Angle value (90 degrees). This field is read-only.
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
            return new Angle(value / ToDegrees);
        }

        /// <summary>
        /// Returns an Angle that represents a specified number of gradians.
        /// </summary>
        /// <param name="value">A number of gradians.</param>
        /// <returns>An object that represents value.</returns>
        public static Angle FromGradians(double value)
        {
            return new Angle(value / ToGradians);
        }

        /// <summary>
        /// Gets the value of the current Angle structure expressed in whole and fractional radians.
        /// </summary>
        public double TotalRadians
        {
            get
            {
                return radians;
            }
        }

        /// <summary>
        /// Gets the value of the current Angle structure expressed in whole and fractional degrees.
        /// </summary>
        public double TotalDegrees
        {
            get
            {
                return radians * ToDegrees;
            }
        }

        /// <summary>
        /// Gets the value of the current Angle structure expressed in whole and fractional gradians.
        /// </summary>
        public double TotalGradians
        {
            get
            {
                return radians * ToGradians;
            }
        }

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

        #endregion
    }
}
