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

            var output = RemoveNthFromEnd(items1, Convert.ToInt32(Console.ReadLine()));
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

        static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var length = GetListLength(head);
            var nodeIndexToRemove = length + 1 - n;
            ListNode currentNode = head, prevNode = null;
            var iterator = 0;
            while (currentNode != null)
            {
                iterator++;
                if (nodeIndexToRemove == iterator)
                {
                    if (prevNode != null)
                        prevNode.next = currentNode.next;
                    else
                        head = currentNode.next;
                    break;
                }
                prevNode = currentNode;
                currentNode = currentNode.next;
            }
            return head;
        }

        static int GetListLength(ListNode head)
        {
            var currentNode = head;
            var iterator = 0;
            while (currentNode != null)
            {
                iterator++;
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
