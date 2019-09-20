using System.Collections.Generic;

namespace LeetCode
{
    public interface ILinkedList<T> : IEnumerable<T>
    {
        ListNode<T> Head { get; }

        void Insert(T data);

        void InsertSorted(T data);

        void InsertRange(IEnumerable<T> range);

        void InsertRangeSorted(IEnumerable<T> range);
    }
}