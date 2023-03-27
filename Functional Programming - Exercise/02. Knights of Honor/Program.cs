using System;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ");

            Action<string> print = n => Console.WriteLine($"Sir {n}");

            foreach (var item in names)
            {
                print(item);
            }
        }
    }
}
