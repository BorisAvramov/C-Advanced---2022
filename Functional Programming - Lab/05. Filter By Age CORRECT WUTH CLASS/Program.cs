using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age_CORRECT_WUTH_CLASS
{
    class Student
    {
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<Student> listStudents = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] data = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = data[0];
                int age = int.Parse(data[1]);

                listStudents.Add(new Student(name, age));

            }

            string condition = Console.ReadLine();
            int conditionAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> tester = Tester(condition, conditionAge);

            listStudents = listStudents.Where(s => tester(s.Age)).ToList();

            Action<Student> printer = Printer(format);

            listStudents.ForEach(printer);

        }

        private static Action<Student> Printer(string format)
        {
            switch (format)
            {
                case "name":
                    return s => Console.WriteLine(s.Name); ;
                case "age":
                    return s => Console.WriteLine(s.Age); ;

                case "name age":
                    return s => Console.WriteLine($"{s.Name} - {s.Age}"); ;

                default:return null;
                    
            }

          
        }

        private static Func<int, bool> Tester(string condition, int conditionAge)
        {
            switch (condition)
            {
                case "older":
                    return a => a >= conditionAge;
                case "younger":
                    return a => a < conditionAge ;

                default:
                    return null;
                    
                    
            }

        }
    }
}
