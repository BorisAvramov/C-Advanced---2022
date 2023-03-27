using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Stack<char> stack = new Stack<char>();

            bool balanced = true;

            foreach (var item in input)
            {
                if (item == '{' || item == '[' || item == '(' )
                {
                    stack.Push(item);
                }
                else if (!stack.Any())
                {
                    balanced = false;
                    break;
                }
                else if (item == '}' && stack.Peek() == '{')
                {
                    stack.Pop();
                }
                else if (item == ']' && stack.Peek() == '[')
                {
                    stack.Pop();
                }
                else if (item == ')' && stack.Peek() == '(')
                {
                    stack.Pop();
                }
                else
                {
                    balanced = false;
                }


            }
            if (balanced == false )
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }


        }
    }
}
