using NUnit.Framework;

namespace LeetCode.Tests
{
    [TestFixture]
    public class ListMergerTests
    {
        private ListMerger<int> _sut;

        [Test]
        public void MergesSortedLists()
        {
            ConfigureSut();
            
            var l1 = new LinkedList<int>(new[] {1, 4, 5});
            var l2 = new LinkedList<int>(new[] {1, 3, 4});
            var l3 = new LinkedList<int>(new[] {2, 6});

            var final = _sut.Merge(new[] {l1, l2, l3});

            CollectionAssert.AreEqual(new[] {1, 1, 2, 3, 4, 4, 5, 6}, final, final.ToString());
        }

        private void ConfigureSut()
        {
            _sut = new ListMerger<int>();
        }
    }
}
