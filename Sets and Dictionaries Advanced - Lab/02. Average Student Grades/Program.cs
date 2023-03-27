using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numSt = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> dict = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < numSt; i++)
            {
                string[] data = Console.ReadLine().Split().ToArray();

                string student = data[0];
                decimal grade = decimal.Parse(data[1]);
                if (!dict.ContainsKey(student))
                {
                    dict.Add(student, new List<decimal>());
                }
                dict[student].Add(grade);

            }

            foreach (var studentGrade in dict)
            {
                Console.Write($"{studentGrade.Key} -> ");
                foreach (var grade in studentGrade.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                //Console.Write(string.Join(" ", studentGrade.Value));
                Console.Write($"(avg: {studentGrade.Value.Average():f2})");
                Console.WriteLine();


            }

        }
    }
}
