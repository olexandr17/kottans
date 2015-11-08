using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtSingle
    {

        /// <summary>
        /// Возвращает единственный элемент последовательности и генерирует исключение, если число элементов последовательности отлично от 1.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T Single<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            T result = default(T);
            var count = 0;

            foreach(var item in source)
            {
                count++;
                result = item;

                if (count > 1)
                {
                    break;
                }
            }

            if (count == 1)
            {
                return result;
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Возвращает единственный элемент последовательности, удовлетворяющий заданному условию, и генерирует исключение, если таких элементов больше одного.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T Single<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }

            T result = default(T);
            var count = 0;

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    count++;
                    result = item;
                }

                if (count > 1)
                {
                    break;
                }
            }

            if (count == 1)
            {
                return result;
            }

            throw new InvalidOperationException();
        }

    }
}
