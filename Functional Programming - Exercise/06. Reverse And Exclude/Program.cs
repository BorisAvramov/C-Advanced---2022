using System;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).Reverse().ToArray();

            int divisibleBy = int.Parse(Console.ReadLine());

            //Predicate<int> isDivisibleBy = n => n % divisibleBy == 0;

            //numbers = numbers.Where(n => !isDivisibleBy (n)).ToArray();

            Func<int, bool> isDivisibleBy = n => n % divisibleBy == 0;

            numbers = numbers.Where(n => !isDivisibleBy(n)).ToArray();


            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
