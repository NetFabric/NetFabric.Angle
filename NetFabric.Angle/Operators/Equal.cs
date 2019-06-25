using System;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Indicates whether two AngleDegrees instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool Equal(AngleDegrees a1, AngleDegrees a2) =>
            a1.Degrees == a2.Degrees;

        /// <summary>
        /// Indicates whether two AngleDegrees instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool Equal(in AngleDegreesMinutes a1, in AngleDegreesMinutes a2) =>
            a1.Degrees == a2.Degrees && a1.Minutes == a2.Minutes;

        /// <summary>
        /// Indicates whether two AngleDegreesMinutesSeconds instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool Equal(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2) =>
            a1.Degrees == a2.Degrees && a1.Minutes == a2.Minutes && a1.Seconds == a2.Seconds;

        /// <summary>
        /// Indicates whether two AngleGradians instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool Equal(AngleGradians a1, AngleGradians a2) =>
            a1.Gradians == a2.Gradians;

        /// <summary>
        /// Indicates whether two AngleRadians instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool Equal(AngleRadians a1, AngleRadians a2) =>
            a1.Radians == a2.Radians;

        /// <summary>
        /// Indicates whether two AngleRevolutions instances are equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are equal; otherwise, false.</returns>
        public static bool Equal(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions == a2.Revolutions;
    }
}
