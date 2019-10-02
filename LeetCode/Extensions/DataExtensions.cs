using System;
using LeetCode.Collections.Tree;

namespace LeetCode.Extensions
{
    public static class DataExtensions
    {
        public static TreeNode<T> ToTreeNode<T>(this T data) where T : struct, IComparable<T>
        {
            return new TreeNode<T>(data);
        }
    }
}
