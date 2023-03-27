using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Person person = new Person();
            //Console.WriteLine(person.Name);
            //Console.WriteLine(person.Age);

            //Person otherPerson = new Person(30);

            //Console.WriteLine(otherPerson.Name);
            //Console.WriteLine(otherPerson.Age);

            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                string name = data[0];
                int age = int.Parse(data[1]);

                Person curPerson = new Person(name, age);

                family.AddMember(curPerson);



            }

             Person oldest =  family.GetOldestMember();

            //Console.WriteLine($"{oldest. Name} {oldest.Age}");

            List<Person> personMoreThan30Age =  family.GetPersonsMoreThan30Age();

            foreach (var item in personMoreThan30Age.OrderBy(p => p.Name))
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}
