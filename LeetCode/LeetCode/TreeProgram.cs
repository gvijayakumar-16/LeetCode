using System;
using System.Collections.Generic;

namespace LeetCode
{
    public static class TreeProgram
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        static IList<IList<int>> LevelOrder(TreeNode root)
        {
            var levelItems = new List<IList<int>>();
            var height = GetDepth(root);
            for (int i = height; i >= 1; --i)
            {
                levelItems.Add(GetSubTree(root, i));
            }
            return levelItems;
        }

        static List<int> GetSubTree(TreeNode node, int level)
        {
            if (node == null) return null;
            if (level == 1) return new List<int>() { node.val };
            var levelItems = new List<int>();
            if (node.left != null)
                levelItems.AddRange(GetSubTree(node.left, level - 1));
            if (node.right != null)
                levelItems.AddRange(GetSubTree(node.right, level - 1));
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
            var leftDepth = MinDepth(root.left);
            var rightDepth = MinDepth(root.right);
            if (rightDepth == 0)
                return 1 + leftDepth;
            else if (leftDepth == 0)
                return 1 + rightDepth;
            return 1 + Math.Min(leftDepth, rightDepth);
        }

        static int GetDepth(TreeNode root)
        {
            if (root == null) return 0;
            int lDepth = GetDepth(root.left);
            int rDepth = GetDepth(root.right);
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
            root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
        }

        /// <summary>
        /// Gets the height
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        static int Height(TreeNode node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(Height(node.left), Height(node.right));
        }

        public static bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;
            var leftSubTreeHeight = Height(root.left);
            var rightSubTreeHeight = Height(root.right);
            return Math.Abs(leftSubTreeHeight - rightSubTreeHeight) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
        }
    }
}
