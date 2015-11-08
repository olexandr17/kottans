using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtReverse
    {

        /// <summary>
        /// Изменяет порядок элементов последовательности на противоположный.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> Reverse<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            return ReverseIterator<T>(source);
        }

        public static IEnumerable<T> ReverseIterator<T>(IEnumerable<T> source)
        {
            T[] array = new List<T>(source).ToArray();
            for(int i = array.Length - 1; i >= 0; i--)
            {
                yield return array[i];
            }
        }

    }
}
