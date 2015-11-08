using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class ExtSum
    {

        /// <summary>
        /// Вычисляет сумму последовательности значений типа Int32.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int Sum(this IEnumerable<int> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            int sum = 0;
            foreach(var item in source)
            {
                sum = checked(sum + item);
            }

            return sum;
        }

        /// <summary>
        /// Вычисляет сумму последовательности значений Int32 обнуляемого типа.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int? Sum(this IEnumerable<int?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            int? sum = 0;
            foreach (var item in source)
            {
                if (item != null)
                {
                    sum = checked(sum + item.GetValueOrDefault());
                }
            }

            return sum;
        }

        /// <summary>
        /// Вычисляет сумму последовательности значений типа Int32, получаемой в результате применения функции преобразования к каждому элементу входной последовательности.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static int Sum<T>(this IEnumerable<T> source, Func<T, int> selector)
        {
            return source.Select(selector).Sum();
        }

        /// <summary>
        /// Вычисляет сумму последовательности значений Int32 обнуляемого типа, получаемой в результате применения функции преобразования к каждому элементу входной последовательности.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static int? Sum<T>(this IEnumerable<T> source, Func<T, int?> selector)
        {
            return source.Select(selector).Sum();
        }

        /// <summary>
        /// Вычисляет сумму последовательности значений типа Int64.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static long Sum(this IEnumerable<long> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            long sum = 0;
            foreach (var item in source)
            {
                sum = checked(sum + item);
            }

            return sum;
        }

        /// <summary>
        /// Вычисляет сумму последовательности значений Int64 обнуляемого типа.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static long? Sum(this IEnumerable<long?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            long? sum = 0;
            foreach (var item in source)
            {
                if (item != null)
                {
                    sum = checked(sum + item.GetValueOrDefault());
                }
            }

            return sum;
        }

        /// <summary>
        /// Вычисляет сумму последовательности значений типа Int64, получаемой в результате применения функции преобразования к каждому элементу входной последовательности.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static long Sum<T>(this IEnumerable<T> source, Func<T, long> selector)
        {
            return source.Select(selector).Sum();
        }

        /// <summary>
        /// Вычисляет сумму последовательности значений Int64 обнуляемого типа, получаемой в результате применения функции преобразования к каждому элементу входной последовательности.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static long? Sum<T>(this IEnumerable<T> source, Func<T, long?> selector)
        {
            return source.Select(selector).Sum();
        }

        /// <summary>
        /// Вычисляет сумму последовательности значений типа Decimal.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static decimal Sum(this IEnumerable<decimal> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            decimal sum = 0;
            foreach (var item in source)
            {
                sum = sum + item;
            }

            return sum;
        }

        /// <summary>
        /// Вычисляет сумму последовательности значений Decimal обнуляемого типа.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static decimal? Sum(this IEnumerable<decimal?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            decimal? sum = 0;
            foreach (var item in source)
            {
                if (item != null)
                {
                    sum = sum + item.GetValueOrDefault();
                }
            }

            return sum;
        }

        /// <summary>
        /// Вычисляет сумму последовательности значений типа Decimal, получаемой в результате применения функции преобразования к каждому элементу входной последовательности.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static decimal Sum<T>(this IEnumerable<T> source, Func<T, decimal> selector)
        {
            return source.Select(selector).Sum();
        }

        /// <summary>
        /// Вычисляет сумму последовательности значений Decimal обнуляемого типа, получаемой в результате применения функции преобразования к каждому элементу входной последовательности.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static decimal? Sum<T>(this IEnumerable<T> source, Func<T, decimal?> selector)
        {
            return source.Select(selector).Sum();
        }

        /// <summary>
        /// Вычисляет сумму последовательности значений Single обнуляемого типа.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static float Sum(this IEnumerable<float> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            double sum = 0;
            foreach (var item in source)
            {
                sum = sum + item;
            }

            return (float)sum;
        }

        /// <summary>
        /// Вычисляет сумму последовательности значений типа Single.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static float? Sum(this IEnumerable<float?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            double sum = 0;
            foreach (var item in source)
            {
                if (item != null)
                {
                    sum = sum + item.GetValueOrDefault();
                }
            }

            return (float?)sum;
        }

        /// <summary>
        /// Вычисляет сумму последовательности значений типа Single, получаемой в результате применения функции преобразования к каждому элементу входной последовательности.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static float Sum<T>(this IEnumerable<T> source, Func<T, float> selector)
        {
            return source.Select(selector).Sum();
        }

        /// <summary>
        /// Вычисляет сумму последовательности значений Single обнуляемого типа, получаемой в результате применения функции преобразования к каждому элементу входной последовательности.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static float? Sum<T>(this IEnumerable<T> source, Func<T, float?> selector)
        {
            return source.Select(selector).Sum();
        }

        /// <summary>
        /// Вычисляет сумму последовательности значений типа Double.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static double Sum(this IEnumerable<double> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            double sum = 0;
            foreach (var item in source)
            {
                sum = sum + item;
            }

            return sum;
        }

        /// <summary>
        /// Вычисляет сумму последовательности значений Double обнуляемого типа.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static double? Sum(this IEnumerable<double?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            double? sum = 0;
            foreach (var item in source)
            {
                if (item != null)
                {
                    sum = sum + item.GetValueOrDefault();
                }
            }

            return sum;
        }

        /// <summary>
        /// Вычисляет сумму последовательности значений типа Double, получаемой в результате применения функции преобразования к каждому элементу входной последовательности.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static double Sum<T>(this IEnumerable<T> source, Func<T, double> selector)
        {
            return source.Select(selector).Sum();
        }

        /// <summary>
        /// Вычисляет сумму последовательности значений Double обнуляемого типа, получаемой в результате применения функции преобразования к каждому элементу входной последовательности.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static double? Sum<T>(this IEnumerable<T> source, Func<T, double?> selector)
        {
            return source.Select(selector).Sum();
        }

    }
}
