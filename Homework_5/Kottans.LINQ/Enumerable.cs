using System;
using System.Collections.Generic;

namespace Kottans.LINQ
{
    public static class Enumerable
    {

        public static IEnumerable<int> Range(int start, int count)
        {
            if (count < 0 || (int.MaxValue - count - start + 1) < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return RangeIterator(start, count);
        }

        private static IEnumerable<int> RangeIterator(int start, int count)
        {
            for (var i = 0; i < count; i++)
            {
                yield return start + i;
            }
        }


        public static IEnumerable<T> Repeat<T>(T item, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return RepeatIterator<T>(item, count);
        }

        private static IEnumerable<T> RepeatIterator<T>(T item, int count)
        {
            for (var i = 0; i < count; i++)
            {
                yield return item;
            }
        }


        public static IEnumerable<T> Empty<T>()
        {
            return TSingleton<T>.Instance;
        }

    }

    internal static class TSingleton<T>
    {
        public static readonly IEnumerable<T> Instance = new T[0];
    }

}
