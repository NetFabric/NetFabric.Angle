using System;

namespace NetFabric
{
    public static partial class Angle
    { 
        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns></returns>
        public static AngleDegrees Reduce(AngleDegrees angle) =>
                new AngleDegrees(AngleDegrees.Reduce(angle.Degrees));

        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns></returns>
        public static AngleDegreesMinutes Reduce(in AngleDegreesMinutes angle) =>
            new AngleDegreesMinutes(AngleDegrees.Reduce(AngleDegreesMinutes.GetDegreesAngle(angle)));

        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns></returns>
        public static AngleDegreesMinutesSeconds Reduce(in AngleDegreesMinutesSeconds angle) =>
            AngleDegreesMinutesSeconds.Reduce(angle);

        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns></returns>
        public static AngleGradians Reduce(AngleGradians angle) =>
            new AngleGradians(AngleGradians.Reduce(angle.Gradians));

        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns></returns>
        public static AngleRadians Reduce(AngleRadians angle) =>
            new AngleRadians(AngleRadians.Reduce(angle.Radians));

        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns></returns>
        public static AngleRevolutions Reduce(AngleRevolutions angle) =>
            new AngleRevolutions(AngleRevolutions.Reduce(angle.Revolutions));


    }
}
