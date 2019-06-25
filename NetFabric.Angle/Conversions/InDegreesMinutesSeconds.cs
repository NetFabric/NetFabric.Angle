using System;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Returns an AngleDegreesMinutesSeconds that represents a specified number of degrees, minutes and seconds.
        /// </summary>
        /// <param name="value">A number of gradians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegreesMinutesSeconds InDegreesMinutesSeconds(int degrees, int minutes, double seconds)
        {
            if (minutes < 0 || minutes >= 60)
                return ThrowHelper.ThrowArgumentOutOfRangeException<AngleDegreesMinutesSeconds>(nameof(minutes), minutes, "Argument must be greater or equal to 0 and less than 60.");
            if (seconds < 0.0 || seconds >= 60.0)
                return ThrowHelper.ThrowArgumentOutOfRangeException<AngleDegreesMinutesSeconds>(nameof(seconds), seconds, "Argument must be greater or equal to 0 and less than 60.");

            return new AngleDegreesMinutesSeconds(degrees, minutes, seconds);
        }

        /// <summary>
        /// Returns an AngleDegreesMinutesSeconds that represents the equivalent to the AngleRadians.
        /// </summary>
        /// <param name="value">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegreesMinutesSeconds InDegreesMinutesSeconds(AngleRadians angle) =>
            new AngleDegreesMinutesSeconds(angle.Radians * DegreesInRadians);

        /// <summary>
        /// Returns an AngleDegreesMinutesSeconds that represents the equivalent to the AngleDegrees.
        /// </summary>
        /// <param name="value">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegreesMinutesSeconds InDegreesMinutesSeconds(AngleDegrees angle) =>
            new AngleDegreesMinutesSeconds(angle.Degrees);

        /// <summary>
        /// Returns an AngleDegreesMinutesSeconds that represents the equivalent to the AngleGradians.
        /// </summary>
        /// <param name="value">An angle in gradians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegreesMinutesSeconds InDegreesMinutesSeconds(AngleGradians angle) =>
            new AngleDegreesMinutesSeconds(angle.Gradians / GradiansInDegrees);

        /// <summary>
        /// Returns an AngleDegreesMinutesSeconds that represents the equivalent to the AngleGradians.
        /// </summary>
        /// <param name="value">An angle in degrees and minutes.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegreesMinutesSeconds InDegreesMinutesSeconds(in AngleDegreesMinutes angle)
        {
            var seconds = Utils.ToBase60(angle.Minutes, out var minutes);
            return angle.Degrees >= 0 ?
                new AngleDegreesMinutesSeconds(angle.Degrees, (int)minutes, seconds) :
                new AngleDegreesMinutesSeconds(angle.Degrees, -(int)minutes, -seconds);
        }

        /// <summary>
        /// Returns an AngleDegreesMinutesSeconds that represents the equivalent to the AngleRevolutions.
        /// </summary>
        /// <param name="value">An angle in revolutions.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegreesMinutesSeconds InDegreesMinutesSeconds(AngleRevolutions angle) =>
            new AngleDegreesMinutesSeconds(angle.Revolutions * AngleDegreesMinutesSeconds.FullAngle);
    }
}
