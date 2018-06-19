using System;
using System.Diagnostics;

namespace NetFabric
{
    /// <summary>
    /// Represents an angle. 
    /// </summary>
    public static partial class Angle
    {
        const double DegreesInRadians = AngleDegrees.FullAngle / AngleRadians.FullAngle;
        const double GradiansInRadians = AngleGradians.FullAngle / AngleRadians.FullAngle;
        const double GradiansInDegrees = AngleGradians.FullAngle / AngleDegrees.FullAngle;

        /// <summary>
        /// Returns an RadiansAngle that represents the equivalent to the DegreesAngle.
        /// </summary>
        /// <param name="angle">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRadians ToRadians(AngleDegrees angle) =>
            new AngleRadians(angle.Degrees / DegreesInRadians);

        /// <summary>
        /// Returns an RadiansAngle that represents the equivalent to the DegreesAngle.
        /// </summary>
        /// <param name="angle">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        //public static AngleRadians ToRadians(AngleDegreesMinutes angle) =>
        //    new AngleRadians(AngleDegreesMinutes.GetDegreesAngle(angle.Degrees, angle.Minutes) / DegreesInRadians);

        /// <summary>
        /// Returns an RadiansAngle that represents the equivalent to the GradiansAngle.
        /// </summary>
        /// <param name="angle">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleRadians ToRadians(AngleGradians angle) =>
            new AngleRadians(angle.Gradians / GradiansInRadians);

        /// <summary>
        /// Returns an DegreessAngle that represents the equivalent to the RadiansAngle.
        /// </summary>
        /// <param name="angle">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegrees ToDegrees(AngleRadians angle) =>
            new AngleDegrees(angle.Radians * DegreesInRadians);

        /// <summary>
        /// Returns an DegreesAngle that represents the equivalent to the DegreesMinutesAngle.
        /// </summary>
        /// <param name="angle">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        //public static AngleDegrees ToDegrees(AngleDegreesMinutes angle) =>
        //    new AngleDegrees(AngleDegreesMinutes.GetDegreesAngle(angle.Degrees, angle.Minutes));

        /// <summary>
        /// Returns an DegreessAngle that represents the equivalent to the GradiansAngle.
        /// </summary>
        /// <param name="angle">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleDegrees ToDegrees(AngleGradians angle) =>
            new AngleDegrees(angle.Gradians / GradiansInDegrees);

        /// <summary>
        /// Returns an GradianssAngle that represents the equivalent to the RadiansAngle.
        /// </summary>
        /// <param name="angle">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleGradians ToGradians(AngleRadians angle) =>
            new AngleGradians(angle.Radians * GradiansInRadians);

        /// <summary>
        /// Returns an GradianssAngle that represents the equivalent to the DegreesAngle.
        /// </summary>
        /// <param name="angle">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        public static AngleGradians ToGradians(AngleDegrees angle) =>
            new AngleGradians(angle.Degrees * GradiansInDegrees);

        ///// <summary>
        ///// Returns an GradiansAngle that represents the equivalent to the DegreesMinutesAngle.
        ///// </summary>
        ///// <param name="angle">An angle in degrees.</param>
        ///// <returns>An object that represents value.</returns>
        //public static AngleGradians ToGradians(AngleDegreesMinutes angle) =>
        //    new AngleGradians(AngleDegreesMinutes.GetDegreesAngle(angle.Degrees, angle.Minutes) * GradiansInDegrees);

        ///// <summary>
        ///// Returns an DegreesMinutesAngle that represents the equivalent to the RadiansAngle.
        ///// </summary>
        ///// <param name="value">A number of gradians.</param>
        ///// <returns>An object that represents value.</returns>
        //public static AngleDegreesMinutes ToDegreesMinutes(AngleRadians angle)
        //{
        //    return new AngleDegreesMinutes(angle.Radians * DegreesInRadians);
        //}

        ///// <summary>
        ///// Returns an DegreesMinutesAngle that represents the equivalent to the DegreesAngle.
        ///// </summary>
        ///// <param name="value">A number of gradians.</param>
        ///// <returns>An object that represents value.</returns>
        //public static AngleDegreesMinutes ToDegreesMinutes(AngleDegrees angle)
        //{
        //    return new AngleDegreesMinutes(angle.Degrees);
        //}

        ///// <summary>
        ///// Returns an DegreesMinutesAngle that represents the equivalent to the GradiansAngle.
        ///// </summary>
        ///// <param name="value">A number of gradians.</param>
        ///// <returns>An object that represents value.</returns>
        //public static AngleDegreesMinutes ToDegreesMinutes(AngleGradians angle)
        //{
        //    return new AngleDegreesMinutes(angle.Gradians / GradiansInDegrees);
        //}

        /// <summary>
        /// Gets the value of the current Angle structure expressed in degrees, minutes and seconds.
        /// </summary>
        /// <param name="degress">The degrees component.</param>
        /// <param name="minutes">The arcminutes component.</param>
        /// <param name="seconds">The arcseconds component.</param>
        //public void ToDegrees(out int degress, out byte minutes, out double seconds)
        //{
        //    var decimalDegrees = radians * DegreesByRadians;
        //    degress = (int)decimalDegrees;
        //    var decimalMinutes = Math.Abs(decimalDegrees - degress) * 60.0;
        //    minutes = (int)decimalMinutes;
        //    seconds = (decimalMinutes - minutes) * 60.0;
        //}


    }
}
