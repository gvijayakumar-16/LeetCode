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
            var list2Items = Console.ReadLine();
            var items2 = AddItems(list2Items);
            ListNode[] listNodesArray = { items1, items2 };
            var output = MergeKLists(listNodesArray);
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
        /// 
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        static ListNode MergeKLists(ListNode[] lists)
        {
            ListNode newList = null;
            List<int> listElements = new List<int>();
            foreach (var list in lists)
            {
                var currentNode = list;
                while (currentNode != null)
                {
                    listElements.Add(currentNode.val);
                    currentNode = currentNode.next;
                }
            }
            listElements.Sort();
            foreach (var item in listElements)
            {
                AddNode(item, ref newList);
            }
            return newList;
        }

        /// <summary>
        /// Append to end of list
        /// </summary>
        /// <param name="tempList"></param>
        /// <param name="originalList"></param>
        static void AppendList(ListNode tempList, ref ListNode originalList)
        {
            if (tempList == null) return;
            if (originalList == null) originalList = tempList;
            else
            {
                var tempNode = originalList;
                while (tempNode != null)
                {
                    if (tempNode.next == null)
                    {
                        tempNode.next = tempList;
                        break;
                    }
                    tempNode = tempNode.next;
                }
            }
        }

        /// <summary>
        /// Get the length of the list
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
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

        /// <summary>
        /// REverse the list
        /// </summary>
        /// <param name="head"></param>
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
