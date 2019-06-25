using System;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleDegrees Subtract(AngleDegrees left, AngleDegrees right) =>
            new AngleDegrees(left.Degrees - right.Degrees);

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleDegreesMinutes Subtract(in AngleDegreesMinutes left, in AngleDegreesMinutes right) =>
            left - right;

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleDegreesMinutesSeconds Subtract(in AngleDegreesMinutesSeconds left, in AngleDegreesMinutesSeconds right) =>
            left - right;

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleGradians Subtract(AngleGradians left, AngleGradians right) =>
            new AngleGradians(left.Gradians - right.Gradians);

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleRadians Subtract(AngleRadians left, AngleRadians right) =>
            new AngleRadians(left.Radians - right.Radians);

        /// <summary>
        /// Subtracts a angle from a angle.  
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the subtraction.</returns>
        public static AngleRevolutions Subtract(AngleRevolutions left, AngleRevolutions right) =>
            new AngleRevolutions(left.Revolutions - right.Revolutions);
    }
}
