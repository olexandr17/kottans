using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtSequenceEqual
    {

        /// <summary>
        /// Определяет, совпадают ли две последовательности, используя для сравнения элементов компаратор проверки на равенство по умолчанию, предназначенный для их типа.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool SequenceEqual<T>(this IEnumerable<T> source, IEnumerable<T> second)
        {
            return source.SequenceEqual<T>(second, null);
        }

        /// <summary>
        /// Определяет, совпадают ли две последовательности, используя для сравнения элементов указанный компаратор IEqualityComparer<T>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="second"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static bool SequenceEqual<T>(this IEnumerable<T> source, IEnumerable<T> second, IEqualityComparer<T> comparer)
        {
            if (source == null || second == null)
            {
                throw new ArgumentNullException();
            }

            if (comparer == null)
            {
                comparer = EqualityComparer<T>.Default;
            }

            ICollection<T> list1 = source as ICollection<T>;
            ICollection<T> list2 = second as ICollection<T>;
            if (list1 != null && list2 != null)
            {
                if (list1.Count != list2.Count)
                {
                    return false;
                }
            }

            using (IEnumerator<T> enumerator1 = source.GetEnumerator())
            {
                using (IEnumerator<T> enumerator2 = second.GetEnumerator())
                {
                    while (enumerator1.MoveNext())
                    {
                        if (!enumerator2.MoveNext() || !comparer.Equals(enumerator1.Current, enumerator2.Current))
                        {
                            return false;
                        }
                    }

                    if (enumerator2.MoveNext())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }
}
