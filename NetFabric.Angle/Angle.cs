using System;
using System.Diagnostics;

namespace NetFabric
{
    /// <summary>
    /// Represents an angle. 
    /// </summary>
    public static partial class Angle
    {
        const double DegreesInRadians = AngleDegrees.FullAngle / AngleRadians.FullAngle;
        const double GradiansInRadians = AngleGradians.FullAngle / AngleRadians.FullAngle;
        const double GradiansInDegrees = AngleGradians.FullAngle / AngleDegrees.FullAngle;

        /// <summary>
        /// Returns an AngleRadians that represents the equivalent to the AngleDegrees.
        /// </summary>
        /// <param name="angle">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRadians ToRadians(AngleDegrees angle) =>
            new AngleRadians(angle.Degrees / DegreesInRadians);

        /// <summary>
        /// Returns an AngleRadians that represents the equivalent to the AngleDegreesMinutes.
        /// </summary>
        /// <param name="angle">An angle in degrees and minutes.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRadians ToRadians(in AngleDegreesMinutes angle) =>
            new AngleRadians(AngleDegreesMinutes.GetDegreesAngle(angle) / DegreesInRadians);

        /// <summary>
        /// Returns an AngleRadians that represents the equivalent to the AngleDegreesMinutesSeconds.
        /// </summary>
        /// <param name="angle">An angle in degrees, minutes and seconds.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRadians ToRadians(in AngleDegreesMinutesSeconds angle) =>
            new AngleRadians(AngleDegreesMinutesSeconds.GetDegreesAngle(angle) / DegreesInRadians);

        /// <summary>
        /// Returns an AngleRadians that represents the equivalent to the AngleGradians.
        /// </summary>
        /// <param name="angle">An angle in gradinas.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRadians ToRadians(AngleGradians angle) =>
            new AngleRadians(angle.Gradians / GradiansInRadians);

        /// <summary>
        /// Returns an AngleDegrees that represents the equivalent to the AngleRadians.
        /// </summary>
        /// <param name="angle">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegrees ToDegrees(AngleRadians angle) =>
            new AngleDegrees(angle.Radians * DegreesInRadians);

        /// <summary>
        /// Returns an AngleDegrees that represents the equivalent to the AngleDegreesMinutes.
        /// </summary>
        /// <param name = "angle" > An angle in degrees and minutes.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegrees ToDegrees(in AngleDegreesMinutes angle) =>
            new AngleDegrees(AngleDegreesMinutes.GetDegreesAngle(angle));

        /// <summary>
        /// Returns an AngleDegrees that represents the equivalent to the AngleDegreesMinutesSeconds.
        /// </summary>
        /// <param name = "angle" > An angle in degrees, minutes and seconds.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegrees ToDegrees(in AngleDegreesMinutesSeconds angle) =>
            new AngleDegrees(AngleDegreesMinutesSeconds.GetDegreesAngle(angle));

        /// <summary>
        /// Returns an AngleDegrees that represents the equivalent to the AngleGradians.
        /// </summary>
        /// <param name="angle">An angle in gradians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegrees ToDegrees(AngleGradians angle) =>
            new AngleDegrees(angle.Gradians / GradiansInDegrees);

        /// <summary>
        /// Returns an AngleGradians that represents the equivalent to the AngleRadians.
        /// </summary>
        /// <param name="angle">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleGradians ToGradians(AngleRadians angle) =>
            new AngleGradians(angle.Radians * GradiansInRadians);

        /// <summary>
        /// Returns an AngleGradians that represents the equivalent to the AngleDegrees.
        /// </summary>
        /// <param name="angle">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleGradians ToGradians(AngleDegrees angle) =>
            new AngleGradians(angle.Degrees * GradiansInDegrees);

        /// <summary>
        /// Returns an AngleGradians that represents the equivalent to the AngleDegreesMinutes.
        /// </summary>
        /// <param name="angle">An angle in degrees and minutes.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleGradians ToGradians(in AngleDegreesMinutes angle) =>
            new AngleGradians(AngleDegreesMinutes.GetDegreesAngle(angle) * GradiansInDegrees);

        /// <summary>
        /// Returns an AngleGradians that represents the equivalent to the AngleDegreesMinutesSeconds.
        /// </summary>
        /// <param name="angle">An angle in degrees, minutes and seconds.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleGradians ToGradians(in AngleDegreesMinutesSeconds angle) =>
            new AngleGradians(AngleDegreesMinutesSeconds.GetDegreesAngle(angle) * GradiansInDegrees);

        /// <summary>
        /// Returns an AngleDegreesMinutes that represents the equivalent to the AngleRadians.
        /// </summary>
        /// <param name="value">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegreesMinutes ToDegreesMinutes(AngleRadians angle) => 
            new AngleDegreesMinutes(angle.Radians * DegreesInRadians);

        /// <summary>
        /// Returns an AngleDegreesMinutes that represents the equivalent to the AngleDegrees.
        /// </summary>
        /// <param name="value">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegreesMinutes ToDegreesMinutes(AngleDegrees angle) => 
            new AngleDegreesMinutes(angle.Degrees);

        /// <summary>
        /// Returns an AngleDegreesMinutes that represents the equivalent to the AngleGradians.
        /// </summary>
        /// <param name="value">An angle in gradians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegreesMinutes ToDegreesMinutes(AngleGradians angle) => 
            new AngleDegreesMinutes(angle.Gradians / GradiansInDegrees);

        /// <summary>
        /// Returns an AngleDegreesMinutes that represents the equivalent to the AngleDegreesMinutesSeconds.
        /// </summary>
        /// <param name="value">An angle in degrees, minutes and seconds.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegreesMinutes ToDegreesMinutes(in AngleDegreesMinutesSeconds angle) => 
            new AngleDegreesMinutes(AngleDegreesMinutesSeconds.GetDegreesAngle(angle));

        /// <summary>
        /// Returns an AngleDegreesMinutesSeconds that represents the equivalent to the AngleRadians.
        /// </summary>
        /// <param name="value">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegreesMinutesSeconds ToDegreesMinutesSeconds(AngleRadians angle) => 
            new AngleDegreesMinutesSeconds(angle.Radians * DegreesInRadians);

        /// <summary>
        /// Returns an AngleDegreesMinutesSeconds that represents the equivalent to the AngleDegrees.
        /// </summary>
        /// <param name="value">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegreesMinutesSeconds ToDegreesMinutesSeconds(AngleDegrees angle) => 
            new AngleDegreesMinutesSeconds(angle.Degrees);

        /// <summary>
        /// Returns an AngleDegreesMinutesSeconds that represents the equivalent to the AngleGradians.
        /// </summary>
        /// <param name="value">An angle in gradians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegreesMinutesSeconds ToDegreesMinutesSeconds(AngleGradians angle) => 
            new AngleDegreesMinutesSeconds(angle.Gradians / GradiansInDegrees);

        /// <summary>
        /// Returns an AngleDegreesMinutesSeconds that represents the equivalent to the AngleGradians.
        /// </summary>
        /// <param name="value">An angle in degrees and minutes.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegreesMinutesSeconds ToDegreesMinutesSeconds(in AngleDegreesMinutes angle)
        {
            var seconds = Utils.ToBase60(angle.Minutes, out var minutes);
            return angle.Degrees >= 0 ?
                new AngleDegreesMinutesSeconds(angle.Degrees, (int)minutes, seconds) :
                new AngleDegreesMinutesSeconds(angle.Degrees, -(int)minutes, -seconds);
        }
    }
}
