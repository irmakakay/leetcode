using LeetCode.Collections.Set;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Tests
{
    [TestFixture]
    public class OrderedSetTests
    {
        [Test]
        public void AddRange_InsertsItem()
        {
            var list = new OrderedSet<int>();

            var items = new[] { 1, 2, 3, 4, 5, 6, 7 };

            list.AddRange(items);

            Assert.AreEqual(7, list.Count);
            CollectionAssert.AreEqual(items, list);
        }

        [Test]
        public void AddRange_IgnoresDuplicateInput()
        {
            var list = new OrderedSet<int>();

            var items = new[] { 1, 2, 3, 4, 5, 6, 7 };
            var items2 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 7, 6, 6, 3 };            

            list.AddRange(items2);

            CollectionAssert.AreEqual(items, list);
        }

        [Test]
        public void Remove_RemovesItemIfItemExists()
        {
            var list = new OrderedSet<int>();

            var items = new[] { 1, 2, 3, 4, 5, 6, 7 };
            list.AddRange(items);
            var removed = list.Remove(3);
            Assert.IsTrue(removed);
            removed = list.Remove(1);
            Assert.IsTrue(removed);

            Assert.AreEqual(5, list.Count);
            CollectionAssert.AreEqual(new[] { 2, 4, 5, 6, 7 }, list);
        }

        [Test]
        public void Remove_IgnoresItemIfItemDoesNotExist()
        {
            var list = new OrderedSet<int>();

            var items = new[] { 1, 2, 3, 4, 5, 6, 7 };
            list.AddRange(items);
            var removed = list.Remove(9);
            Assert.IsFalse(removed);
            removed = list.Remove(11);
            Assert.IsFalse(removed);

            Assert.AreEqual(7, list.Count);
            CollectionAssert.AreEqual(items, list);
        }
    }
}
