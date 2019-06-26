using System;

namespace NetFabric
{
    public static partial class Angle
    {
        /// <summary>
        /// Return the sine of the specified angle.
        /// </summary>
        /// <param name="angle">An angle.</param>
        /// <returns>The sine of the specified angle. If angle is equal to NaN, NegativeInfinity, or PositiveInfinity, this method returns NaN.</returns>
        public static double Sin(AngleRadians angle) =>
            Math.Sin(angle.Radians);
    }
}
