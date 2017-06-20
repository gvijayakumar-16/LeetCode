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

        }
    }
}
