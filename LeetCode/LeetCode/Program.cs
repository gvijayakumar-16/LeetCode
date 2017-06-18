using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1Items = Console.ReadLine();
            var list2Items = Console.ReadLine();
            //var items1 = AddItems(list1Items);
            //var items2 = AddItems(list2Items);
            //var output = MergeTwoLists(items1, items2);
            var output = MergeTwoLists(new ListNode(1), null);
            WriteOutput(output);
            if (System.Diagnostics.Debugger.IsAttached) Console.ReadKey();
        }

        /// <summary>
        /// Build the linked list
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        static ListNode AddItems(string data)
        {
            ListNode nodeBeginning = null;
            foreach (var item in data.Split(','))
            {
                AddNode(Convert.ToInt32(item), ref nodeBeginning);
            }
            return nodeBeginning;
        }

        /// <summary>
        /// Add the value to the list
        /// </summary>
        /// <param name="value"></param>
        /// <param name="linkedList"></param>
        static void AddNode(int value, ref ListNode linkedList)
        {
            if (linkedList == null)
            {
                linkedList = new ListNode(Convert.ToInt32(value));
            }
            else
            {
                ListNode currentNode = linkedList;
                while (currentNode != null)
                {
                    if (currentNode.next == null)
                    {
                        currentNode.next = new ListNode(value);
                        break;
                    }
                    currentNode = currentNode.next;
                }
            }
        }

        static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode l1CurrentNode = l1, l2CurrentNode = l2, mergedList = null;
            while (l1 != null || l2 != null)
            {
                if (l1 == null)
                {
                    AddNode(l2.val, ref mergedList);
                    l2 = l2.next;
                }
                else if (l2 == null)
                {
                    AddNode(l1.val, ref mergedList);
                    l1 = l1.next;
                }
                else if (l1.val < l2.val)
                {
                    AddNode(l1.val, ref mergedList);
                    l1 = l1.next;
                }
                else
                {
                    AddNode(l2.val, ref mergedList);
                    l2 = l2.next;
                }
            }
            return mergedList;
        }

        /// <summary>
        /// Write the output to console
        /// </summary>
        /// <param name="data"></param>
        static void WriteOutput(ListNode data)
        {
            var currentNode = data;
            while (currentNode != null)
            {
                Console.Write(currentNode.val + "->");
                currentNode = currentNode.next;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
