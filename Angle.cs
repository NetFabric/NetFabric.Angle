using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace NetFabric
{
    [DebuggerDisplay("Degrees = {TotalDegrees}")]
    public struct Angle
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
    }
}
