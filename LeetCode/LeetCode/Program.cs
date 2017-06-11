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
            var items1 = AddItems(list1Items);

            var output = ReverseBetween(items1, Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
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
                while (true)
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

        static ListNode ReverseBetween(ListNode head, int m, int n)
        {
            var iterator = 1;
            var currentNode = head;
            ListNode mNode = null, nNode = null;
            while (true)
            {
                if (iterator == m)
                {
                    mNode = currentNode;
                }
                if (iterator == n)
                {
                    nNode = currentNode;
                }
                if (mNode != null && nNode != null) break;
                currentNode = currentNode.next;
                ++iterator;
            }
            var tempNode = mNode.next;
            mNode.next = nNode.next;
            mNode.next = tempNode;
            return head;
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
