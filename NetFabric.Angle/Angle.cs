using System;
using System.Diagnostics;

namespace NetFabric
{
    /// <summary>
    /// Represents an angle. 
    /// </summary>
    public static partial class Angle
    {
        const double RevolutionsInRadians = AngleRevolutions.FullAngle / AngleRadians.FullAngle;
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
        /// <param name="angle">An angle in gradians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRadians ToRadians(AngleGradians angle) =>
            new AngleRadians(angle.Gradians / GradiansInRadians);

        /// <summary>
        /// Returns an AngleRadians that represents the equivalent to the AngleRevolutions.
        /// </summary>
        /// <param name="angle">An angle in revolutions.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRadians ToRadians(AngleRevolutions angle) =>
            new AngleRadians(angle.Revolutions * AngleRadians.FullAngle);

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
        /// Returns an AngleDegrees that represents the equivalent to the AngleRevolutions.
        /// </summary>
        /// <param name="angle">An angle in revolutions.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegrees ToDegrees(AngleRevolutions angle) =>
            new AngleDegrees(angle.Revolutions * AngleGradians.FullAngle);

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
        /// Returns an AngleGradians that represents the equivalent to the AngleRevolutions.
        /// </summary>
        /// <param name="angle">An angle in revolutions.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleGradians ToGradians(in AngleRevolutions angle) =>
            new AngleGradians(angle.Revolutions * AngleGradians.FullAngle);

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
        /// Returns an AngleDegreesMinutes that represents the equivalent to the AngleRevolutions.
        /// </summary>
        /// <param name="value">An angle in revolutions.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegreesMinutes ToDegreesMinutes(in AngleRevolutions angle) =>
            new AngleDegreesMinutes(angle.Revolutions * AngleDegreesMinutes.FullAngle);

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

        /// <summary>
        /// Returns an AngleDegreesMinutesSeconds that represents the equivalent to the AngleRevolutions.
        /// </summary>
        /// <param name="value">An angle in revolutions.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegreesMinutesSeconds ToDegreesMinutesSeconds(AngleRevolutions angle) =>
            new AngleDegreesMinutesSeconds(angle.Revolutions * AngleDegreesMinutesSeconds.FullAngle);

        /// <summary>
        /// Returns an AngleRevolutions that represents the equivalent to the AngleRadians.
        /// </summary>
        /// <param name="angle">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRevolutions ToRevolutions(AngleRadians angle) =>
            new AngleRevolutions(angle.Radians / AngleRadians.FullAngle);

        /// <summary>
        /// Returns an AngleRevolutions that represents the equivalent to the AngleDegrees.
        /// </summary>
        /// <param name="angle">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRevolutions ToRevolutions(AngleDegrees angle) =>
            new AngleRevolutions(angle.Degrees / AngleDegrees.FullAngle);

        /// <summary>
        /// Returns an AngleRevolutions that represents the equivalent to the AngleDegreesMinutes.
        /// </summary>
        /// <param name="angle">An angle in degrees and minutes.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRevolutions ToRevolutions(in AngleDegreesMinutes angle) =>
            new AngleRevolutions(AngleDegreesMinutes.GetDegreesAngle(angle) / AngleDegreesMinutes.FullAngle);

        /// <summary>
        /// Returns an AngleRevolutions that represents the equivalent to the AngleDegreesMinutesSeconds.
        /// </summary>
        /// <param name="angle">An angle in degrees, minutes and seconds.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRevolutions ToRevolutions(in AngleDegreesMinutesSeconds angle) =>
            new AngleRevolutions(AngleDegreesMinutesSeconds.GetDegreesAngle(angle) / AngleDegreesMinutesSeconds.FullAngle);

        /// <summary>
        /// Returns an AngleRevolutions that represents the equivalent to the AngleGradians.
        /// </summary>
        /// <param name="angle">An angle in gradians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRevolutions ToRevolutions(AngleGradians angle) =>
            new AngleRevolutions(angle.Gradians / AngleGradians.FullAngle);
    }
}
