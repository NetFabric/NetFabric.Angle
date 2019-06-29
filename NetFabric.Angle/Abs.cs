using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Returns the absolute value of the AngleDegrees.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>
        /// An AngleDegrees, x, such that AngleDegrees.Zero &lt;= x &lt;= AngleDegrees.MaxValue.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegrees Abs(AngleDegrees angle) =>
            new AngleDegrees(Math.Abs(angle.Degrees));

        /// <summary>
        /// Returns the absolute value of the AngleDegreesMinutes.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>
        /// An AngleDegreesMinutes, x, such that AngleDegreesMinutes.Zero &lt;= x &lt;= AngleDegreesMinutes.MaxValue.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegreesMinutes Abs(in AngleDegreesMinutes angle) =>
            new AngleDegreesMinutes(Math.Abs(angle.Degrees), angle.Minutes);

        /// <summary>
        /// Returns the absolute value of the AngleDegreesMinutesSeconds.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>
        /// An AngleDegreesMinutesSeconds, x, such that AngleDegreesMinutesSeconds.Zero &lt;= x &lt;= AngleDegreesMinutesSeconds.MaxValue.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegreesMinutesSeconds Abs(in AngleDegreesMinutesSeconds angle) =>
            new AngleDegreesMinutesSeconds(Math.Abs(angle.Degrees), Math.Abs(angle.Minutes), Math.Abs(angle.Seconds));

        /// <summary>
        /// Returns the absolute value of the AngleGradians.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>
        /// An AngleGradians, x, such that AngleGradians.Zero &lt;= x &lt;= AngleGradians.MaxValue.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleGradians Abs(AngleGradians angle) =>
            new AngleGradians(Math.Abs(angle.Gradians));

        /// <summary>
        /// Returns the absolute value of the AngleRadians.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>
        /// An AngleRadians, x, such that AngleRadians.Zero &lt;= x &lt;= AngleRadians.MaxValue.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians Abs(AngleRadians angle) =>
            new AngleRadians(Math.Abs(angle.Radians));

        /// <summary>
        /// Returns the absolute value of the AngleRevolutions.
        /// </summary>
        /// <param name="angle">Source angle.</param>
        /// <returns>
        /// An AngleRevolutions, x, such that AngleRevolutions.Zero &lt;= x &lt;= AngleRevolutions.MaxValue.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRevolutions Abs(AngleRevolutions angle) =>
            new AngleRevolutions(Math.Abs(angle.Revolutions));
    }
}
