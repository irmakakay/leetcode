using System;
using NUnit.Framework;

namespace LeetCode.Tests
{
    [TestFixture]
    public class ListMergerTests
    {
        private ListMerger<int> _sut;

        [Test]
        public void MergeVertical_ReturnsSortedList()
        {
            ConfigureSut();

            var l1 = new LinkedList<int>(new[] {1, 4, 5});
            var l2 = new LinkedList<int>(new[] {1, 3, 4});
            var l3 = new LinkedList<int>(new[] {2, 6});

            var final = _sut.MergeVertical(new[] {l1, l2, l3});
            CollectionAssert.AreEqual(new[] {1, 1, 2, 3, 4, 4, 5, 6}, final, final.ToString());
        }

        [Test]
        public void MergeHorizontal_ReturnsSortedList()
        {
            ConfigureSut();

            var l1 = new LinkedList<int>(new[] {1, 4, 5});
            var l2 = new LinkedList<int>(new[] {1, 3, 4});
            var l3 = new LinkedList<int>(new[] {2, 6});

            var final = _sut.MergeHorizontal(new[] {l1, l2, l3});
            CollectionAssert.AreEqual(new[] {1, 1, 2, 3, 4, 4, 5, 6}, final, final.ToString());
        }

        [Test]
        public void MergeHorizontal_ThrowsException_WhenAnyInputSequenceIsNull()
        {
            ConfigureSut();

            var l1 = new LinkedList<int>(new[] { 1, 4, 5 });
            var l2 = new LinkedList<int>(new[] { 1, 3, 4 });
            LinkedList<int> l3 = null;

            Assert.Throws<ArgumentException>(() => _sut.MergeHorizontal(new[] { l1, l2, l3 }));
        }

        private void ConfigureSut()
        {
            _sut = new ListMerger<int>();
        }
    }
}
