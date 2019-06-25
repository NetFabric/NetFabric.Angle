using System;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Compares two AngleDegrees values and returns an integer that indicates whether when both reduced the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int CompareReduced(AngleDegrees a1, AngleDegrees a2) =>
            AngleDegrees.Reduce(a1.Degrees).CompareTo(AngleDegrees.Reduce(a2.Degrees));

        /// <summary>
        /// Compares two AngleDegreesMinutes values and returns an integer that indicates whether when both reduced the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int CompareReduced(in AngleDegreesMinutes a1, in AngleDegreesMinutes a2) =>
            Compare(Reduce(a1), Reduce(a2));

        /// <summary>
        /// Compares two AngleDegreesMinutesSeconds values and returns an integer that indicates whether when both reduced the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int CompareReduced(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2) =>
            AngleDegreesMinutesSeconds.Compare(Reduce(a1), Reduce(a2));

        /// <summary>
        /// Compares two AngleGradians values and returns an integer that indicates whether when both reduced the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int CompareReduced(AngleGradians a1, AngleGradians a2) =>
            AngleGradians.Reduce(a1.Gradians).CompareTo(AngleGradians.Reduce(a2.Gradians));

        /// <summary>
        /// Compares two AngleRadians values and returns an integer that indicates whether when both reduced the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int CompareReduced(AngleRadians a1, AngleRadians a2) =>
            AngleRadians.Reduce(a1.Radians).CompareTo(AngleRadians.Reduce(a2.Radians));

        /// <summary>
        /// Compares two AngleRevolutions values and returns an integer that indicates whether when both reduced the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns></returns>
        public static int CompareReduced(AngleRevolutions a1, AngleRevolutions a2) =>
            AngleRevolutions.Reduce(a1.Revolutions).CompareTo(AngleRevolutions.Reduce(a2.Revolutions));
    }
}
