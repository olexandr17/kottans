using System;
using System.Collections;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtCount
    {

        /// <summary>
        /// Возвращает количество элементов в последовательности.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int Count<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            var count = 0;
            foreach (var item in source)
            {
                count = checked(count + 1);
            }

            return count;
        }

        /// <summary>
        /// Возвращает число, представляющее количество элементов последовательности, удовлетворяющих заданному условию.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int Count<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }

            var count = 0;
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    count = checked(count + 1);
                }
            }

            return count;
        }

    }
}
