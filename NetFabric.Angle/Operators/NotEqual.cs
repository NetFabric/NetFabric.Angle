using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Indicates whether two AngleDegrees instances are not equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are not equal; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotEqual(AngleDegrees a1, AngleDegrees a2) =>
            a1 != a2;

        /// <summary>
        /// Indicates whether two AngleDegrees instances are not equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are not equal; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotEqual(in AngleDegreesMinutes a1, in AngleDegreesMinutes a2) =>
            a1 != a2;

        /// <summary>
        /// Indicates whether two AngleDegreesMinutesSeconds instances are not equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are not equal; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotEqual(in AngleDegreesMinutesSeconds a1, in AngleDegreesMinutesSeconds a2) =>
            a1 != a2;

        /// <summary>
        /// Indicates whether two AngleGradians instances are not equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are not equal; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotEqual(AngleGradians a1, AngleGradians a2) =>
            a1 != a2;

        /// <summary>
        /// Indicates whether two AngleRadians instances are not equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are not equal; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotEqual(AngleRadians a1, AngleRadians a2) =>
            a1 != a2;

        /// <summary>
        /// Indicates whether two AngleRevolutions instances are not equal.
        /// </summary>
        /// <param name="a1">The first angle to compare.</param>
        /// <param name="a2">The second angle to compare.</param>
        /// <returns>true if the values of a1 and a2 are not equal; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotEqual(AngleRevolutions a1, AngleRevolutions a2) =>
            a1 != a2;
    }
}
