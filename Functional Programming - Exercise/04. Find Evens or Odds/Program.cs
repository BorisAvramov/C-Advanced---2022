using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> list = new List<int>();

            for (int i = range[0]; i <= range[1]; i++)
            {
                list.Add(i);

            }

            string filterCommand = Console.ReadLine();

            //Predicate<int> filter = GetFFilter(filterCommand);

            //list = list.Where(n => filter(n)).ToList();

            //Action<List<int>> print = numbers => Console.WriteLine(string.Join(" ", numbers));

            //print(list);
            //=====================================================================

            //Predicate<int> even = n => n % 2 == 0;
            //Predicate<int> odd = n => n % 2 != 0;

            //list = filterCommand == "even" ? list.FindAll(even) : list.FindAll(odd);

            //Action<List<int>> print = numbers => Console.WriteLine(string.Join(" ", numbers));

            //print(list);
            //==========================================================================

            Func<int, bool> even = n => n % 2 == 0;
            Func<int, bool> odd = n => n % 2 != 0;

            list = filterCommand == "even" ? list.Where(even).ToList() : list.Where(odd).ToList();
            Action < List<int> > print = numbers => Console.WriteLine(string.Join(" ", numbers));

            print(list);

        }

        private static Predicate<int> GetFFilter(string filterCommand)
        {
            switch (filterCommand)
            {
                case "odd":
                    return n => n % 2 != 0 ;
                case "even":
                    return n => n % 2 == 0;
                default:
                    return null;
            }

        }
    }
}
