using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (var symbol in input)
            {
                stack.Push(symbol);

            }

            //1.    char[] result = stack.ToArray();

            // Console.WriteLine(string.Join("", result));


            /* 2. */    //foreach (var item in stack)
                        //{
                        //    Console.Write(item);

            //}

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }


        }
    }
}
