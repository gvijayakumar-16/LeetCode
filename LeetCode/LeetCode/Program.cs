using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = TwoSum(Console.ReadLine().Split(',').Select(x => int.Parse(x)).ToArray(), 9);
            WriteOutput(output);
            if (System.Diagnostics.Debugger.IsAttached) Console.ReadKey();
        }

        static int[] TwoSum(int[] nums, int target)
        {
            var indices = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == j) continue;
                    if (nums[i] + nums[j] == target)
                    {
                        indices[0] = i;
                        indices[1] = j;
                        return indices;
                    }
                }
            }
            return indices;
        }

        static void WriteOutput(int[] data)
        {
            foreach (var datum in data)
            {
                Console.WriteLine(datum + ",");
            }
        }
    }
}
