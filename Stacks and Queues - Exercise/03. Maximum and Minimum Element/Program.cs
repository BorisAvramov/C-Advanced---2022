using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();




            for (int i = 1; i <= n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (input[0] == 1)
                {
                    stack.Push(input[1]);

                }
                if (input[0] == 2)
                {
                    if (stack.Count>0)
                    {
                        stack.Pop();
                    }
                }
                if (input[0] == 3)
                {
                    if (stack.Count>0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                if (input[0] == 4)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            
            }
            if (stack.Count > 0)
            {
                Console.WriteLine(string.Join(", ", stack));
            }

        }
    }
}
