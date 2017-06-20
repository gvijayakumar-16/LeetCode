using System;

namespace LeetCode
{
    class Entry
    {
        static void Main(string[] args)
        {
            //ExecuteLinkedListProgram();
            ExecuteTreeProgram();
            if (System.Diagnostics.Debugger.IsAttached) Console.ReadKey();
        }

        static void ExecuteLinkedListProgram()
        {
            var list1Items = Console.ReadLine();
            var items1 = LinkedListProgram.AddItems(list1Items);
            var list2Items = Console.ReadLine();
            var items2 = LinkedListProgram.AddItems(list2Items);
            ListNode[] listNodesArray = { items1, items2 };
            var output = LinkedListProgram.MergeKLists(listNodesArray);
            LinkedListProgram.WriteOutput(output);
        }

        static void ExecuteTreeProgram()
        {
            TreeProgram.PrintTree(null);
        }
    }
}