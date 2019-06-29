using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Returns an DegreessAngle that represents a specified number of degrees.
        /// </summary>
        /// <param name="value">A number of degrees.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegrees InDegrees(double value) =>
            new AngleDegrees(value);

        /// <summary>
        /// Returns an AngleDegrees that represents the equivalent to the AngleRadians.
        /// </summary>
        /// <param name="angle">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegrees InDegrees(AngleRadians angle) =>
            new AngleDegrees(angle.Radians * DegreesInRadians);

        /// <summary>
        /// Returns an AngleDegrees that represents the equivalent to the AngleDegreesMinutes.
        /// </summary>
        /// <param name = "angle" > An angle in degrees and minutes.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegrees InDegrees(in AngleDegreesMinutes angle) =>
            new AngleDegrees(AngleDegreesMinutes.GetDegreesAngle(angle));

        /// <summary>
        /// Returns an AngleDegrees that represents the equivalent to the AngleDegreesMinutesSeconds.
        /// </summary>
        /// <param name = "angle" > An angle in degrees, minutes and seconds.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegrees InDegrees(in AngleDegreesMinutesSeconds angle) =>
            new AngleDegrees(AngleDegreesMinutesSeconds.GetDegreesAngle(angle));

        /// <summary>
        /// Returns an AngleDegrees that represents the equivalent to the AngleGradians.
        /// </summary>
        /// <param name="angle">An angle in gradians.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegrees InDegrees(AngleGradians angle) =>
            new AngleDegrees(angle.Gradians / GradiansInDegrees);

        /// <summary>
        /// Returns an AngleDegrees that represents the equivalent to the AngleRevolutions.
        /// </summary>
        /// <param name="angle">An angle in revolutions.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegrees InDegrees(AngleRevolutions angle) =>
            new AngleDegrees(angle.Revolutions * AngleGradians.FullAngle);
    }
}
