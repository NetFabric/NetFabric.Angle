using System;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Indicates whether the specified angle is straight.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 180 degrees; otherwise false.</returns>
        public static bool IsStraight(AngleDegrees angle) =>
            AngleDegrees.Reduce(Math.Abs(angle.Degrees)) == AngleDegrees.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is straight.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 180 degrees; otherwise false.</returns>
        public static bool IsStraight(in AngleDegreesMinutes angle) =>
            AngleDegreesMinutes.EqualsReduced(angle, AngleDegreesMinutes.StraightAngle);

        /// <summary>
        /// Indicates whether the specified angle is straight.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 180 degrees; otherwise false.</returns>
        public static bool IsStraight(in AngleDegreesMinutesSeconds angle) =>
            AngleDegreesMinutesSeconds.EqualsReduced(Angle.Abs(angle), AngleDegreesMinutesSeconds.Straight);

        /// <summary>
        /// Indicates whether the specified angle is straight.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 180 degrees; otherwise false.</returns>
        public static bool IsStraight(AngleGradians angle) =>
            AngleGradians.Reduce(Math.Abs(angle.Gradians)) == AngleGradians.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is straight.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 180 degrees; otherwise false.</returns>
        public static bool IsStraight(AngleRadians angle) =>
            AngleRadians.Reduce(Math.Abs(angle.Radians)) == AngleRadians.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is straight.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 180 revolutions; otherwise false.</returns>
        public static bool IsStraight(AngleRevolutions angle) =>
            AngleRevolutions.Reduce(Math.Abs(angle.Revolutions)) == AngleRevolutions.StraightAngle;
    }
}
