using LeetCode.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCode.Tests
{
    [TestFixture]
    public class CollectionExtentionsTests
    {        
        [TestCaseSource(nameof(CountResultPairs))]
        public void TestFetchFromEach(Tuple<int, int[]> pair)
        {
            var l1 = new[] { 1, 11, 111, 1111, 11111 };
            var l2 = new[] { 2, 22 };
            var l3 = new[] { 3 };
            var l4 = new[] { 4, 44, 444, 4444 };
            var l5 = new[] { 5, 55, 555 };

            var input = new[] { l1, l2, l3, l4, l5 };

            var result = input.FecthFromEach(pair.Item1);

            CollectionAssert.AreEqual(pair.Item2, result);
        }

        private static IEnumerable<Tuple<int, int[]>> CountResultPairs
        {
            get
            {
                yield return Tuple.Create(10, new[] { 1, 2, 3, 4, 5, 11, 22, 44, 55, 111 });
                yield return Tuple.Create(11, new[] { 1, 2, 3, 4, 5, 11, 22, 44, 55, 111, 444 });
                yield return Tuple.Create(12, new[] { 1, 2, 3, 4, 5, 11, 22, 44, 55, 111, 444, 555 });
                yield return Tuple.Create(13, new[] { 1, 2, 3, 4, 5, 11, 22, 44, 55, 111, 444, 555, 1111 });
                yield return Tuple.Create(14, new[] { 1, 2, 3, 4, 5, 11, 22, 44, 55, 111, 444, 555, 1111, 4444 });
                yield return Tuple.Create(15, new[] { 1, 2, 3, 4, 5, 11, 22, 44, 55, 111, 444, 555, 1111, 4444, 11111 });
                yield return Tuple.Create(115, new[] { 1, 2, 3, 4, 5, 11, 22, 44, 55, 111, 444, 555, 1111, 4444, 11111 });
            }
        }
    }
}
