using System;

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
        public static AngleDegrees Divide(AngleDegrees left, double right) =>
            new AngleDegrees(left.Degrees / right);

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleDegreesMinutes Divide(in AngleDegreesMinutes left, double right) =>
            left / right;

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleDegreesMinutesSeconds Divide(in AngleDegreesMinutesSeconds left, double right) =>
            left / right;

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleGradians Divide(AngleGradians left, double right) =>
            new AngleGradians(left.Gradians / right);

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleRadians Divide(AngleRadians left, double right) =>
            new AngleRadians(left.Radians / right);

        /// <summary>
        /// Divides a angle by a scalar value.
        /// </summary>
        /// <param name="left">Source angle.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>Result of the division.</returns>
        public static AngleRevolutions Divide(AngleRevolutions left, double right) =>
            new AngleRevolutions(left.Revolutions / right);
    }
}
