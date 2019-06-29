using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Performs a linear interpolation.
        /// </summary>
        /// <param name="a1">The first angle.</param>
        /// <param name="a2">The second angle.</param>
        /// <param name="t">A value that linearly interpolates between the a1 parameter and the a2 parameter.</param>
        /// <returns>The result of the linear interpolation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegrees Lerp(AngleDegrees a1, AngleDegrees a2, double t) =>
            new AngleDegrees(Utils.Lerp(a1.Degrees, a2.Degrees, t));

        /// <summary>
        /// Performs a linear interpolation.
        /// </summary>
        /// <param name="a1">The first angle.</param>
        /// <param name="a2">The second angle.</param>
        /// <param name="t">A value that linearly interpolates between the a1 parameter and the a2 parameter.</param>
        /// <returns>The result of the linear interpolation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegreesMinutes Lerp(in AngleDegreesMinutes a1, in AngleDegreesMinutes a2, double t) =>
            new AngleDegreesMinutes(Utils.Lerp(AngleDegreesMinutes.GetDegreesAngle(a1), AngleDegreesMinutes.GetDegreesAngle(a2), t));

        /// <summary>
        /// Performs a linear interpolation.
        /// </summary>
        /// <param name="a1">The first angle.</param>
        /// <param name="a2">The second angle.</param>
        /// <param name="t">A value that linearly interpolates between the a1 parameter and the a2 parameter.</param>
        /// <returns>The result of the linear interpolation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegreesMinutesSeconds Lerp(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2, double t) =>
            new AngleDegreesMinutesSeconds(Utils.Lerp(AngleDegreesMinutesSeconds.GetDegreesAngle(a1), AngleDegreesMinutesSeconds.GetDegreesAngle(a2), t));

        /// <summary>
        /// Performs a linear interpolation.
        /// </summary>
        /// <param name="a1">The first angle.</param>
        /// <param name="a2">The second angle.</param>
        /// <param name="t">A value that linearly interpolates between the a1 parameter and the a2 parameter.</param>
        /// <returns>The result of the linear interpolation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleGradians Lerp(AngleGradians a1, AngleGradians a2, double t) =>
            new AngleGradians(Utils.Lerp(a1.Gradians, a2.Gradians, t));

        /// <summary>
        /// Performs a linear interpolation.
        /// </summary>
        /// <param name="a1">The first angle.</param>
        /// <param name="a2">The second angle.</param>
        /// <param name="t">A value that linearly interpolates between the a1 parameter and the a2 parameter.</param>
        /// <returns>The result of the linear interpolation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians Lerp(AngleRadians a1, AngleRadians a2, double t) =>
            new AngleRadians(Utils.Lerp(a1.Radians, a2.Radians, t));

        /// <summary>
        /// Performs a linear interpolation.
        /// </summary>
        /// <param name="a1">The first angle.</param>
        /// <param name="a2">The second angle.</param>
        /// <param name="t">A value that linearly interpolates between the a1 parameter and the a2 parameter.</param>
        /// <returns>The result of the linear interpolation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRevolutions Lerp(AngleRevolutions a1, AngleRevolutions a2, double t) =>
            new AngleRevolutions(Utils.Lerp(a1.Revolutions, a2.Revolutions, t));
    }
}
