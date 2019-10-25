using LeetCode.Collections.List;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var merger = new ListMerger<int>();

            //var l0 = new LinkedList<int>(new[] { 11, 14, 5, 3, 7 });
            //var l1 = new LinkedList<int>(new[] { 1, 4, 5 });
            //var l2 = new LinkedList<int>(new[] { 1, 3, 4 });
            //var l3 = new LinkedList<int>(new[] { 2, 6 });

            //var final = merger.MergeVertical(new[] { l0, l1, l2, l3 });

            var items = Find(new object[] { 1, 2, 5, 2, 10, 2, 100, 2 });
            var f = items.First();

            items = Find(new object[] { 0, 1, 1, 1, 1, 1 });
        }

        private static IEnumerable<object> Find(object[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            object previous = null;
            foreach (var current in array)
            {
                if (Predicate(current)) yield return previous;

                previous = current;
            }
        }

        private static bool Predicate(object o)
        {
            return o != null && (int)o == 2;
        }
    }
}
