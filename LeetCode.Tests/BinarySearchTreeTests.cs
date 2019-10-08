using System.Linq;
using LeetCode.Collections.Tree;
using NUnit.Framework;

namespace LeetCode.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        [Test]
        public void TestTraverseAfterInsert()
        {
            var tree = new BinarySearchTree<int>();
            tree.Insert(13);
            tree.Insert(4);
            tree.Insert(8);
            tree.Insert(11);
            tree.Insert(12);
            tree.Insert(1);
            tree.Insert(5);

            var recursiveResult = tree.Traverse(iterative: false).ToList();
            var iterativeResult = tree.Traverse(iterative: true).ToList();

            CollectionAssert.AreEqual(iterativeResult, recursiveResult);
        }

        [Test]
        public void TestGetMaxDepth()
        {
            var tree = new BinarySearchTree<int>();
            tree.Insert(13);
            tree.Insert(4);
            tree.Insert(3);
            tree.Insert(8);
            tree.Insert(11);
            tree.Insert(12);
            tree.Insert(1);
            tree.Insert(5);

            Assert.That(tree.GetMaxDepth(), Is.EqualTo(5));
        }

        [Test]
        public void TestValidatePositive()
        {
            var tree = new BinarySearchTree<int>();
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(3);

            Assert.IsTrue(tree.IsValid);
        }

        [Test]
        public void TestValidateNegative()
        {
            var tree = new BinarySearchTree<int>
            {
                Root = new TreeNode<int>(5)
                {
                    Left = new TreeNode<int>(1),
                    Right = new TreeNode<int>(4)
                    {
                        Left = new TreeNode<int>(3),
                        Right = new TreeNode<int>(6)
                    }
                }
            };

            Assert.IsFalse(tree.IsValid);
        }
    }
}
