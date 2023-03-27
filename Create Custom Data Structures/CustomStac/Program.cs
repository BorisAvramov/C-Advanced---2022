using System;
using System.Collections;

namespace CustomStack
{
    public class Program

    {
        static void Main(string[] args)
        {
            Stack<int> myStack = new Stack<int>();

            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);

            Console.WriteLine(myStack.Pop());

            Console.WriteLine(myStack.Peek());

            myStack.ForEach(Console.WriteLine);

            Console.WriteLine(myStack.Count);

            
        }
    }
}
