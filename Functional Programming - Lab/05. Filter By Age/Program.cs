using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Filter_By_Age
{
    class Program
    {
       

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> dictNAmeAge = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] data = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = data[0];
                int age = int.Parse(data[1]);

                dictNAmeAge.Add(name, age);


            }

            string condition = Console.ReadLine();
            int conditionAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> tester = Test(condition, conditionAge);

            dictNAmeAge = dictNAmeAge.Where(p => tester(p.Value)).ToDictionary(p => p.Key, p => p.Value);

            Action<KeyValuePair<string, int>> printer = Print(format);

            foreach (var item in dictNAmeAge)
            {
                printer(item);
            }

        }

      

        private static Action<KeyValuePair<string, int>> Print(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine($"{person.Key}");
                case "age":
                    return person => Console.WriteLine(person.Value);
                case "name age":
                    return person => Console.WriteLine($"{person.Key} - {person.Value}");


                default:
                    return null;
                    
            }
        }

        private static Func<int, bool> Test(string condition, int conditionAge)
        {
            switch (condition)
            {
                case "older":
                    return a => a >= conditionAge;
                case "younger":
                    return a => a < conditionAge;
                default:
                    return null;
                    
            }

            
        }
    }
}
