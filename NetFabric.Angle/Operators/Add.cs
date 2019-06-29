using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegrees Add(AngleDegrees left, AngleDegrees right) =>
            left + right;

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegreesMinutes Add(in AngleDegreesMinutes left, in AngleDegreesMinutes right) =>
            left + right;

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleDegreesMinutesSeconds Add(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right) =>
            left + right;

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleGradians Add(AngleGradians left, AngleGradians right) =>
            left + right;

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians Add(AngleRadians left, AngleRadians right) =>
            left + right;

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRevolutions Add(AngleRevolutions left, AngleRevolutions right) =>
            left + right;
    }
}
