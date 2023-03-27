using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] circleChildren = Console.ReadLine().Split();

            int nToss = int.Parse(Console.ReadLine());

            Queue<string> queueCircle = new Queue<string>(circleChildren);

            int countToss = 1;
            while (queueCircle.Count >1)
            {
                if (nToss != countToss)
                {
                    string kid = queueCircle.Dequeue();
                    queueCircle.Enqueue(kid);
                    countToss++;
                }
                else
                {
                    string kid = queueCircle.Dequeue();
                    Console.WriteLine($"Removed {kid}");
                    countToss = 1;
                }
            }

            Console.WriteLine($"Last is {queueCircle.Dequeue()}");  


        }
    }
}
