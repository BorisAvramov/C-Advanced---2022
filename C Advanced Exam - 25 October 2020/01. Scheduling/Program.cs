using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Stack<int> tasksStack = new Stack<int>(Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));


            Queue<int> threadsQueue = new Queue<int>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));


            int taskToBeKilled = int.Parse(Console.ReadLine());

            int threadKilling = 0;

            while (true)
            {
                int curThread = threadsQueue.Peek();
                int curTask = tasksStack.Peek();

                if (curTask == taskToBeKilled)
                {
                    tasksStack.Pop();
                    threadKilling = curThread;
                    break;
                }

                if (curThread >= curTask)
                {
                    tasksStack.Pop();
                    threadsQueue.Dequeue();
                }
                if (curThread < curTask)
                {
                    threadsQueue.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {threadKilling} killed task {taskToBeKilled}");

            Console.WriteLine(String.Join(" ", threadsQueue));

        }
    }
}
