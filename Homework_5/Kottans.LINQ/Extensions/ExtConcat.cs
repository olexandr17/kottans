using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtConcat
    {

        /// <summary>
        /// Объединяет две последовательности.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, IEnumerable<T> second)
        {
            if (source == null || second == null)
            {
                throw new ArgumentNullException();
            }

            return ConcatIterator<T>(source, second);
        }

        private static IEnumerable<T> ConcatIterator<T>(IEnumerable<T> source, IEnumerable<T> second)
        {
            foreach (var item in source)
            {
                yield return item;
            }
            foreach (var item in second)
            {
                yield return item;
            }
        }

    }
}
