using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Returns an GradianssAngle that represents a specified number of gradians.
        /// </summary>
        /// <param name="value">A number of gradians.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleGradians InGradians(double value) =>
            new AngleGradians(value);

        /// <summary>
        /// Returns an AngleGradians that represents the equivalent to the AngleRadians.
        /// </summary>
        /// <param name="angle">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleGradians InGradians(AngleRadians angle) =>
            new AngleGradians(angle.Radians * GradiansInRadians);

        /// <summary>
        /// Returns an AngleGradians that represents the equivalent to the AngleDegrees.
        /// </summary>
        /// <param name="angle">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleGradians InGradians(AngleDegrees angle) =>
            new AngleGradians(angle.Degrees * GradiansInDegrees);

        /// <summary>
        /// Returns an AngleGradians that represents the equivalent to the AngleDegreesMinutes.
        /// </summary>
        /// <param name="angle">An angle in degrees and minutes.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleGradians InGradians(in AngleDegreesMinutes angle) =>
            new AngleGradians(AngleDegreesMinutes.GetDegreesAngle(angle) * GradiansInDegrees);

        /// <summary>
        /// Returns an AngleGradians that represents the equivalent to the AngleDegreesMinutesSeconds.
        /// </summary>
        /// <param name="angle">An angle in degrees, minutes and seconds.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleGradians InGradians(in AngleDegreesMinutesSeconds angle) =>
            new AngleGradians(AngleDegreesMinutesSeconds.GetDegreesAngle(angle) * GradiansInDegrees);

        /// <summary>
        /// Returns an AngleGradians that represents the equivalent to the AngleRevolutions.
        /// </summary>
        /// <param name="angle">An angle in revolutions.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleGradians InGradians(AngleRevolutions angle) =>
            new AngleGradians(angle.Revolutions * AngleGradians.FullAngle);
    }
}
