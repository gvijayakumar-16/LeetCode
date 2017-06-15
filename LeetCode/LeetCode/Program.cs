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
        /// Fails for [3,5], 1,2
        /// </summary>
        /// <param name="head"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static ListNode ReverseBetween(ListNode head, int m, int n)
        {
            int iterator = 0, count = 0;
            ListNode currentNode = head, mNode = null, nNode = null, nextNode = null, prevNode = null, mMinus1Node = null, nPlus1Node = null;
            while (currentNode != null)
            {
                ++iterator;
                if (iterator >= m && iterator <= n) ++count;
                if (iterator == m - 1) mMinus1Node = currentNode;
                if (iterator == n + 1)
                {
                    nPlus1Node = currentNode; break;
                }
                else if (iterator == m)
                {
                    mNode = currentNode;
                }
                else if (iterator == n)
                {
                    nNode = currentNode;
                }
                currentNode = currentNode.next;
            }
            currentNode = mNode;
            iterator = 0;
            prevNode = nPlus1Node;
            while (currentNode != null)
            {
                ++iterator;
                nextNode = currentNode.next;
                currentNode.next = prevNode;
                prevNode = currentNode;
                currentNode = nextNode;
                if (iterator == count) break;
            }
            if (mMinus1Node != null)
                mMinus1Node.next = prevNode;
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
