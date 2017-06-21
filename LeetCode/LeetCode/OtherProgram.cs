using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class OtherProgram
    {
        public static IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            var subsets = new List<IList<int>>() { nums };
            var distinctNum = nums.Distinct().ToArray();
            foreach (var num in distinctNum)
            {
                subsets.Add(new List<int> { num });
            }
            return subsets;
        }

        public static void PrintOutput(IList<IList<int>> values)
        {
            Console.WriteLine("Output:");
            foreach (var level in values)
            {
                foreach (var lvl in level)
                {
                    Console.Write(lvl);
                }
                Console.WriteLine("");
            }
        }
    }
}
