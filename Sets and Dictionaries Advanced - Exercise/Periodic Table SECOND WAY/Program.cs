using System;
using System.Collections.Generic;
using System.Linq;

namespace Periodic_Table_SECOND_WAY
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();
            GetCompunds(set, n);
            PrintCompounds(set);  
        }

        private static void PrintCompounds(HashSet<string> set)
        {
            Console.WriteLine(string.Join(" ", set.OrderBy(c=>c)));
        }

        private static HashSet<string> GetCompunds(HashSet<string> set, int n)
        {
           for (int i = 0; i < n; i++)
            {
                List<string> list = Console.ReadLine().Split().ToList();
                list.ForEach(compund => set.Add(compund));


            }
            return set;

        }
    }
}
