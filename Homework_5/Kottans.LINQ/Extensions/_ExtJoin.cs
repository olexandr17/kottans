using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtJoin
    {

        /// <summary>
        ///  Устанавливает корреляцию между элементами двух последовательностей на основе сопоставления ключей. Для сравнения ключей используется компаратор проверки на равенство по умолчанию. 
        /// </summary>
        /// <typeparam name="TO"></typeparam>
        /// <typeparam name="TI"></typeparam>
        /// <typeparam name="TK"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="source"></param>
        /// <param name="inner"></param>
        /// <param name="outerKeySelector"></param>
        /// <param name="innerKeySelector"></param>
        /// <param name="resultSelector"></param>
        /// <returns></returns>
        public static IEnumerable<TR> Join<TO, TI, TK, TR>(this IEnumerable<TO> source, IEnumerable<TI> inner, Func<TO, TK> outerKeySelector, Func<TI, TK> innerKeySelector, Func<TO, TI, TR> resultSelector)
        {
            return source.Join<TO, TI, TK, TR>(inner, outerKeySelector, innerKeySelector, resultSelector, null);
        }

        /// <summary>
        ///  Устанавливает корреляцию между элементами двух последовательностей на основе сопоставления ключей. Для сравнения ключей используется указанный компаратор IEqualityComparer<T>. 
        /// </summary>
        /// <typeparam name="TO"></typeparam>
        /// <typeparam name="TI"></typeparam>
        /// <typeparam name="TK"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="source"></param>
        /// <param name="inner"></param>
        /// <param name="outerKeySelector"></param>
        /// <param name="innerKeySelector"></param>
        /// <param name="resultSelector"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<TR> Join<TO, TI, TK, TR>(this IEnumerable<TO> source, IEnumerable<TI> inner, Func<TO, TK> outerKeySelector, Func<TI, TK> innerKeySelector, Func<TO, TI, TR> resultSelector, IEqualityComparer<TK> comparer)
        {
            if (source == null || inner == null || outerKeySelector == null || innerKeySelector == null || resultSelector == null)
            {
                throw new ArgumentNullException();
            }

            return JoinIterator(source, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        private static IEnumerable<TR> JoinIterator<TO, TI, TK, TR>(IEnumerable<TO> outer, IEnumerable<TI> inner, Func<TO, TK> outerKeySelector, Func<TI, TK> innerKeySelector, Func<TO, TI, TR> resultSelector, IEqualityComparer<TK> comparer)
        {
            throw new NotImplementedException();
        }

    }

}
