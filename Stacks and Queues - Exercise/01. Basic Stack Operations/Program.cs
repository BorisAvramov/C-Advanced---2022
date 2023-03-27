using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();


            int toPush = input[0];
            int toPop = input[1];
            int toCOntains = input[2];  

            Stack<int> stack = new Stack<int>();

            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < toPush; i++)

            {
                stack.Push(integers[i]);


            }

            for (int i = 1; i <= toPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(toCOntains))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count > 0)
            {
                Console.WriteLine($"{stack.Min()}");
            }
            else
            {
                Console.WriteLine("0");
            }
           

            


         }
    }
}
