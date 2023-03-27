using System;

namespace CustomQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> myQueue = new Queue<int>();

            myQueue.Enqueue(1);

            myQueue.Dequeue();


        }
    }
}
