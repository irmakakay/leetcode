using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Collections.Tree
{
    public class TreeNode<T> where T : struct, IComparable<T>
    {
        public TreeNode(T data)
        {
            Data = data;
        }

        public T Data { get; }

        public TreeNode<T> Left { get; set; }

        public TreeNode<T> Right { get; set; }
    }
}
