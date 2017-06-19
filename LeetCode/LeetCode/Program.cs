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
            var output = ReverseKGroup(items1, Convert.ToInt32(Console.ReadLine()));
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

        /// <summary>
        /// Fails for [1,2,3,4,5]
        /// 1
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        static ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode currentNode = head, prevNode = null, newList = null, tempList = null;
            var listLength = GetLength(head);
            var visitedLength = 0;
            int iterator = 0;
            while (currentNode != null)
            {
                ++iterator;
                if (iterator <= k)
                {
                    ++visitedLength;
                    AddNode(currentNode.val, ref tempList);
                    prevNode = currentNode;
                    currentNode = currentNode.next;
                    if (iterator == k) Reverse(ref tempList);
                    if (currentNode == null) AppendList(tempList, ref newList);
                    continue;
                }
                AppendList(tempList, ref newList);
                tempList = null;
                if (k + visitedLength - 1 <= listLength)
                {
                    iterator = 0;
                    continue;
                }
                ++visitedLength;
                AddNode(currentNode.val, ref newList);
                prevNode = currentNode;
                currentNode = currentNode.next;
            }
            return newList;
        }

        static void AppendList(ListNode tempList, ref ListNode originalList)
        {
            if (tempList == null) return;
            if (originalList == null) originalList = tempList;
            else
            {
                var c1Node = originalList;
                while (c1Node != null)
                {
                    if (c1Node.next == null)
                    {
                        c1Node.next = tempList;
                        break;
                    }
                    c1Node = c1Node.next;
                }
            }
        }

        static int GetLength(ListNode head)
        {
            var currentNode = head;
            var iterator = 0;
            while (currentNode != null)
            {
                ++iterator;
                currentNode = currentNode.next;
            }
            return iterator;
        }

        static void Reverse(ref ListNode head)
        {
            ListNode currentNode = head, prevNode = null, nextNode = null;
            while (currentNode != null)
            {
                nextNode = currentNode.next;
                currentNode.next = prevNode;
                prevNode = currentNode;
                currentNode = nextNode;
            }
            head = prevNode;
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
