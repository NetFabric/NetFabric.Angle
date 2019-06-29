using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Returns an AngleRadians that represents a angle with the specified number of radians.
        /// </summary>
        /// <param name="radians">A number of radians.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians InRadians(double radians) =>
            new AngleRadians(radians);

        /// <summary>
        /// Returns an AngleRadians that represents the equivalent to the AngleDegrees.
        /// </summary>
        /// <param name="angle">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians InRadians(AngleDegrees angle) =>
            new AngleRadians(angle.Degrees / DegreesInRadians);

        /// <summary>
        /// Returns an AngleRadians that represents the equivalent to the AngleDegreesMinutes.
        /// </summary>
        /// <param name="angle">An angle in degrees and minutes.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians InRadians(in AngleDegreesMinutes angle) =>
            new AngleRadians(AngleDegreesMinutes.GetDegreesAngle(angle) / DegreesInRadians);

        /// <summary>
        /// Returns an AngleRadians that represents the equivalent to the AngleDegreesMinutesSeconds.
        /// </summary>
        /// <param name="angle">An angle in degrees, minutes and seconds.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians InRadians(in AngleDegreesMinutesSeconds angle) =>
            new AngleRadians(AngleDegreesMinutesSeconds.GetDegreesAngle(angle) / DegreesInRadians);

        /// <summary>
        /// Returns an AngleRadians that represents the equivalent to the AngleGradians.
        /// </summary>
        /// <param name="angle">An angle in gradians.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians InRadians(AngleGradians angle) =>
            new AngleRadians(angle.Gradians / GradiansInRadians);

        /// <summary>
        /// Returns an AngleRadians that represents the equivalent to the AngleRevolutions.
        /// </summary>
        /// <param name="angle">An angle in revolutions.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians InRadians(AngleRevolutions angle) =>
            new AngleRadians(angle.Revolutions * AngleRadians.FullAngle);
    }
}
