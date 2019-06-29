using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Indicates whether the specified angle is acute.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than zero and less than 90 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAcute(AngleDegrees angle)
        {
            var reduced = AngleDegrees.Reduce(Math.Abs(angle.Degrees));
            return reduced > 0.0 && reduced < AngleDegrees.RightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is acute.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than zero and less than 90 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAcute(in AngleDegreesMinutes angle) =>
            AngleDegreesMinutes.InRangeReduced(angle, 0, AngleDegreesMinutes.RightAngle);

        /// <summary>
        /// Indicates whether the specified angle is acute.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than zero and less than 90 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAcute(in AngleDegreesMinutesSeconds angle) =>
            AngleDegreesMinutesSeconds.InRangeReduced(Angle.Abs(angle), AngleDegreesMinutesSeconds.Zero, AngleDegreesMinutesSeconds.Right);

        /// <summary>
        /// Indicates whether the specified angle is acute.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than zero and less than 90 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAcute(AngleGradians angle)
        {
            var reduced = AngleGradians.Reduce(Math.Abs(angle.Gradians));
            return reduced > 0.0 && reduced < AngleGradians.RightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is acute.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than zero and less than 90 degrees; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAcute(AngleRadians angle)
        {
            var reduced = AngleRadians.Reduce(Math.Abs(angle.Radians));
            return reduced > 0.0 && reduced < AngleRadians.RightAngle;
        }

        /// <summary>
        /// Indicates whether the specified angle is acute.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>true if the reduction of the absolute angle is greater than zero and less than 90 revolutions; otherwise false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAcute(AngleRevolutions angle)
        {
            var reduced = AngleRevolutions.Reduce(Math.Abs(angle.Revolutions));
            return reduced > 0.0 && reduced < AngleRevolutions.RightAngle;
        }
    }
}
