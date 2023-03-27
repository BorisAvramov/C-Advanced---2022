using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedSet = new SortedSet<Person>();

            HashSet<Person> hashSet = new HashSet<Person>();


            int intValue = int.Parse(Console.ReadLine());

            for (int i = 1; i <= intValue; i++)
            {

                string[] stringElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(stringElements[0], int.Parse(stringElements[1]));

                sortedSet.Add(person);
                hashSet.Add(person);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
