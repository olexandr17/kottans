using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtFirstOrDefault
    {

        /// <summary>
        /// Возвращает первый элемент последовательности или значение по умолчанию, если последовательность не содержит элементов.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T FirstOrDefault<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in source)
            {
                return item;
            }

            return default(T);
        }

        /// <summary>
        /// Возвращает первый удовлетворяющий условию элемент последовательности или значение по умолчанию, если ни одного такого элемента не найдено.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
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

            return default(T);
        }

    }
}
