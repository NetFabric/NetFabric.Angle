using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace NetFabric
{
    [DebuggerDisplay("Degrees = {TotalDegrees}")]
    public struct Angle
        : IEquatable<Angle>
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
        /// <remarks>This method implements the <see cref="System.IEquatable<T>"/> interface, and performs slightly better than <see cref="Equals"/> because it does not have to convert the obj parameter to an object.</remarks>
        public bool Equals(Angle obj)
        {
            return radians == obj.radians;
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
