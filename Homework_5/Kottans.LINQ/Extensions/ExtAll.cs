using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtAll
    {

        /// <summary>
        /// Проверяет, все ли элементы последовательности удовлетворяют условию.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool All<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }

            foreach(var item in source)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }

            return true;
        }

    }
}
