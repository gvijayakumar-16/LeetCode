using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1Items = Console.ReadLine();
            var list2Items = Console.ReadLine();
            var items1 = AddItems(list1Items);
            var items2 = AddItems(list2Items);

            var output = AddTwoNumbers(items1, items2);
            WriteOutput(output);
            if (System.Diagnostics.Debugger.IsAttached) Console.ReadKey();
        }

        static ListNode AddItems(string data)
        {
            ListNode nodeBeginning = null;
            foreach (var item in data.Split(','))
            {
                AddNode(Convert.ToInt32(item), ref nodeBeginning);
            }
            return nodeBeginning;
        }

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

        static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null) throw new ArgumentNullException();
            ListNode summedList = null;
            ListNode l1CurrentNode = l1;
            ListNode l2CurrentNode = l2;
            var firstValue = new StringBuilder();
            var secondValue = new StringBuilder();
            ListNode currentElement1 = l1;
            ListNode currentElement2 = l2;
            while (true)
            {
                if (currentElement1 == null && currentElement2 == null) break;

                if (currentElement1 != null)
                {
                    firstValue.Append(currentElement1.val.ToString());
                    currentElement1 = currentElement1.next;
                }
                if (currentElement2 != null)
                {
                    secondValue.Append(currentElement2.val.ToString());
                    currentElement2 = currentElement2.next;
                }
            }
            var reversed = firstValue.ToString().ToCharArray();
            Array.Reverse(reversed);
            var firstNumber = Convert.ToInt64(new string(reversed));
            reversed = secondValue.ToString().ToCharArray();
            Array.Reverse(reversed);
            var secondNumber = Convert.ToInt64(new string(reversed));
            var total = firstNumber + secondNumber;

            reversed = total.ToString().ToCharArray();
            Array.Reverse(reversed);
            foreach (var item in reversed)
            {
                AddNode(item - '0', ref summedList);
            }
            return summedList;
        }

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
