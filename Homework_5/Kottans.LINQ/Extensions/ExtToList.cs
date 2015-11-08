using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtToList
    {

        /// <summary>
        /// Создает список List<T> из объекта IEnumerable<T>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            return new List<T>(source);
        }

    }
}
