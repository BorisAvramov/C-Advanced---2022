using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] stringElements = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = stringElements[0];
                int age = int.Parse(stringElements[1]);
                string town = stringElements[2];

                Person curPerson = new Person(name, age, town);
                list.Add(curPerson);

                
            }

            int position = int.Parse(Console.ReadLine());

            Person persontoCompare = list[position - 1];

            int equal = 0;
            int diff = 0;
            foreach (var item in list)
            {
                if (item.CompareTo(persontoCompare) == 0)
                {
                    equal++;
                }
                else
                {
                    diff++;
                }
            }

            if (equal == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {diff} {list.Count}");
            }


        }
    }
}
