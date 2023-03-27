using System;
using System.Collections.Generic;

namespace _06._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> hashSet = new HashSet<string>();

            for (int i = 1; i <= n; i++)
            {
                hashSet.Add(Console.ReadLine());

            }
            foreach (var name in hashSet)
            {
                Console.WriteLine(name);
            }

        }
    }
}
