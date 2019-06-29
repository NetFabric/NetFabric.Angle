using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 degrees and less than 360 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsReflex(AngleDegrees angle) =>
            AngleDegrees.Reduce(Math.Abs(angle.Degrees)) > AngleDegrees.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 degrees and less than 360 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsReflex(in AngleDegreesMinutes angle) =>
            AngleDegreesMinutes.GreaterThanReduced(angle, AngleDegreesMinutes.StraightAngle);

        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 degrees and less than 360 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsReflex(in AngleDegreesMinutesSeconds angle) =>
            AngleDegreesMinutesSeconds.GreaterThanReduced(Angle.Abs(angle), AngleDegreesMinutesSeconds.Straight);

        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 degrees and less than 360 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsReflex(AngleGradians angle) =>
            AngleGradians.Reduce(Math.Abs(angle.Gradians)) > AngleGradians.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 degrees and less than 360 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsReflex(AngleRadians angle) =>
            AngleRadians.Reduce(Math.Abs(angle.Radians)) > AngleRadians.StraightAngle;

        /// <summary>
        /// Indicates whether the specified angle is reflex.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 180 revolutions and less than 360 revolutions; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsReflex(AngleRevolutions angle) =>
            AngleRevolutions.Reduce(Math.Abs(angle.Revolutions)) > AngleRevolutions.StraightAngle;
    }
}
