﻿using System;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Returns the reference angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The reference angle.</returns>
        public static AngleDegrees GetReference(AngleDegrees angle) =>
            new AngleDegrees(AngleDegrees.GetReference(angle.Degrees));

        /// <summary>
        /// Returns the reference angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The reference angle.</returns>
        public static AngleDegreesMinutes GetReference(in AngleDegreesMinutes angle) =>
            new AngleDegreesMinutes(AngleDegreesMinutes.GetReference(angle));

        /// <summary>
        /// Returns the reference angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The reference angle.</returns>
        public static AngleDegreesMinutesSeconds GetReference(in AngleDegreesMinutesSeconds angle) =>
            AngleDegreesMinutesSeconds.GetReference(angle);

        /// <summary>
        /// Returns the reference angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The reference angle.</returns>
        public static AngleGradians GetReference(AngleGradians angle) =>
            new AngleGradians(AngleGradians.GetReference(angle.Gradians));

        /// <summary>
        /// Returns the reference angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The reference angle.</returns>
        public static AngleRadians GetReference(AngleRadians angle) =>
            new AngleRadians(AngleRadians.GetReference(angle.Radians));

        /// <summary>
        /// Returns the reference angle.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>The reference angle.</returns>
        public static AngleRevolutions GetReference(AngleRevolutions angle) =>
            new AngleRevolutions(AngleRevolutions.GetReference(angle.Revolutions));
    }
}