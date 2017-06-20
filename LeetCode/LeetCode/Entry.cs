using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Entry
    {
        static void Main(string[] args)
        {
            var list1Items = Console.ReadLine();
            var items1 = LinkedListProgram.AddItems(list1Items);
            var list2Items = Console.ReadLine();
            var items2 = LinkedListProgram.AddItems(list2Items);
            ListNode[] listNodesArray = { items1, items2 };
            var output = LinkedListProgram.MergeKLists(listNodesArray);
            LinkedListProgram.WriteOutput(output);
            if (System.Diagnostics.Debugger.IsAttached) Console.ReadKey();
        }
    }
}
