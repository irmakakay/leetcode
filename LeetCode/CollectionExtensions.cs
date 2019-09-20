using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public static class CollectionExtensions
    {
        public static void ForEach<T>(this LinkedList<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || !collection.Any();
        }
    }
}
