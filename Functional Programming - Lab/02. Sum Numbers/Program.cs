using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n)).ToArray();

            Action<int[]> count = numbers => Console.WriteLine(numbers.Length);

            count(numbers);

            Action<int[]> sum = numbers => Console.WriteLine(numbers.Sum());

            sum(numbers);

            //Console.WriteLine(numbers.Length);
            //Console.WriteLine(numbers.Sum());


        }
    }
}
