using System;
using System.Collections.Generic;

namespace LeetCode
{
    public static class TreeProgram
    {
        public class TreeNode
        {
            private readonly int _value;
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public TreeNode(int x) { _value = x; }
            public int GetValue() => _value;
        }

        static IList<IList<int>> LevelOrder(TreeNode root)
        {
            var levelItems = new List<IList<int>>();
            var height = GetDepth(root);
            for (int i = height; i >= 1; --i)
            {
                levelItems.Add(GetLevelElements(root, i));
            }
            return levelItems;
        }

        static List<int> GetLevelElements(TreeNode node, int level)
        {
            if (node == null) return null;
            if (level == 1) return new List<int>() { node.GetValue() };
            var levelItems = new List<int>();
            if (node.Left != null)
                levelItems.AddRange(GetLevelElements(node.Left, level - 1));
            if (node.Right != null)
                levelItems.AddRange(GetLevelElements(node.Right, level - 1));
            return levelItems;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        static int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            var leftDepth = MinDepth(root.Left);
            var rightDepth = MinDepth(root.Right);
            if (rightDepth == 0)
                return 1 + leftDepth;
            if (leftDepth == 0)
                return 1 + rightDepth;
            return 1 + Math.Min(leftDepth, rightDepth);
        }

        static int GetDepth(TreeNode root)
        {
            if (root == null) return 0;
            int lDepth = GetDepth(root.Left);
            int rDepth = GetDepth(root.Right);
            if (lDepth > rDepth)
                return lDepth + 1;
            else
                return rDepth + 1;
        }

        public static void PrintTree(TreeNode root)
        {
            ConstructTree(ref root);
            var levels = LevelOrder(root);
            Console.Write("Level Order Traversal:");
            foreach (var level in levels)
            {
                foreach (var lvl in level)
                {
                    Console.WriteLine(lvl);
                }
            }
        }

        static void ConstructTree(ref TreeNode root)
        {
            root = new TreeNode(3)
            {
                Left = new TreeNode(9),
                Right = new TreeNode(20)
                {
                    Left = new TreeNode(15),
                    Right = new TreeNode(7)
                }
            };
        }

        /// <summary>
        /// Gets the height
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        static int Height(TreeNode node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        public static bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;
            var leftSubTreeHeight = Height(root.Left);
            var rightSubTreeHeight = Height(root.Right);
            return Math.Abs(leftSubTreeHeight - rightSubTreeHeight) <= 1 && IsBalanced(root.Left) && IsBalanced(root.Right);
        }
    }
}
