using System;
using System.Collections.Generic;
using System.Linq;
using LeetCode.Collections.Tree;

namespace LeetCode.Extensions
{
    public static class TreeNodeExtensions
    {
        public static int GetDepth<T>(this TreeNode<T> node) where T: struct, IComparable<T>
        {
            if (node == null) return 0;

            var left = node.Left.GetDepth();
            var right = node.Right.GetDepth();

            return (left > right ? left : right) + 1;
        }


        public static IEnumerable<T> TraverseIterative<T>(this TreeNode<T> node) where T : struct, IComparable<T>
        {
            var stack = new Stack<TreeNode<T>>();

            var current = node;

            while (true)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                if (!stack.Any()) break;

                current = stack.Pop();
                yield return current.Data;
                current = current.Right;
            }
        }

        public static void TraverseRecursive<T>(this TreeNode<T> node, List<T> results) where T : struct, IComparable<T>
        {
            if (node == null) return;

            TraverseRecursive(node.Left, results);
            results.Add(node.Data);
            TraverseRecursive(node.Right, results);
        }
    }
}
