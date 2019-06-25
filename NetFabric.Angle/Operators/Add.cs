using System;

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
        public static AngleDegrees Add(AngleDegrees left, AngleDegrees right) =>
            new AngleDegrees(left.Degrees + right.Degrees);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleDegreesMinutes Add(in AngleDegreesMinutes left, in AngleDegreesMinutes right) =>
            left + right;

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleDegreesMinutesSeconds Add(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right) =>
            left + right;

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleGradians Add(AngleGradians left, AngleGradians right) =>
            new AngleGradians(left.Gradians + right.Gradians);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleRadians Add(AngleRadians left, AngleRadians right) =>
            new AngleRadians(left.Radians + right.Radians);

        /// <summary>
        /// Adds two vectors. 
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the addition.</returns>
        public static AngleRevolutions Add(AngleRevolutions left, AngleRevolutions right) =>
            new AngleRevolutions(left.Revolutions + right.Revolutions);
    }
}
