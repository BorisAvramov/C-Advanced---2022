using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            

            //int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            //Func<int, bool> smallest = IsMSmallest(numbers);

            //numbers = numbers.Where(n => smallest(n)).ToArray();
            
           
            //Action<int> print = n => Console.WriteLine(n);

            //1========================
            //foreach (var item in numbers)
            //{
            //    print(item);
            //    break;
            //}

            //2===========================
            //int[] result = numbers.Distinct().ToArray();
            //Console.WriteLine(string.Join(" ", result));

            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Func<int[], int> func = numbers => numbers.Min();
            int smallesdt = func(numbers);
            Console.WriteLine(smallesdt);

        }

        private static Func<int, bool> IsMSmallest(int[] numbers)
        {
            int smallest = numbers.Min(); ;

            return n => n == smallest;


        }
    }
}
