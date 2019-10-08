using System;
using System.Collections.Generic;
using LeetCode.Extensions;

namespace LeetCode.Collections.Tree
{
    public class BinarySearchTree<T> where T : struct, IComparable<T>
    {
        private static readonly IComparer<T> Comparer = Comparer<T>.Default;
        
        public TreeNode<T> Root { get; set; }

        public bool IsValid => Root.Validate(null, null);

        public void Insert(T data)
        {
            if (Root == null)
            {
                Root = data.ToTreeNode();
                return;
            }

            var current = Root;
            while (current != null)
            {
                if (Comparer.Compare(data, current.Data) < 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = data.ToTreeNode();
                        break;
                    }

                    current = current.Left;
                }
                else if (Comparer.Compare(data, current.Data) > 0)
                {
                    if (current.Right == null)
                    {
                        current.Right = data.ToTreeNode();
                        break;
                    }

                    current = current.Right;
                }
            }
        }

        public int GetMaxDepth()
        {
            return Root.GetDepth();
        }

        public IEnumerable<T> Traverse(bool iterative = false)
        {
            if (iterative) return Root.TraverseIterative();

            var results = new List<T>();
            Root.TraverseRecursive(results);

            return results;
        }        
    }
}
