using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator_SECOND
{
    class Program
    {
        static void Main(string[] args)
        {

            string [] input = Console.ReadLine().Split();

            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                int fisrtNum = int.Parse(stack.Pop());
                string op = stack.Pop();
                int secondNum = int.Parse(stack.Pop());

                if (op == "+")
                {
                    stack.Push((fisrtNum + secondNum).ToString());
                }
                else if (op == "-")
                {
                    stack.Push((fisrtNum - secondNum).ToString());
                }


            }

            Console.WriteLine(string.Join("", stack));

        }
    }
}
