using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtDistinct
    {

        /// <summary>
        /// Возвращает различающиеся элементы последовательности, используя для сравнения значений компаратор проверки на равенство по умолчанию.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source)
        {
            return source.Distinct<T>(null);
        }

        /// <summary>
        /// Возвращает различающиеся элементы последовательности, используя для сравнения значений указанный компаратор IEqualityComparer<T>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            return DistinctIterator(source, comparer);
        }
        
        private static IEnumerable<T> DistinctIterator<T>(IEnumerable<T> source, IEqualityComparer<T> comparer)
        {
            var hash = new HashSet<T>(comparer);
            foreach (var item in source)
            {
                if (hash.Add(item))
                {
                    yield return item;
                }
            }
        }

    }
}
