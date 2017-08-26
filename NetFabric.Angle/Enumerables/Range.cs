using System;
using System.Collections.Generic;
using System.Linq;

namespace NetFabric
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns the range with the minimum and maximum values in a sequence of Angle values.
        /// </summary>
        /// <param name="source">A sequence of Angle values to determine the maximum value of.</param>
        /// <returns>A tuple containing the the minimum and maximum values in the sequence.</returns>
        /// <remarks>If the source sequence is empty, this function returns null.</remarks>
        public static (Angle Min, Angle Max)? Range(this IEnumerable<Angle> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    return null; // sequence is empty

                var min = enumerator.Current;
                var max = enumerator.Current;
                while(enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    if (current < min)
                        min = current;
                    if (current > max)
                        max = current;
                }

                return (min, max);
            }
        }

        /// <summary>
        /// Returns the range with the maximum value in a sequence of nullable Angle values.
        /// </summary>
        /// <param name="source">A sequence of Angle values to determine the maximum value of.</param>
        /// <returns>The maximum value in the sequence.</returns>
        /// <remarks>If the source sequence is empty or contains only values that are null, this function returns null.</remarks>
        public static (Angle Min, Angle Max)? Range(this IEnumerable<Angle?> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            using (var enumerator = source.GetEnumerator())
            {
                Angle? current = null;
                do
                {
                    if (!enumerator.MoveNext())
                        return null; // sequence is empty

                    current = enumerator.Current;
                }
                while (!current.HasValue);

                var min = current.GetValueOrDefault();
                var max = min;
                while (enumerator.MoveNext())
                {
                    current = enumerator.Current;

                    // Do not replace & with &&. The branch prediction cost outweighs the extra operation
                    // unless nulls either never happen or always happen.
                    if (current.HasValue)
                    {
                        var currentValue = current.GetValueOrDefault();
                        if (currentValue < min)
                        {
                            min = currentValue;
                        }
                        if (currentValue > max)
                        {
                            max = currentValue;
                        }
                    }
                }

                return (min, max);
            }
        }

        /// <summary>
        /// Returns the smallest range containing all the ranges in a sequence of Angle values.
        /// </summary>
        /// <param name="source">A sequence of Angle values to determine the maximum value of.</param>
        /// <returns>A tuple containing the the minimum and maximum values in the sequence.</returns>
        /// <remarks>If the source sequence is empty, this function returns null.</remarks>
        public static (Angle Min, Angle Max)? Range(this IEnumerable<(Angle Min, Angle Max)> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    return null; // sequence is empty

                var current = enumerator.Current;
                var min = current.Min;
                var max = current.Max;
                while (enumerator.MoveNext())
                {
                    current = enumerator.Current;
                    if (current.Min < min)
                        min = current.Min;
                    if (current.Max > max)
                        max = current.Max;
                }

                return (min, max);
            }
        }

        /// <summary>
        /// Returns the range with the maximum value in a sequence of nullable Angle values.
        /// </summary>
        /// <param name="source">A sequence of Angle values to determine the maximum value of.</param>
        /// <returns>The maximum value in the sequence.</returns>
        /// <remarks>If the source sequence is empty or contains only values that are null, this function returns null.</remarks>
        public static (Angle Min, Angle Max)? Range(this IEnumerable<(Angle Min, Angle Max)?> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            using (var enumerator = source.GetEnumerator())
            {
                (Angle Min, Angle Max)? current = null;
                do
                {
                    if (!enumerator.MoveNext())
                        return null; // sequence is empty

                    current = enumerator.Current;
                }
                while (!current.HasValue);

                var currentValue = current.GetValueOrDefault();
                var min = currentValue.Min;
                var max = currentValue.Max;
                while (enumerator.MoveNext())
                {
                    current = enumerator.Current;

                    // Do not replace & with &&. The branch prediction cost outweighs the extra operation
                    // unless nulls either never happen or always happen.
                    if (current.HasValue)
                    {
                        currentValue = current.GetValueOrDefault();
                        if (currentValue.Min < min)
                        {
                            min = currentValue.Min;
                        }
                        if (currentValue.Max > max)
                        {
                            max = currentValue.Max;
                        }
                    }
                }

                return (min, max);
            }
        }

    }
}
