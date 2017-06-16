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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static ListNode ReverseBetween(ListNode head, int m, int n)
        {
            int iterator = 0;
            ListNode currentNode = head, splicedNodes = null, newNodes = null;
            string data = string.Empty;
            while (currentNode != null)
            {
                ++iterator;
                if (iterator >= m && iterator <= n)
                {
                    AddNode(Convert.ToInt32(currentNode.val), ref splicedNodes);
                }
                currentNode = currentNode.next;
            }
            Reverse(ref splicedNodes);
            currentNode = head;
            iterator = 0;
            while (currentNode != null)
            {
                ++iterator;
                if (iterator < m)
                {
                    AddNode(currentNode.val, ref newNodes);
                    if (m == iterator - 1) break;
                    currentNode = currentNode.next;
                    continue;
                }
                break;
            }
            var tempNode = newNodes;
            while (tempNode != null)
            {
                if (tempNode.next == null) { tempNode.next = splicedNodes; break; }
                else tempNode = tempNode.next;
            }
            if (newNodes == null) newNodes = splicedNodes;
            while (currentNode != null)
            {
                ++iterator;
                if (iterator > n + 1)
                {
                    AddNode(currentNode.val, ref newNodes);
                }
                currentNode = currentNode.next;
            }

            return newNodes;
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
