using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Indicates whether the specified angle is obtuse.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 90 degrees and less than 180 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsObtuse(AngleDegrees angle)
        {
            var reduced = AngleDegrees.Reduce(Math.Abs(angle.Degrees));
            return reduced > AngleDegrees.RightAngle && reduced < AngleDegrees.StraightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is obtuse.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 90 degrees and less than 180 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsObtuse(in AngleDegreesMinutes angle) =>
            AngleDegreesMinutes.InRangeReduced(angle, AngleDegreesMinutes.RightAngle, AngleDegreesMinutes.StraightAngle);

        /// <summary>
        /// Indicates whether the specified angle is obtuse.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 90 degrees and less than 180 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsObtuse(in AngleDegreesMinutesSeconds angle) =>
            AngleDegreesMinutesSeconds.InRangeReduced(Angle.Abs(angle), AngleDegreesMinutesSeconds.Right, AngleDegreesMinutesSeconds.Straight);

        /// <summary>
        /// Indicates whether the specified angle is obtuse.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 90 degrees and less than 180 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsObtuse(AngleGradians angle)
        {
            var reduced = AngleGradians.Reduce(Math.Abs(angle.Gradians));
            return reduced > AngleGradians.RightAngle && reduced < AngleGradians.StraightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is obtuse.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 90 degrees and less than 180 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsObtuse(AngleRadians angle)
        {
            var reduced = AngleRadians.Reduce(Math.Abs(angle.Radians));
            return reduced > AngleRadians.RightAngle && reduced < AngleRadians.StraightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is obtuse.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than 90 revolutions and less than 180 revolutions; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsObtuse(AngleRevolutions angle)
        {
            var reduced = AngleRevolutions.Reduce(Math.Abs(angle.Revolutions));
            return reduced > AngleRevolutions.RightAngle && reduced < AngleRevolutions.StraightAngle;
        }
    }
}
