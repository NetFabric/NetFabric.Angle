using System;
using System.Runtime.CompilerServices;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Return the sine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The sine of the specified angle. If angle is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sin(AngleRadians angle) =>
            Math.Sin(angle.Radians);

        /// <summary>
        /// Returns the hyperbolic sine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The hyperbolic sine of value. If value is equal to NegativeInfinity, PositiveInfinity, or NaN, this method returns an Angle equal to value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sinh(AngleRadians angle) =>
             Math.Sinh(angle.Radians);

        /// <summary>
        /// Returns the angle whose sine is the specified number.
        /// </summary>
        /// <param name="value">A number representing a sine, where value must be greater than or equal to -1, but less than or equal to 1.</param>
        /// <returns>The angle whose sine is the specified number.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians Asin(double value)
        {
            if (value < -1.0 || value > 1.0)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Argument must be greater or equal to -1.0 and less or equal to 1.0.");

            return new AngleRadians(Math.Asin(value));
        }

        /// <summary>
        /// Return the cosine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The cosine of the specified angle. If angle is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Cos(AngleRadians angle) =>
            Math.Cos(angle.Radians);

        /// <summary>
        /// Returns the hyperbolic cosine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The hyperbolic cosine of value. If value is equal to NegativeInfinity, PositiveInfinity, or NaN, this method returns an Angle equal to value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Cosh(AngleRadians angle) =>
            Math.Cosh(angle.Radians);

        /// <summary>
        /// Returns the angle whose cosine is the specified number.
        /// </summary>
        /// <param name="value">A number representing a cosine, where value must be greater than or equal to -1, but less than or equal to 1.</param>
        /// <returns>The angle whose cosine is the specified number.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians Acos(double value)
        {
            if (value < -1.0 || value > 1.0)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Argument must be greater or equal to -1.0 and less or equal to 1.0.");

            return new AngleRadians(Math.Acos(value));
        }

        /// <summary>
        /// Returns the tangent of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The tangent of the specified angle. If angle is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Tan(AngleRadians angle) =>
            Math.Tan(angle.Radians);

        /// <summary>
        /// Returns the angle whose tangent is the specified number.
        /// </summary>
        /// <param name="value">A number representing a tangent.</param>
        /// <returns>The angle whose tangent is the specified number.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians Atan(double value) =>
            new AngleRadians(Math.Atan(value));

        /// <summary>
        /// Returns the angle whose tangent is the quotient of two specified numbers.
        /// </summary>
        /// <param name="x">The y coordinate of a point.</param>
        /// <param name="y">The x coordinate of a point.</param>
        /// <returns>The angle whose tangent is the quotient of two specified numbers.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AngleRadians Atan2(double y, double x) =>
            new AngleRadians(Math.Atan2(y, x));
    }
}
