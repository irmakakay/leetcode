using LeetCode.Collections.List;

namespace LeetCode.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var merger = new ListMerger<int>();

            var l0 = new LinkedList<int>(new[] { 11, 14, 5, 3, 7 });
            var l1 = new LinkedList<int>(new[] { 1, 4, 5 });
            var l2 = new LinkedList<int>(new[] { 1, 3, 4 });
            var l3 = new LinkedList<int>(new[] { 2, 6 });

            var final = merger.MergeVertical(new[] { l0, l1, l2, l3 });
        }
    }
}
