using System;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).OrderByDescending(x=>x).Take(3).ToArray();

            foreach (var item in nums)
            {
                Console.Write(item + " ");
            }

        }
    }
}
