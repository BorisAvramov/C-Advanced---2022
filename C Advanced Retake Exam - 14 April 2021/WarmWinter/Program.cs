using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Stack<int> intStackHats = new Stack<int>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));


            List<int> sets = new List<int>();

            Queue<int> intQueueScarfs = new Queue<int>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));

            while (intStackHats.Any() && intQueueScarfs.Any())
            {
                int hat = intStackHats.Peek();
                int scarf = intQueueScarfs.Peek();

                if (hat > scarf)
                {
                    int price = hat + scarf;
                    sets.Add(price);
                    intStackHats.Pop();
                    intQueueScarfs.Dequeue();
                }
                if (scarf > hat)
                {
                    intStackHats.Pop();
                    continue;
                }
                if (scarf == hat)
                {
                    intQueueScarfs.Dequeue();
                    intStackHats.Pop();
                    intStackHats.Push(++hat);
                }   

            }

            int maxValue = int.MinValue;
            foreach (var item in sets)
            {
                if (item > maxValue)
                {
                    maxValue = item;
                }
            }
            Console.WriteLine($"The most expensive set is: {maxValue}");
            Console.WriteLine(String.Join(" ", sets));

        }
    }
}
