using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtFirst
    {

        /// <summary>
        /// Возвращает первый элемент последовательности.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T First<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in source)
            {
                return item;
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Возвращает первый элемент последовательности, удовлетворяющий указанному условию.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T First<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            throw new InvalidOperationException();
        }

    }
}
