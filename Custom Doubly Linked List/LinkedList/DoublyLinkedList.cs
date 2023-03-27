using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {

        private class ListNode
        {
            public ListNode(int value)
            {
                Value = value;
            }
            public int Value { get; set; }

            public ListNode NextNode { get; set; }
            public ListNode PreviosNode { get; set; }


        }

        private ListNode head;
        private ListNode tail;

        public int Count { get; set; }


        public void AddFirst(int element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode(element);

            }
            else
            {
                ListNode newHead = new ListNode(element);
                newHead.NextNode = head;
                head.PreviosNode = newHead;
                head = newHead;
            }
            Count++;

        }

        public void AddLast(int element)
        {
            if (Count == 0)
            {

                head = tail = new ListNode(element);
            }
            else
            {
                var newTail = new ListNode(element);
                newTail.PreviosNode = tail;
                tail.NextNode = newTail;
                tail = newTail;

            }
            Count++;

        }
        public int RemoveFirst()
        {
            if (Count == 0)
            {

                throw new InvalidOperationException("The list is empty");
            }
            var firstElement = head.Value;

            head = head.NextNode;

            if (head != null)
            {
                head.PreviosNode = null;
            }
            else
            {
                tail = null;
            }
            Count--;
            return firstElement;
        }
        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var lastElement = tail.Value;

            tail = tail.PreviosNode;

            if (tail != null)
            {
                tail.NextNode = null;

            }
            else
            {
                head = null;
            }
            Count--;
            return lastElement;

        }


        public void ForEach(Action<int> action)
        {
            var currNode = head;
            while (currNode != null)
            {

                action(currNode.Value);
                currNode = currNode.NextNode;
            }


        }

        public int[] ToArray()
        {
            int[] arr = new int[Count];
            int counter = 0;
            ListNode curNode = head;
            while (curNode != null)
            {

                arr[counter] = curNode.Value;
                counter++;
                curNode = curNode.NextNode;
                    

            }
            return arr;
        }
    }
}
