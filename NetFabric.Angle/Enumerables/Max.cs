using System;
using System.Collections.Generic;
using System.Linq;

namespace NetFabric
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns the maximum value in a sequence of Angle values.
        /// </summary>
        /// <param name="source">A sequence of Angle values to determine the maximum value of.</param>
        /// <returns>The maximum value in the sequence.</returns>
        /// <remarks>If the source sequence is empty, this function returns null.</remarks>
        public static Angle? Max(this IEnumerable<Angle> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    return null; // sequence is empty

                var max = enumerator.Current;
                Angle current;
                while(enumerator.MoveNext())
                {
                    current = enumerator.Current;
                    if (current > max)
                        max = current;
                }

                return max;
            }
        }

        /// <summary>
        /// Returns the maximum value in a sequence of nullable Angle values.
        /// </summary>
        /// <param name="source">A sequence of Angle values to determine the maximum value of.</param>
        /// <returns>The maximum value in the sequence.</returns>
        /// <remarks>If the source sequence is empty or contains only values that are null, this function returns null.</remarks>
        public static Angle? Max(this IEnumerable<Angle?> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            using (var enumerator = source.GetEnumerator())
            {
                Angle? max = null;
                do
                {
                    if (!enumerator.MoveNext())
                        return null; // sequence is empty

                    max = enumerator.Current;
                }
                while (!max.HasValue);

                var maxValue = max.GetValueOrDefault();
                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    var currentValue = current.GetValueOrDefault();

                    // Do not replace & with &&. The branch prediction cost outweighs the extra operation
                    // unless nulls either never happen or always happen.
                    if (current.HasValue & currentValue > maxValue)
                    {
                        maxValue = currentValue;
                        max = current;
                    }
                }

                return max;
            }
        }
    }
}
