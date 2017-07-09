using System;
using System.Collections.Generic;
using System.Linq;

namespace NetFabric
{
    public static class MinExtensions
    {
        /// <summary>
        /// Returns the minimum value in a sequence of Angle values.
        /// </summary>
        /// <param name="source">A sequence of Angle values to determine the minimum value of.</param>
        /// <returns>The minimum value in the sequence.</returns>
        public static Angle Min(this IEnumerable<Angle> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            var minRadians = source.Min(angle => angle.ToRadians());
            return Angle.FromRadians(minRadians);
        }

        /// <summary>
        /// Returns the minimum value in a sequence of nullable Angle values.
        /// </summary>
        /// <param name="source">A sequence of Angle values to determine the minimum value of.</param>
        /// <returns>The minimum value in the sequence.</returns>
        /// <remarks>If the source sequence is empty or contains only values that are null, this function returns null.</remarks>
        public static Angle? Min(this IEnumerable<Angle?> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            var minRadians = source.Min(angle => (angle.HasValue ? angle.Value.ToRadians() : (double?)null));
            if(minRadians.HasValue)
                return Angle.FromRadians(minRadians.Value);
            return null;
        }
    }
}
