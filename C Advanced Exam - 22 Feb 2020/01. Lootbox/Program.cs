using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //10 11 8 13 5 6
            //0 4 7 3 6 23 3


            //10 11 8 13 5 6 3
            // 0 4 7 3 6 23

            // 10 11 8 13 5 6 3 23
            // 0 4 7 3 6

            // 11 8 13 5 6 3 23
            // 0 4 7 3 

            // 8 13 5 6 3 23
            // 0 4 7

            // 8 13 5 6 3 23 7
            // 0 4

            // 13 5 6 3 23 7
            // 0

            // 13 5 6 3 23 7

            // 16 + 14 + 12

            Queue<int> queu = new Queue<int>(Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());

            Stack<int> stack = new Stack<int>(Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());



            List<int> claimedItems = new List<int>();

            while (true)
            {
                if (!queu.Any())
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }
                if (!stack.Any())
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }
                int queueItem = queu.Peek();
                int stackItem = stack.Peek();

                if ((queueItem + stackItem) % 2 == 0)
                {
                    claimedItems.Add(queueItem + stackItem);

                    queu.Dequeue();
                    
                }
                else
                {

                    queu.Enqueue(stackItem);

                }
                stack.Pop();
                

            }

            if (claimedItems.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum(i =>i)}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum(i => i)}");
            }


        }

    }
}   
