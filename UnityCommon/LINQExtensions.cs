// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityCommon
{
    public static class LinqExtensions
    {
        public static IEnumerable<(T Element1, T Element2)> GetAllPairs<T>(this IList<T> source)
        {
            //TODO i don't understand this)))
            return source.SelectMany((_, i) => source.Where((_, j) => i < j), (x, y) => (x, y));
        }

        public static IEnumerable<T> FindKeysByValue<T, TU>(this Dictionary<T, TU> source, TU value)
        {
            return source.Where(pair => pair.Value!.Equals(value)).Select(pair => pair.Key);
        }
        
        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            return source.MinBy(selector, null);
        }

        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey>? comparer)
        {
            comparer ??= Comparer<TKey>.Default;

            using var sourceIterator = source.GetEnumerator();
            if (!sourceIterator.MoveNext())
            {
                throw new InvalidOperationException("Sequence contains no elements");
            }
            var min = sourceIterator.Current;
            var minKey = selector(min);
            while (sourceIterator.MoveNext())
            {
                var candidate = sourceIterator.Current;
                var candidateProjected = selector(candidate);
                if (comparer.Compare(candidateProjected, minKey) >= 0) continue;
                min = candidate;
                minKey = candidateProjected;
            }
            return min;
        }
        
        public static IEnumerable<TSource> MinsBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            return source.MinsBy(selector, null);
        }

        public static IEnumerable<TSource> MinsBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey>? comparer)
        {
            comparer ??= Comparer<TKey>.Default;

            using var sourceIterator = source.GetEnumerator();
            if (!sourceIterator.MoveNext())
            {
                throw new InvalidOperationException("Sequence contains no elements");
            }
            var min = new List<TSource> { sourceIterator.Current };
            var minKey = selector(min[0]);
            while (sourceIterator.MoveNext())
            {
                var candidate = sourceIterator.Current;
                var candidateProjected = selector(candidate);
                if (comparer.Compare(candidateProjected, minKey) < 0)
                {
                    min.Clear();
                    min.Add(candidate);
                    minKey = candidateProjected;
                }
                else if (comparer.Compare(candidateProjected, minKey) == 0)
                {
                    min.Add(candidate);
                }
            }
            return min;
        }
        
        public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            return source.MaxBy(selector, null);
        }

        public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey>? comparer)
        {
            comparer ??= Comparer<TKey>.Default;

            using var sourceIterator = source.GetEnumerator();
            if (!sourceIterator.MoveNext())
            {
                throw new InvalidOperationException("Sequence contains no elements");
            }
            var max = sourceIterator.Current;
            var maxKey = selector(max);
            while (sourceIterator.MoveNext())
            {
                var candidate = sourceIterator.Current;
                var candidateProjected = selector(candidate);
                if (comparer.Compare(candidateProjected, maxKey) <= 0) continue;
                max = candidate;
                maxKey = candidateProjected;
            }
            return max;
        }
        
        public static IEnumerable<TSource> MaxsBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            return source.MaxsBy(selector, null);
        }

        public static IEnumerable<TSource> MaxsBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey>? comparer)
        {
            comparer ??= Comparer<TKey>.Default;

            using var sourceIterator = source.GetEnumerator();
            if (!sourceIterator.MoveNext())
            {
                throw new InvalidOperationException("Sequence contains no elements");
            }
            var max = new List<TSource> { sourceIterator.Current };
            var maxKey = selector(max[0]);
            while (sourceIterator.MoveNext())
            {
                var candidate = sourceIterator.Current;
                var candidateProjected = selector(candidate);
                if (comparer.Compare(candidateProjected, maxKey) > 0)
                {
                    max.Clear();
                    max.Add(candidate);
                    maxKey = candidateProjected;
                }
                else if (comparer.Compare(candidateProjected, maxKey) == 0)
                {
                    max.Add(candidate);
                }
            }
            return max;
        }
        
        public static IEnumerable<T> ClearNull<T>(this IEnumerable<T> source)
        {
            return source.Where(elem => elem != null);
        }
    }
}