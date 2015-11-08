using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtSingleOrDefault
    {

        /// <summary>
        /// Возвращает единственный элемент последовательности или значение по умолчанию, если последовательность пуста; если в последовательности более одного элемента, генерируется исключение.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T SingleOrDefault<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            T result = default(T);
            var count = 0;

            foreach (var item in source)
            {
                count++;
                result = item;

                if (count > 1)
                {
                    throw new InvalidOperationException();
                }
            }

            return result;
        }

        /// <summary>
        /// Возвращает единственный элемент последовательности, удовлетворяющий заданному условию, или значение по умолчанию, если такого элемента не существует; если условию удовлетворяет более одного элемента, генерируется исключение.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T SingleOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
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
                    throw new InvalidOperationException();
                }
            }

            return result;
        }

    }
}
