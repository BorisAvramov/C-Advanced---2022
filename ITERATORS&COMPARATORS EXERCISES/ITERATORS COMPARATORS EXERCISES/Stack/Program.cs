using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    public class Program
    {
        static void Main(string[] args)
        {

            MyStack<string> myStack = new MyStack<string>();

            while (true)
            {
                List<string> stringList = Console.ReadLine().Split(new char []{ ',', ' '},StringSplitOptions.RemoveEmptyEntries).ToList();
                if (stringList[0] == "END")
                {
                    break;
                }
                if (stringList[0] == "Push")
                {

                    var elements = stringList.Skip(1).ToList();
                    myStack.Push(elements);



                }
                if (stringList[0] == "Pop")
                {
                    if (myStack.Count > 0)
                    {
                        myStack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("No elements");
                        return;
                    }
                    
                }

            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
