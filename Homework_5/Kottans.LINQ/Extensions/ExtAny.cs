using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtAny
    {

        /// <summary>
        /// Проверяет, содержит ли последовательность какие-либо элементы.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool Any<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in source)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Проверяет, удовлетворяет ли какой-либо элемент последовательности заданному условию.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool Any<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
