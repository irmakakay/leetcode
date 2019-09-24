﻿using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class ListMerger<T> : IListMerger<T>
    {
        private readonly LinkedList<T> _sorted = new LinkedList<T>(Enumerable.Empty<T>());

        public IEnumerable<T> MergeVertical(IEnumerable<LinkedList<T>> lists)
        {
            var enumerable = lists as LinkedList<T>[] ?? lists.ToArray();
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

        public IEnumerable<T> MergeHorizontal(IEnumerable<LinkedList<T>> lists)
        {
            var final = new LinkedList<T>(Enumerable.Empty<T>());

            lists.ZipManyWithDifferentLength(_ => _).ForEach(i => final.InsertRangeSorted(i));

            return final;            
        }        
    }
}
