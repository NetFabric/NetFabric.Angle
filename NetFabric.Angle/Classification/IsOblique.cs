using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Indicates whether the specified angle is oblique.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the angle is not right or a multiple of a right angle; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOblique(AngleDegrees angle) =>
            angle.Degrees % AngleDegrees.RightAngle != 0.0;

        /// <summary>
        /// Indicates whether the specified angle is oblique.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the angle is not right or a multiple of a right angle; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOblique(in AngleDegreesMinutes angle) =>
            angle.Minutes != 0.0 || angle.Degrees % AngleDegreesMinutes.RightAngle != 0.0;

        /// <summary>
        /// Indicates whether the specified angle is oblique.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the angle is not right or a multiple of a right angle; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOblique(in AngleDegreesMinutesSeconds angle) =>
            angle.Minutes != 0.0 || angle.Seconds != 0.0 || angle.Degrees % AngleDegreesMinutesSeconds.RightAngle != 0.0;

        /// <summary>
        /// Indicates whether the specified angle is oblique.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the angle is not right or a multiple of a right angle; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOblique(AngleGradians angle) =>
            angle.Gradians % AngleGradians.RightAngle != 0.0;

        /// <summary>
        /// Indicates whether the specified angle is oblique.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the angle is not right or a multiple of a right angle; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOblique(AngleRadians angle) =>
            angle.Radians % AngleRadians.RightAngle != 0.0;

        /// <summary>
        /// Indicates whether the specified angle is oblique.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the angle is not right or a multiple of a right angle; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOblique(AngleRevolutions angle) =>
            angle.Revolutions % AngleRevolutions.RightAngle != 0.0;
    }
}
