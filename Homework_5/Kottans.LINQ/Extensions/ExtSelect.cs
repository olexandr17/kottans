using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtSelect
    {

        /// <summary>
        /// Проецирует каждый элемент последовательности в новую форму.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<TR> Select<T, TR>(this IEnumerable<T> source, Func<T, TR> selector)
        {
            if (source == null || selector == null)
            {
                throw new ArgumentNullException();
            }

            return SelectIterator<T, TR>(source, selector);
        }

        private static IEnumerable<TR> SelectIterator<T, TR>(IEnumerable<T> source, Func<T, TR> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }


        /// <summary>
        /// Проецирует каждый элемент последовательности в новую форму, добавляя индекс элемента.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<TR> Select<T, TR>(this IEnumerable<T> source, Func<T, int, TR> selector)
        {
            if (source == null || selector == null)
            {
                throw new ArgumentNullException();
            }

            return SelectIterator<T, TR>(source, selector);
        }

        private static IEnumerable<TR> SelectIterator<T, TR>(IEnumerable<T> source, Func<T, int, TR> selector)
        {
            int count = 0;
            foreach (var item in source)
            {
                yield return selector(item, count);
                count++;
            }
        }

    }
}
