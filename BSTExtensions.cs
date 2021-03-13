using System;

namespace LaboratoryWork2
{
    internal static class BSTExtensions
    {
        internal static BSTNodeBase<T> FindMax<T>(this BSTNodeBase<T> node) where T : IComparable
        {
            if (node == null)
                return null;

            while (true)
            {
                if (node.Right == null) 
                    return node;
                node = node.Right;
            }
        }

        internal static BSTNodeBase<T> FindMin<T>(this BSTNodeBase<T> node) where T : IComparable
        {
            if (node == null)
                return null;

            while (true)
            {
                if (node.Left == null)
                    return node;
                node = node.Left;
            }
        }

        internal static BSTNodeBase<T> NextLower<T>(this BSTNodeBase<T> node) where T : IComparable
        {
            if (node.Parent == null || node.IsLeftChild)
            {
                if (node.Left != null)
                {
                    node = node.Left;

                    while (node.Right != null)
                        node = node.Right;

                    return node;
                }
                
                while (node.Parent != null && node.IsLeftChild)
                    node = node.Parent;

                return node?.Parent;
            }

            if (node.Left != null)
            {
                node = node.Left;
                
                while (node.Right != null)
                    node = node.Right;

                return node;
            }
            return node.Parent;
        }

        internal static BSTNodeBase<T> NextHigher<T>(this BSTNodeBase<T> node) where T : IComparable
        {
            if (node.Parent == null || node.IsLeftChild)
            {
                if (node.Right != null)
                {
                    node = node.Right;

                    while (node.Left != null)
                        node = node.Left;

                    return node;
                }

                return node.Parent;
            }

            if (node.Right != null)
            {
                node = node.Right;

                while (node.Left != null)
                    node = node.Left;

                return node;
            }

            while (node.Parent != null && node.IsRightChild)
                node = node.Parent;

            return node?.Parent;
        }
    

        internal static void UpdateCounts<T>(this BSTNodeBase<T> node, bool spiralUp = false) where T : IComparable
        {
            while (node != null)
            {
                var leftCount = node.Left?.Count ?? 0;
                var rightCount = node.Right?.Count ?? 0;

                node.Count = leftCount + rightCount + 1;

                node = node.Parent;

                if (!spiralUp)
                    break;
            }
        }

        internal static int Position<T>(this BSTNodeBase<T> node, T item) where T : IComparable
        {
            if (node == null)
                return -1;

            var leftCount = node.Left?.Count ?? 0;

            if (node.Value.CompareTo(item) == 0)
                return leftCount;

            if (item.CompareTo(node.Value) < 0)
                return Position(node.Left, item);

            var position = Position(node.Right, item);

            return position < 0 ? position : position + leftCount + 1;
        }
    }
}