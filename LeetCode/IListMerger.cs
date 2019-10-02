using System.Collections.Generic;

namespace LeetCode
{
    public interface IListMerger<T>
    {
        IEnumerable<T> MergeVertical(IEnumerable<Collections.List.LinkedList<T>> lists);

        IEnumerable<T> MergeHorizontal(IEnumerable<Collections.List.LinkedList<T>> lists);
    }
}