using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Returns an AngleDegreesMinutes that represents a specified number of degrees and minutes.
        /// </summary>
        /// <param name="degrees">A number of degrees.</param>
        /// <param name="minutes">A number of minutes.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegreesMinutes InDegreesMinutes(int degrees, double minutes)
        {
            if (minutes < 0.0 || minutes >= 60.0)
                ThrowHelper.ThrowArgumentOutOfRangeException(nameof(minutes), minutes, "Argument must be positive and less than 60.");

            return new AngleDegreesMinutes(degrees, minutes);
        }

        /// <summary>
        /// Returns an AngleDegreesMinutes that represents the equivalent to the AngleRadians.
        /// </summary>
        /// <param name="angle">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegreesMinutes InDegreesMinutes(AngleRadians angle) =>
            new AngleDegreesMinutes(angle.Radians * DegreesPerRadian);

        /// <summary>
        /// Returns an AngleDegreesMinutes that represents the equivalent to the AngleDegrees.
        /// </summary>
        /// <param name="angle">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegreesMinutes InDegreesMinutes(AngleDegrees angle) =>
            new AngleDegreesMinutes(angle.Degrees);

        /// <summary>
        /// Returns an AngleDegreesMinutes that represents the equivalent to the AngleGradians.
        /// </summary>
        /// <param name="angle">An angle in gradians.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegreesMinutes InDegreesMinutes(AngleGradians angle) =>
            new AngleDegreesMinutes(angle.Gradians * DegreesPerGradian);

        /// <summary>
        /// Returns an AngleDegreesMinutes that represents the equivalent to the AngleDegreesMinutesSeconds.
        /// </summary>
        /// <param name="angle">An angle in degrees, minutes and seconds.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegreesMinutes InDegreesMinutes(in AngleDegreesMinutesSeconds angle) =>
            new AngleDegreesMinutes(AngleDegreesMinutesSeconds.GetDegreesAngle(angle));

        /// <summary>
        /// Returns an AngleDegreesMinutes that represents the equivalent to the AngleRevolutions.
        /// </summary>
        /// <param name="angle">An angle in revolutions.</param>
        /// <returns>An object that represents value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegreesMinutes InDegreesMinutes(in AngleRevolutions angle) =>
            new AngleDegreesMinutes(angle.Revolutions * DegreesPerRevolution);
    }
}
