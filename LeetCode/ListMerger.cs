using System.Collections.Generic;
using System.Linq;
using LeetCode.Extensions;

namespace LeetCode
{
    public class ListMerger<T> : IListMerger<T>
    {
        private readonly Collections.List.LinkedList<T> _sorted = new Collections.List.LinkedList<T>(Enumerable.Empty<T>());

        public IEnumerable<T> MergeVertical(IEnumerable<Collections.List.LinkedList<T>> lists)
        {
            var enumerable = lists as Collections.List.LinkedList<T>[] ?? lists.ToArray();
            var count = enumerable.Length;

            var head = enumerable.FirstOrDefault();
            var tail = enumerable.Skip(1).Take(count - 1);

            _sorted.InsertRange(head);

            foreach (var list in tail)
            {
                _sorted.InsertRangeSorted(list);
            }

            return _sorted;
        }

        public IEnumerable<T> MergeHorizontal(IEnumerable<Collections.List.LinkedList<T>> lists)
        {
            var final = new Collections.List.LinkedList<T>(Enumerable.Empty<T>());

            lists.InvokeActionByZip(_ => final.InsertSorted(_));

            return final;
        }        
    }
}
