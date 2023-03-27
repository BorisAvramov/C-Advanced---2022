using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);


            }

            int[] dividers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Func<int, int[], bool> isDivisibleBy = (numbers, dividers) =>
            {
                bool isDivisibleByAll = true;

                for (int i = 0; i < dividers.Length; i++)
                {
                    if (numbers % dividers[i] != 0)
                    {
                        isDivisibleByAll = false;
                    }


                }

                return isDivisibleByAll;
            };

            numbers = numbers.Where(n => isDivisibleBy(n, dividers)).ToList();

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
