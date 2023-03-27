using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(" ").ToList();

            Dictionary<string, Predicate<string>> dictPredicates = new Dictionary<string, Predicate<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Print")
                {
                    break;
                }
                string[] data = input.Split(';');
                string command = data[0];
                string filterType = data[1];
                string filterParameter = data[2];

                Predicate<string> filterPredicates = GetPredicates(filterType, filterParameter);

                if (command == "Add filter")
                {
                    dictPredicates.Add(filterType + filterParameter, filterPredicates);
                }
                else if (command == "Remove filter")
                {
                    dictPredicates.Remove(filterType + filterParameter);
                }
            }

            foreach (var (key, value) in dictPredicates)
            {
                guests.RemoveAll(value);


            }
            if (guests.Any())
            {
                Console.WriteLine(string.Join(" ", guests));
            }

        }

        private static Predicate<string> GetPredicates(string filterType, string filterParameter)
        {
            if (filterType == "Starts with")
            {
                return guest => guest.StartsWith(filterParameter);
            }
            if (filterType == "Ends with")
            {
                return guest => guest.EndsWith(filterParameter);
            }
            if (filterType == "Length")
            {
                return guest => guest.Length == int.Parse(filterParameter);
            }
            
                return guest => guest.Contains(filterParameter);
            
        }
    }
}
