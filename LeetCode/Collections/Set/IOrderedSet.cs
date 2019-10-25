using System;
using System.Collections.Generic;

namespace LeetCode.Collections.Set
{
    public interface IOrderedSet<T> : IEnumerable<T> where T : IEquatable<T>
    {
        long Count { get; }

        void Add(T item);

        void AddRange(IEnumerable<T> items);

        bool Remove(T item);
    }
}
