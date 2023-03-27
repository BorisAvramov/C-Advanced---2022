using System;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    internal class StartUp
    {
        static void Main(string[] args)
        {

            DoublyLinkedList list = new DoublyLinkedList();

            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);
            list.AddFirst(4);
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);

            LinkedList<int> lis2 = new LinkedList<int>();

            lis2.AddFirst(1);
            lis2.AddFirst(2);
            lis2.AddFirst(3);

            Console.WriteLine(lis2.First.Next.Next.Value);

            Action<int> act = i => Console.WriteLine(i);

            list.ForEach(act);


            var arr = list.ToArray();

            Console.WriteLine(String.Join(" ", arr));
            

        }
    }
}
