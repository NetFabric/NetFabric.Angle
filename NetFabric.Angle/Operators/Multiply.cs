using System;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Multiplies a angle by a scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleDegrees Multiply(double left, AngleDegrees right) =>
            new AngleDegrees(left * right.Degrees);

        /// <summary>
        /// Multiplies a angle by a scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleDegreesMinutes Multiply(double left, in AngleDegreesMinutes right) =>
            left * right;

        /// <summary>
        /// Multiplies a angle by a scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleDegreesMinutesSeconds Multiply(double left, in AngleDegreesMinutesSeconds right) =>
            left * right;

        /// <summary>
        /// Multiplies a angle by a scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleGradians Multiply(double left, AngleGradians right) =>
            new AngleGradians(left * right.Gradians);

        /// <summary>
        /// Multiplies a angle by a scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleRadians Multiply(double left, AngleRadians right) =>
            new AngleRadians(left * right.Radians);

        /// <summary>
        /// Multiplies a angle by a scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Source angle.</param>
        /// <returns>Result of the multiplication.</returns>
        public static AngleRevolutions Multiply(double left, AngleRevolutions right) =>
            new AngleRevolutions(left * right.Revolutions);
    }
}
