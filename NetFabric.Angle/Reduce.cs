using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegrees Reduce(AngleDegrees angle) =>
                new AngleDegrees(AngleDegrees.Reduce(angle.Degrees));

        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegreesMinutes Reduce(in AngleDegreesMinutes angle) =>
            new AngleDegreesMinutes(AngleDegrees.Reduce(AngleDegreesMinutes.GetDegreesAngle(angle)));

        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegreesMinutesSeconds Reduce(in AngleDegreesMinutesSeconds angle) =>
            AngleDegreesMinutesSeconds.Reduce(angle);

        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleGradians Reduce(AngleGradians angle) =>
            new AngleGradians(AngleGradians.Reduce(angle.Gradians));

        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians Reduce(AngleRadians angle) =>
            new AngleRadians(AngleRadians.Reduce(angle.Radians));

        /// <summary>
        /// Reduce an angle between 0 and 2π.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRevolutions Reduce(AngleRevolutions angle) =>
            new AngleRevolutions(AngleRevolutions.Reduce(angle.Revolutions));


    }
}
