using System;
using System.Collections.Generic;
using System.Linq;

namespace Kottans.LINQ
{
    public static class ExtGroupBy
    {

        /// <summary>
        /// Группирует элементы последовательности в соответствии с заданной функцией селектора ключа.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TK"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<TK, T>> GroupBy<T, TK>(this IEnumerable<T> source, Func<T, TK> keySelector)
        {
            if (source == null || keySelector == null)
            {
                throw new ArgumentNullException();
            }

            return GroupByIterator<T, TK>(source, keySelector);
        }

        private static IEnumerable<IGrouping<TK, T>> GroupByIterator<T, TK>(this IEnumerable<T> source, Func<T, TK> keySelector)
        {
            return null;
        }

        /// <summary>
        /// Группирует элементы последовательности в соответствии с заданной функцией селектора ключа и проецирует элементы каждой группы с помощью указанной функции.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TK"></typeparam>
        /// <typeparam name="TE"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<TK, TE>> GroupBy<T, TK, TE>(this IEnumerable<T> source, Func<T, TK> keySelector, Func<T, TE> elementSelector)
        {
            if (source == null || keySelector == null || elementSelector == null)
            {
                throw new ArgumentNullException();
            }

            return GroupByIterator<T, TK, TE>(source, keySelector, elementSelector);
        }

        private static IEnumerable<IGrouping<TK, TE>> GroupByIterator<T, TK, TE>(IEnumerable<T> source, Func<T, TK> keySelector, Func<T, TE> elementSelector)
        {
            return null;
        }

        /// <summary>
        /// Группирует элементы последовательности в соответствии с заданной функцией селектора ключа и создает результирующее значение для каждой группы и ее ключа.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TK"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="resultSelector"></param>
        /// <returns></returns>
        public static IEnumerable<TR> GroupBy<T, TK, TR>(this IEnumerable<T> source, Func<T, TK> keySelector, Func<TK, IEnumerable<T>, TR> resultSelector)
        {
            if (source == null || keySelector == null || resultSelector == null)
            {
                throw new ArgumentNullException();
            }

            return GroupByIterator<T, TK, TR>(source, keySelector, resultSelector);
        }

        private static IEnumerable<TR> GroupByIterator<T, TK, TR>(IEnumerable<T> source, Func<T, TK> keySelector, Func<TK, IEnumerable<T>, TR> resultSelector)
        {
            return null;
        }

        /// <summary>
        ///  Группирует элементы последовательности в соответствии с заданной функцией селектора ключа и создает результирующее значение для каждой группы и ее ключа. Элементы каждой группы проецируются с помощью указанной функции. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TK"></typeparam>
        /// <typeparam name="TE"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <param name="resultSelector"></param>
        /// <returns></returns>
        public static IEnumerable<TR> GroupBy<T, TK, TE, TR>(this IEnumerable<T> source, Func<T, TK> keySelector, Func<T, TE> elementSelector, Func<TK, IEnumerable<TE>, TR> resultSelector)
        {
            if (source == null || keySelector == null || elementSelector == null || resultSelector == null)
            {
                throw new ArgumentNullException();
            }

            return GroupByIterator<T, TK, TE, TR>(source, keySelector, elementSelector, resultSelector);
        }

        private static IEnumerable<TR> GroupByIterator<T, TK, TE, TR>(IEnumerable<T> source, Func<T, TK> keySelector, Func<T, TE> elementSelector, Func<TK, IEnumerable<TE>, TR> resultSelector)
        {
            return null;
        }

    }
}
