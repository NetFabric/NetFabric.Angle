using System;
using System.Diagnostics;

namespace NetFabric
{
    /// <summary>
    /// Represents an angle. 
    /// </summary>
    public partial struct Angle
    {
        /// <summary>
        /// Gets the value of the current Angle structure expressed in degrees and minutes.
        /// </summary>
        /// <returns>The degrees and minutes components of the Angle.</returns>
        public (int degress, double minutes) ToDegreesMinutes()
        {
            var decimalDegrees = radians * DegreesByRadians;
            var degress = (int)decimalDegrees;
            var minutes = Math.Abs(decimalDegrees - degress) * 60.0;
            return (degress, minutes);
        }

        /// <summary>
        /// Gets the value of the current Angle structure expressed in degrees, minutes and seconds.
        /// </summary>
        /// <returns>The degrees, minutes and seconds components of the Angle.</returns>
        public (int degress, int minutes, double seconds) ToDegreesMinutesSeconds()
        {
            var decimalDegrees = radians * DegreesByRadians;
            var degress = (int)decimalDegrees;
            var decimalMinutes = Math.Abs(decimalDegrees - degress) * 60.0;
            var minutes = (int)decimalMinutes;
            var seconds = (decimalMinutes - minutes) * 60.0;
            return (degress, minutes, seconds);
        }
    }
}
