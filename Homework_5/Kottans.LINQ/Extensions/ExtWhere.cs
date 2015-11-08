using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtWhere
    {

        /// <summary>
        /// Выполняет фильтрацию последовательности значений на основе заданного предиката.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }
            
            return WhereIterator<T>(source, predicate);
        }

        public static IEnumerable<T> WhereIterator<T>(IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach(var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        ///  Выполняет фильтрацию последовательности значений на основе заданного предиката. Индекс каждого элемента используется в логике функции предиката. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }

            return WhereIterator<T>(source, predicate);
        }

        public static IEnumerable<T> WhereIterator<T>(IEnumerable<T> source, Func<T, int, bool> predicate)
        {
            var count = 0;
            foreach (var item in source)
            {
                if (predicate(item, count))
                {
                    yield return item;
                }
                count++;
            }
        }

    }
}
