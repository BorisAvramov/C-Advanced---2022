using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                int first = int.Parse(stack.Pop());
                string op = stack.Pop();
                int second = int.Parse(stack.Pop());

                if (op == "+")
                {
                    stack.Push((first+second).ToString());
                }
                else
                {
                    stack.Push((first - second).ToString());
                }

            }
            Console.WriteLine(stack.Pop());


        }
    }
}
