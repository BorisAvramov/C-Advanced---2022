 using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> dict = new Dictionary<double, int>();

            foreach (var num in numbers)
            {
                if (!dict.ContainsKey(num))
                {
                    dict.Add(num,1);
                }
                else
                {
                    dict[num]++;

                }
            }

            foreach (var num in dict)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }

        }
    }
}
  

