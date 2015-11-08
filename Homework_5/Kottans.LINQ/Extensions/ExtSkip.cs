using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtSkip
    {

        /// <summary>
        /// Пропускает заданное число элементов в последовательности и возвращает остальные элементы.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<T> Skip<T>(this IEnumerable<T> source, int count)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            return SkipIterator<T>(source, count);
        }

        public static IEnumerable<T> SkipIterator<T>(IEnumerable<T> source, int count)
        {
            foreach(var item in source)
            {
                if (count == 0)
                {
                    yield return item;
                }
                else
                {
                    count--;
                }
            }
        }

    }
}
