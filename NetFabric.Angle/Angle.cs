using System;
using System.Diagnostics;

namespace NetFabric
{
    /// <summary>
    /// Represents an angle. 
    /// </summary>
    public static partial class Angle
    {
        const double DegreesInRadians = DegreesAngle.FullAngle / RadiansAngle.FullAngle;
        const double GradiansInRadians = GradiansAngle.FullAngle / RadiansAngle.FullAngle;
        const double GradiansInDegrees = GradiansAngle.FullAngle / DegreesAngle.FullAngle;

        /// <summary>
        /// Returns an RadiansAngle that represents a angle with the specified number of radians.
        /// </summary>
        /// <param name="radians">A number of radians.</param>
        /// <returns>An object that represents value.</returns>
        public static RadiansAngle InRadians(double radians) => 
            new RadiansAngle(radians);

        /// <summary>
        /// Returns an RadiansAngle that represents the equivalent to the DegreesAngle.
        /// </summary>
        /// <param name="angle">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        public static RadiansAngle InRadians(DegreesAngle angle) =>
            new RadiansAngle(angle.Degrees / DegreesInRadians);

        /// <summary>
        /// Returns an RadiansAngle that represents the equivalent to the GradiansAngle.
        /// </summary>
        /// <param name="angle">An angle in degrees.</param>
        /// <returns>An object that represents value.</returns>
        public static RadiansAngle InRadians(GradiansAngle angle) =>
            new RadiansAngle(angle.Gradians / GradiansInRadians);

        /// <summary>
        /// Returns an DegreessAngle that represents a specified number of degrees.
        /// </summary>
        /// <param name="value">A number of degrees.</param>
        /// <returns>An object that represents value.</returns>
        public static DegreesAngle InDegrees(double value) =>
            new DegreesAngle(value);

        /// <summary>
        /// Returns an DegreessAngle that represents the equivalent to the RadiansAngle.
        /// </summary>
        /// <param name="angle">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        public static DegreesAngle InDegrees(RadiansAngle angle) =>
            new DegreesAngle(angle.Radians * DegreesInRadians);

        /// <summary>
        /// Returns an DegreessAngle that represents the equivalent to the GradiansAngle.
        /// </summary>
        /// <param name="angle">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        public static DegreesAngle InDegrees(GradiansAngle angle) =>
            new DegreesAngle(angle.Gradians / GradiansInDegrees);

        /// <summary>
        /// Returns an GradianssAngle that represents a specified number of gradians.
        /// </summary>
        /// <param name="value">A number of gradians.</param>
        /// <returns>An object that represents value.</returns>
        public static GradiansAngle InGradians(double value) =>
            new GradiansAngle(value);

        /// <summary>
        /// Returns an GradianssAngle that represents the equivalent to the RadiansAngle.
        /// </summary>
        /// <param name="angle">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        public static GradiansAngle InGradians(RadiansAngle angle) =>
            new GradiansAngle(angle.Radians * GradiansInRadians);

        /// <summary>
        /// Returns an GradianssAngle that represents the equivalent to the DegreesAngle.
        /// </summary>
        /// <param name="angle">An angle in radians.</param>
        /// <returns>An object that represents value.</returns>
        public static GradiansAngle InGradians(DegreesAngle angle) =>
            new GradiansAngle(angle.Degrees * GradiansInDegrees);

        /// <summary>
        /// Returns an Angle that represents a specified number of degrees and minutes.
        /// </summary>
        /// <param name="degrees">The degrees parcel of the angle value.</param>
        /// <param name="minutes">The minutes parcel of the angle value.</param>
        /// <returns>An object that represents value.</returns>
        //public static Angle FromDegrees(int degrees, double minutes)
        //{
        //    if (minutes < 0.0 || minutes >= 60.0)
        //        throw new ArgumentOutOfRangeException(nameof(minutes), minutes, "Argument must be positive and less than 60.");

        //    if (Math.Sign(degrees) < 0)
        //        return new Angle((degrees - minutes / 60.0) / DegreesByRadians);
        //    else
        //        return new Angle((degrees + minutes / 60.0) / DegreesByRadians);
        //}

        /// <summary>
        /// Returns an Angle that represents a specified number of degrees, minutes and seconds.
        /// </summary>
        /// <param name="degrees">The degrees parcel of the angle value.</param>
        /// <param name="minutes">The minutes parcel of the angle value.</param>
        /// <param name="seconds">The seconds parcel of the angle value.</param>
        /// <returns>An object that represents value.</returns>
        //public static Angle FromDegrees(int degrees, int minutes, double seconds)
        //{
        //    if (minutes < 0.0 || minutes >= 60.0)
        //        throw new ArgumentOutOfRangeException(nameof(minutes), minutes, "Argument must be positive and less than 60.");
        //    if (seconds < 0.0 || seconds >= 60.0)
        //        throw new ArgumentOutOfRangeException(nameof(seconds), seconds, "Argument must be positive and less than 60.");

        //    if (Math.Sign(degrees) < 0)
        //        return new Angle((degrees - minutes / 60.0 - seconds / 3600.0) / DegreesByRadians);
        //    else
        //        return new Angle((degrees + minutes / 60.0 + seconds / 3600.0) / DegreesByRadians);
        //}

        /// <summary>
        /// Gets the value of the current Angle structure expressed in degrees and minutes.
        /// </summary>
        /// <param name="degress">The degrees component.</param>
        /// <param name="minutes">The arcminutes component.</param>
        //public void ToDegrees(out int degress, out double minutes)
        //{
        //    var decimalDegrees = radians * DegreesByRadians;
        //    degress = (int)decimalDegrees;
        //    minutes = Math.Abs(decimalDegrees - degress) * 60.0;
        //}

        /// <summary>
        /// Gets the value of the current Angle structure expressed in degrees, minutes and seconds.
        /// </summary>
        /// <param name="degress">The degrees component.</param>
        /// <param name="minutes">The arcminutes component.</param>
        /// <param name="seconds">The arcseconds component.</param>
        //public void ToDegrees(out int degress, out int minutes, out double seconds)
        //{
        //    var decimalDegrees = radians * DegreesByRadians;
        //    degress = (int)decimalDegrees;
        //    var decimalMinutes = Math.Abs(decimalDegrees - degress) * 60.0;
        //    minutes = (int)decimalMinutes;
        //    seconds = (decimalMinutes - minutes) * 60.0;
        //}


    }
}
