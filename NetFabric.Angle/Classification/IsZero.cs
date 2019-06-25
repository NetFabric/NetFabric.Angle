using System;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Indicates whether the specified angle is equal to Zero when reduced.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is zero; otherwise false.</returns>
        public static bool IsZero(AngleDegrees angle) =>
            angle.Degrees % AngleDegrees.FullAngle == 0.0;

        /// <summary>
        /// Indicates whether the specified angle is equal to Zero when reduced.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is zero; otherwise false.</returns>
        public static bool IsZero(in AngleDegreesMinutes angle) =>
            angle.Minutes == 0.0 && angle.Degrees % AngleDegreesMinutes.FullAngle == 0;

        /// <summary>
        /// Indicates whether the specified angle is equal to Zero when reduced.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is zero; otherwise false.</returns>
        public static bool IsZero(in AngleDegreesMinutesSeconds angle) =>
            angle.Minutes == 0.0 && angle.Degrees % AngleDegreesMinutesSeconds.FullAngle == 0;

        /// <summary>
        /// Indicates whether the specified angle is equal to Zero when reduced.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is zero; otherwise false.</returns>
        public static bool IsZero(AngleGradians angle) =>
            angle.Gradians % AngleGradians.FullAngle == 0.0;

        /// <summary>
        /// Indicates whether the specified angle is equal to Zero when reduced.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is zero; otherwise false.</returns>
        public static bool IsZero(AngleRadians angle) =>
            angle.Radians % AngleRadians.FullAngle == 0.0;

        /// <summary>
        /// Indicates whether the specified angle is equal to Zero when reduced.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is zero; otherwise false.</returns>
        public static bool IsZero(AngleRevolutions angle) =>
            angle.Revolutions % AngleRevolutions.FullAngle == 0.0;
    }
}
