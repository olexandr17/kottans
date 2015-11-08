using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtSelectMany
    {

        /// <summary>
        /// Проецирует каждый элемент последовательности в объект IEnumerable<T> и объединяет результирующие последовательности в одну последовательность.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<TR> SelectMany<T, TR>(this IEnumerable<T> source, Func<T, IEnumerable<TR>> selector)
        {
            if (source == null || selector == null)
            {
                throw new ArgumentNullException();
            }

            return SelectManyIterator<T, TR>(source, selector);
        }

        private static IEnumerable<TR> SelectManyIterator<T, TR>(IEnumerable<T> source, Func<T, IEnumerable<TR>> selector)
        {
            foreach (T item in source)
            {
                foreach (TR item2 in selector(item))
                {
                    yield return item2;
                }
            }
        }

        /// <summary>
        ///  Проецирует каждый элемент последовательности в объект IEnumerable<T> и объединяет результирующие последовательности в одну последовательность. Индекс каждого элемента исходной последовательности используется в проецированной форме этого элемента. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<TR> SelectMany<T, TR>(this IEnumerable<T> source, Func<T, int, IEnumerable<TR>> selector)
        {
            if (source == null || selector == null)
            {
                throw new ArgumentNullException();
            }

            return SelectManyIterator<T, TR>(source, selector);
        }

        private static IEnumerable<TR> SelectManyIterator<T, TR>(IEnumerable<T> source, Func<T, int, IEnumerable<TR>> selector)
        {
            int count = 0;
            foreach (T item in source)
            {
                foreach (TR item2 in selector(item, count))
                {
                    yield return item2;
                }

                count++;
            }
        }

        /// <summary>
        /// Проецирует каждый элемент последовательности в объект IEnumerable<T>, объединяет результирующие последовательности в одну и вызывает функцию селектора результата для каждого элемента этой последовательности.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TC"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="resSelector"></param>
        /// <returns></returns>
        public static IEnumerable<TR> SelectMany<T, TC, TR>(this IEnumerable<T> source, Func<T, IEnumerable<TC>> selector, Func<T, TC, TR> resSelector)
        {
            if (source == null || selector == null || resSelector == null)
            {
                throw new ArgumentNullException();
            }

            return SelectManyIterator<T, TC, TR>(source, selector, resSelector);
        }

        private static IEnumerable<TR> SelectManyIterator<T, TC, TR>(IEnumerable<T> source, Func<T, IEnumerable<TC>> selector, Func<T, TC, TR> resSelector)
        {
            foreach (T item in source)
            {
                foreach (TC item2 in selector(item))
                {
                    yield return resSelector(item, item2);
                }
            }
        }

        /// <summary>
        ///  Проецирует каждый элемент последовательности в объект IEnumerable<T>, объединяет результирующие последовательности в одну и вызывает функцию селектора результата для каждого элемента этой последовательности. Индекс каждого элемента исходной последовательности используется в промежуточной проецированной форме этого элемента. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TC"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="resSelector"></param>
        /// <returns></returns>
        public static IEnumerable<TR> SelectMany<T, TC, TR>(this IEnumerable<T> source, Func<T, int, IEnumerable<TC>> selector, Func<T, TC, TR> resSelector)
        {
            if (source == null || selector == null || resSelector == null)
            {
                throw new ArgumentNullException();
            }

            return SelectManyIterator<T, TC, TR>(source, selector, resSelector);
        }

        private static IEnumerable<TR> SelectManyIterator<T, TC, TR>(IEnumerable<T> source, Func<T, int, IEnumerable<TC>> selector, Func<T, TC, TR> resSelector)
        {
            int count = 0;
            foreach (T item in source)
            {
                foreach (TC item2 in selector(item, count))
                {
                    yield return resSelector(item, item2);
                }
                count++;
            }
        }

    }
}
