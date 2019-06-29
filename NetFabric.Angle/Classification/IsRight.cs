using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Indicates whether the specified angle is right.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 90 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsRight(AngleDegrees angle) =>
            AngleDegrees.Reduce(Math.Abs(angle.Degrees)) == AngleDegrees.RightAngle;

        /// <summary>
        /// Indicates whether the specified angle is right.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 90 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsRight(in AngleDegreesMinutes angle) =>
            AngleDegreesMinutes.EqualsReduced(angle, AngleDegreesMinutes.RightAngle);

        /// <summary>
        /// Indicates whether the specified angle is right.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 90 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsRight(in AngleDegreesMinutesSeconds angle) =>
            AngleDegreesMinutesSeconds.EqualsReduced(Angle.Abs(angle), AngleDegreesMinutesSeconds.Right);

        /// <summary>
        /// Indicates whether the specified angle is right.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 90 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsRight(AngleGradians angle) =>
            AngleGradians.Reduce(Math.Abs(angle.Gradians)) == AngleGradians.RightAngle;

        /// <summary>
        /// Indicates whether the specified angle is right.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 90 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsRight(AngleRadians angle) =>
            AngleRadians.Reduce(Math.Abs(angle.Radians)) == AngleRadians.RightAngle;

        /// <summary>
        /// Indicates whether the specified angle is right.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is 90 revolutions; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsRight(AngleRevolutions angle) =>
            AngleRevolutions.Reduce(Math.Abs(angle.Revolutions)) == AngleRevolutions.RightAngle;
    }
}
