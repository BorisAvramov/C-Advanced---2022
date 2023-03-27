using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] compounds = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < compounds.Length; j++)
                {
                    set.Add(compounds[j]);
                }

            }

            set = set.OrderBy(x => x).ToHashSet();
            Console.WriteLine(string.Join(" ", set));
            //foreach (var item in set.OrderBy(i=>i))
            //{
            //    Console.Write(item + " ");
            //}


        }
    }
}
