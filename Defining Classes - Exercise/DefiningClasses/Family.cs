using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    class Family
    {
        public Family()
        {
            ListPersonsInFamily = new List<Person>();
        }

        public List<Person> ListPersonsInFamily { get; set; }


        public void AddMember(Person person)
        {
            ListPersonsInFamily.Add(person);

        }

        //public string GetOldestMember() 
        //{
        //    int max = int.MinValue;
        //    string maxName = "";
        //    foreach (var person in ListPersonsInFamily)
        //    {
        //        if (person.Age > max)
        //        {

        //            max = person.Age;
        //            maxName = person.Name;
        //        }
        //    }

        //    return $"{maxName} {max}";
        //}

        public Person GetOldestMember()
        {
            int oldestAge = int.MinValue;
            Person oldestPerson = new Person();
            foreach (var pers in ListPersonsInFamily)
            {
                if (pers.Age > oldestAge)
                {
                    oldestPerson = pers;

                    oldestAge = pers.Age;


                }
            }
            return oldestPerson;
        }

        public List<Person> GetPersonsMoreThan30Age()
        {
            ListPersonsInFamily = ListPersonsInFamily.Where(p => p.Age > 30).ToList();
            return ListPersonsInFamily;

        }
    }
}
