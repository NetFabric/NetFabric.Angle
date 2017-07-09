using System;
using System.Collections.Generic;
using System.Linq;

namespace NetFabric
{
    public static class SumExtensions
    {
        /// <summary>
        /// Computes the sum of a sequence of Angle values.
        /// </summary>
        /// <param name="source">A sequence of Angle values to calculate the sum of.</param>
        /// <returns>The sum of the values in the sequence.</returns>
        /// <exception cref="ArgumentNullException">source is null.</exception>
        /// <exception cref="OverflowException">The sum is larger than <see cref="Angle.MaxValue"/>.</exception>
        /// <remarks>The Sum(IEnumerable<Angle>) method returns Angle.Zero if source contains no elements.</remarks>
        public static Angle Sum(this IEnumerable<Angle> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            return source.Aggregate(Angle.Zero, (accumulate, angle) => accumulate + angle);
        }

        /// <summary>
        /// Computes the sum of a sequence of Angle values.
        /// </summary>
        /// <param name="source">A sequence of Angle values to calculate the sum of.</param>
        /// <returns>The sum of the values in the sequence.</returns>
        /// <exception cref="ArgumentNullException">source is null.</exception>
        /// <exception cref="OverflowException">The sum is larger than <see cref="Angle.MaxValue"/>.</exception>
        /// <remarks>
        /// The Sum(IEnumerable<Angle>) method returns Angle.Zero if source contains no elements.
        /// The result does not include values that are null.
        /// </remarks>
        public static Angle? Sum(this IEnumerable<Angle?> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            return source.Aggregate(Angle.Zero, (accumulate, angle) => angle.HasValue ? accumulate + angle.Value : accumulate);
        }

        /// <summary>
        /// Computes the sum of the sequence of Angle values that are obtained by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a sum.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The sum of the projected values.</returns>
        /// <exception cref="ArgumentNullException">source or selector is null.</exception>
        /// <exception cref="OverflowException">The sum is larger than <see cref="Angle.MaxValue"/>.</exception>
        /// <remarks>
        /// The Sum(IEnumerable<Angle>) method returns Angle.Zero if source contains no elements.
        /// You can apply this method to a sequence of arbitrary values if you provide a function, selector, that projects the members of source into an Angle.
        /// </remarks>
        public static Angle Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, Angle> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));
            return source.Aggregate(Angle.Zero, (accumulate, value) => accumulate + selector(value));
        }

        /// <summary>
        /// Computes the sum of the sequence of Angle values that are obtained by invoking a transform function on each element of the input sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence of values that are used to calculate a sum.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The sum of the projected values.</returns>
        /// <exception cref="ArgumentNullException">source or selector is null.</exception>
        /// <exception cref="OverflowException">The sum is larger than <see cref="Angle.MaxValue"/>.</exception>
        /// <remarks>
        /// The Sum(IEnumerable<Angle>) method returns Angle.Zero if source contains no elements.
        /// You can apply this method to a sequence of arbitrary values if you provide a function, selector, that projects the members of source into an Nullable&lt;Angle&gt;>.
        /// </remarks>
        public static Angle? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, Angle?> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));
            return source.Aggregate(Angle.Zero, (accumulate, value) =>
            {
                var angle = selector(value);
                return angle.HasValue ? accumulate + angle.Value : accumulate;
            });
        }
    }
}
