using System.Collections.Generic;

namespace LeetCode
{
    public interface IListMerger<T>
    {
        IEnumerable<T> Merge(IEnumerable<LinkedList<T>> lists);
    }
}