using System.Collections.Generic;

namespace LaboratoryWork2
{
    public class TreeNode
    {
        public TreeNode(string data)
        {
            Data = data;
        }

        public string Data { get; set; }

        public TreeNode Left { get; set; }

        public TreeNode Right { get; set; }

        public void Add(TreeNode node)
        {
            if (string.CompareOrdinal(node.Data, Data) < 0)
            {
                if (Left == null)
                    Left = node;
                else Left.Add(node);
            }
            else
            {
                if (Right == null)
                    Right = node;
                else Right.Add(node);
            }
        }

        public IEnumerable<string> Transform()
        {
            if (Left != null)
                foreach (var value in Left.Transform())
                    yield return value;

            yield return Data;

            if (Right != null)
                foreach (var value in Right.Transform())
                    yield return value;
        }
    }

}