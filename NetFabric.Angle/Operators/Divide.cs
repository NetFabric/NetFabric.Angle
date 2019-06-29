using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegrees Divide(AngleDegrees left, double right) =>
            left / right;

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegreesMinutes Divide(in AngleDegreesMinutes left, double right) =>
            left / right;

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegreesMinutesSeconds Divide(in AngleDegreesMinutesSeconds left, double right) =>
            left / right;

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleGradians Divide(AngleGradians left, double right) =>
            left / right;

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians Divide(AngleRadians left, double right) =>
            left / right;

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRevolutions Divide(AngleRevolutions left, double right) =>
            left / right;
    }
}
