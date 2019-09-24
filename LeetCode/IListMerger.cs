using System.Collections.Generic;

namespace LeetCode
{
    public interface IListMerger<T>
    {
        IEnumerable<T> MergeVertical(IEnumerable<LinkedList<T>> lists);

        IEnumerable<T> MergeHorizontal(IEnumerable<LinkedList<T>> lists);
    }
}