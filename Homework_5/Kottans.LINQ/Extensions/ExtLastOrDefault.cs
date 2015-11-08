using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtLastOrDefault
    {

        /// <summary>
        /// Возвращает последний элемент последовательности или значение по умолчанию, если последовательность не содержит элементов.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T LastOrDefault<T>(this IEnumerable<T> source)
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
                T result = default(T);
                foreach (var item in source)
                {
                    result = item;
                }

                return result;
            }

            return default(T);
        }

        /// <summary>
        /// Возвращает последний элемент последовательности, удовлетворяющий указанному условию, или значение по умолчанию, если ни одного такого элемента не найдено.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T LastOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }

            T result = default(T);
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    result = item;
                }
            }

            return result;
        }

    }
}
