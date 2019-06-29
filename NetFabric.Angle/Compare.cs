using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Compares two AngleDegrees values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Compare(AngleDegrees a1, AngleDegrees a2) =>
            a1.Degrees.CompareTo(a2.Degrees);

        /// <summary>
        /// Compares two AngleDegreesMinutes values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int Compare(in AngleDegreesMinutes a1, in AngleDegreesMinutes a2) =>
            AngleDegreesMinutes.GetDegreesAngle(a1).CompareTo(AngleDegreesMinutes.GetDegreesAngle(a2));

        /// <summary>
        /// Compares two AngleDegreesMinutesSeconds values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int Compare(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2) =>
            AngleDegreesMinutesSeconds.Compare(a1, a2);

        /// <summary>
        /// Compares two AngleGradians values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int Compare(AngleGradians a1, AngleGradians a2) =>
            a1.Gradians.CompareTo(a2.Gradians);

        /// <summary>
        /// Compares two AngleRadians values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int Compare(AngleRadians a1, AngleRadians a2) =>
            a1.Radians.CompareTo(a2.Radians);

        /// <summary>
        /// Compares two AngleRevolutions values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int Compare(AngleRevolutions a1, AngleRevolutions a2) =>
            a1.Revolutions.CompareTo(a2.Revolutions);
    }
}
