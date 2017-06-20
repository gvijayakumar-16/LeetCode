using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Height = " + GetDepth(root));
        }

        static void ConstructTree(ref TreeNode root)
        {
            root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
        }

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
