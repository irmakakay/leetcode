﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Extensions
{
    public static class CollectionExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }

        public static IEnumerable<T> Yield<T>(this T item)
        {
            yield return item;
        }

        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> product = new[] {Enumerable.Empty<T>()};

            return sequences.Aggregate(
                product,
                (acc, seq) => from a in acc from s in seq select a.Concat(new[] {s}));
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || !collection.Any();
        }

        public static T GetAtPosition<T>(this Collections.List.LinkedList<T> list, int position)
        {
            if (position < 0) throw new ArgumentException(nameof(position));

            return list.Skip(position).FirstOrDefault();
        }

        public static IEnumerable<IEnumerable<TResult>> ZipMany<TIn, TResult>(
            this IEnumerable<IEnumerable<TIn>> sequences,
            Func<TIn, TResult> resultSelector)
        {
            var enumerators = sequences.Select(_ => _.GetEnumerator()).ToArray();
            var length = enumerators.Length;
            while (true)
            {
                var result = new TResult[length];
                foreach (var i in Enumerable.Range(0, length))
                {
                    if (!enumerators[i].MoveNext()) yield break;
                    result[i] = resultSelector(enumerators[i].Current);
                }

                yield return result;
            }
        }

        public static IEnumerable<IEnumerable<TResult>> ZipManyWithDifferentLengths<TIn, TResult>(
            this IEnumerable<IEnumerable<TIn>> sequences,
            Func<TIn, TResult> resultSelector)
        {
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

            var sequenceCollection = sequences as IEnumerable<TIn>[] ?? sequences.ToArray();
            if (sequenceCollection.Any(_ => _ == null)) throw new ArgumentException(nameof(sequences));

            return ZipIteratorExtended(sequenceCollection, resultSelector);
        }

        public static IEnumerable<TResult> ZipThree<TFirst, TSecond, TThird, TResult>(
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            IEnumerable<TThird> third,
            Func<TFirst, TSecond, TThird, TResult> resultSelector)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            if (third == null) throw new ArgumentNullException(nameof(third));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

            return ZipIterator(first, second, third, resultSelector);
        }

        public static void InvokeActionByZip<TIn>(
            this IEnumerable<IEnumerable<TIn>> sequences,
            Action<TIn> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            var sequenceCollection = sequences as IEnumerable<TIn>[] ?? sequences.ToArray();
            if (sequenceCollection.Any(_ => _ == null)) throw new ArgumentException(nameof(sequences));

            var enumerators = sequenceCollection.Select(_ => _.GetEnumerator()).ToList();
            var length = enumerators.Count;
            var breakEnumerators = new bool[length];

            while (breakEnumerators.Any(_ => !_))
            {                
                foreach (var i in Enumerable.Range(0, length))
                {
                    if (!enumerators[i].MoveNext()) breakEnumerators[i] = true;
                    else
                    {
                        action(enumerators[i].Current);
                    }
                }                
            }

            enumerators.ForEach(_ => _.Dispose());
        }

        public static IEnumerable<TIn> FecthFromEach<TIn>(
            this IEnumerable<IEnumerable<TIn>> sequences,
            int maxLimit)
        {
            var enumerators = sequences.Select(_ => _.GetEnumerator()).ToList();
            var length = enumerators.Count;
            var breakEnumerators = new bool[length];            
            var count = 0;

            try
            {
                while (count < maxLimit && breakEnumerators.Any(_ => !_))
                {
                    foreach (var i in Enumerable.Range(0, length))
                    {
                        if (count >= maxLimit) break;

                        if (!enumerators[i].MoveNext()) breakEnumerators[i] = true;
                        else
                        {
                            yield return enumerators[i].Current;
                            ++count;
                        }
                    }
                }                
            }
            finally
            {
                enumerators.ForEach(_ => _.Dispose());
            }
        }

        private static IEnumerable<TResult> ZipIterator<TFirst, TSecond, TThird, TResult>(
            IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            IEnumerable<TThird> third,
            Func<TFirst, TSecond, TThird, TResult> resultSelector)
        {
            using (var e1 = first.GetEnumerator())
            using (var e2 = second.GetEnumerator())
            using (var e3 = third.GetEnumerator())
                while (e1.MoveNext() && e2.MoveNext() && e3.MoveNext())
                    yield return resultSelector(e1.Current, e2.Current, e3.Current);
        }

        private static IEnumerable<IEnumerable<TResult>> ZipIteratorExtended<TIn, TResult>(
            IEnumerable<IEnumerable<TIn>> sequences,
            Func<TIn, TResult> resultSelector)
        {
            var enumerators = sequences.Select(_ => _.GetEnumerator()).ToList();
            var length = enumerators.Count;
            var breakEnumerators = new bool[length];
            while (breakEnumerators.Any(_ => !_))
            {
                var result = Enumerable.Empty<TResult>();
                foreach (var i in Enumerable.Range(0, length))
                {
                    if (!enumerators[i].MoveNext()) breakEnumerators[i] = true;
                    else
                    {
                        result = resultSelector(enumerators[i].Current).Yield().Concat(result);
                    }
                }

                yield return result;
            }

            enumerators.ForEach(_ => _.Dispose());
        }
    }
}
