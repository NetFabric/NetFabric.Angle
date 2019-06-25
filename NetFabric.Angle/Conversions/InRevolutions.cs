﻿using System;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Returns an RevolutionssAngle that represents a specified number of revolutions.
        /// </summary>
        /// <param name="value">A number of revolutions.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRevolutions InRevolutions(double value) =>
            new AngleRevolutions(value);

        /// <summary>
        /// Returns an AngleRevolutions that represents the equivalent to the AngleRadians.
        /// </summary>
        /// <param name="angle">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRevolutions InRevolutions(AngleRadians angle) =>
            new AngleRevolutions(angle.Radians / AngleRadians.FullAngle);

        /// <summary>
        /// Returns an AngleRevolutions that represents the equivalent to the AngleDegrees.
        /// </summary>
        /// <param name="angle">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRevolutions InRevolutions(AngleDegrees angle) =>
            new AngleRevolutions(angle.Degrees / AngleDegrees.FullAngle);

        /// <summary>
        /// Returns an AngleRevolutions that represents the equivalent to the AngleDegreesMinutes.
        /// </summary>
        /// <param name="angle">An angle in degrees and minutes.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRevolutions InRevolutions(in AngleDegreesMinutes angle) =>
            new AngleRevolutions(AngleDegreesMinutes.GetDegreesAngle(angle) / AngleDegreesMinutes.FullAngle);

        /// <summary>
        /// Returns an AngleRevolutions that represents the equivalent to the AngleDegreesMinutesSeconds.
        /// </summary>
        /// <param name="angle">An angle in degrees, minutes and seconds.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRevolutions InRevolutions(in AngleDegreesMinutesSeconds angle) =>
            new AngleRevolutions(AngleDegreesMinutesSeconds.GetDegreesAngle(angle) / AngleDegreesMinutesSeconds.FullAngle);

        /// <summary>
        /// Returns an AngleRevolutions that represents the equivalent to the AngleGradians.
        /// </summary>
        /// <param name="angle">An angle in gradians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRevolutions InRevolutions(AngleGradians angle) =>
            new AngleRevolutions(angle.Gradians / AngleGradians.FullAngle);
    }
}