using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtZip
    {

        /// <summary>
        /// Объединяет две последовательности, используя указанную функцию предиката.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="source"></param>
        /// <param name="second"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<TR> Zip<T1, T2, TR>(this IEnumerable<T1> source, IEnumerable<T2> second, Func<T1, T2, TR> selector)
        {
            if (source == null || second == null || selector == null)
            {
                throw new ArgumentNullException();
            }

            return ZipIterator<T1, T2, TR>(source, second, selector);
        }

        public static IEnumerable<TR> ZipIterator<T1, T2, TR>(IEnumerable<T1> source, IEnumerable<T2> second, Func<T1, T2, TR> selector)
        {
            using (IEnumerator<T1> enumerator1 = source.GetEnumerator())
            {
                using (IEnumerator<T2> enumerator2 = second.GetEnumerator())
                {
                    while (enumerator1.MoveNext() && enumerator2.MoveNext())
                    {
                        yield return selector(enumerator1.Current, enumerator2.Current);
                    }
                }
            }
        }

    }
}
