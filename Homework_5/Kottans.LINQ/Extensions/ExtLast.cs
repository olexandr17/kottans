using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtLast
    {

        /// <summary>
        /// Возвращает последний элемент последовательности.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T Last<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            IList<T> list = source as IList<T>;
            if (list != null)
            {
                if (list.Count > 0)
                {
                    return list[list.Count - 1];
                }
            }
            else
            {
                bool isFound = false;
                T result = default(T);
                foreach (var item in source)
                {
                    isFound = true;
                    result = item;
                }

                if (isFound)
                {
                    return result;
                }
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Возвращает последний элемент последовательности, удовлетворяющий указанному условию.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T Last<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }

            bool isFound = false;
            T result = default(T);
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    isFound = true;
                    result = item;
                }
            }

            if (isFound)
            {
                return result;
            }

            throw new InvalidOperationException();
        }

    }
}
