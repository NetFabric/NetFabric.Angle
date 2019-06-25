using System;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleDegrees Negate(AngleDegrees angle) =>
            new AngleDegrees(-angle.Degrees);

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleDegreesMinutes Negate(in AngleDegreesMinutes angle) =>
            -angle;

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleDegreesMinutesSeconds Negate(in AngleDegreesMinutesSeconds angle) =>
            -angle;

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleGradians Negate(AngleGradians angle) =>
            new AngleGradians(-angle.Gradians);

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleRadians Negate(AngleRadians angle) =>
            new AngleRadians(-angle.Radians);

        /// <summary>
        /// Negates an angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>Result of the negation.</returns>
        public static AngleRevolutions Negate(AngleRevolutions angle) =>
            new AngleRevolutions(-angle.Revolutions);
    }
}
