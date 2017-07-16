using System;
using System.Collections.Generic;
using System.Linq;

namespace NetFabric
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns the minimum value in a sequence of Angle values.
        /// </summary>
        /// <param name="source">A sequence of Angle values to determine the minimum value of.</param>
        /// <returns>The minimum value in the sequence.</returns>
        /// <remarks>If the source sequence is empty, this function returns null.</remarks>
        public static Angle? Min(this IEnumerable<Angle> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    return null; // sequence is empty

                var min = enumerator.Current;
                Angle current;
                while(enumerator.MoveNext())
                {
                    current = enumerator.Current;
                    if (current < min)
                        min = current;
                }

                return min;
            }
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

            using (var enumerator = source.GetEnumerator())
            {
                var min = (Angle?)null;
                do
                {
                    if (!enumerator.MoveNext())
                        return null; // sequence is empty

                    min = enumerator.Current;
                }
                while (!min.HasValue);

                var minValue = min.GetValueOrDefault();
                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    var currentValue = current.GetValueOrDefault();

                    // Do not replace & with &&. The branch prediction cost outweighs the extra operation
                    // unless nulls either never happen or always happen.
                    if (current.HasValue & currentValue < minValue)
                    {
                        minValue = currentValue;
                        min = current;
                    }
                }

                return min;
            }
        }
    }
}
