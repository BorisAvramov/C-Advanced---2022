using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int toEnqueue = input[0];
            int toDequeue = input[1];
            int toContain = input[2];
            Queue<int> queue = new Queue<int>(); 

            string str = "";
            for (int i = 1; i < input[0]; i++)
            {
                str += Console.ReadLine();
            }

            int[] elements = str.Split().Select(int.Parse).ToArray();
            for (int i = 0; i < toEnqueue; i++)
            {
                queue.Enqueue(elements[i]);

            }
            for (int i = 1; i <= toDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(toContain))
            {
                Console.WriteLine("true");


            }
            else if (queue.Count > 0)
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine("0");
            }

        }



    }
}
