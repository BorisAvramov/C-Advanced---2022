using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results__not_included_in_final_score_
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> userMaxPoints = new Dictionary<string, int>();

            Dictionary<string, int> languageSubmissionCount = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();
               
                if (input == "exam finished")
                {
                    break;
                }
                string[] data = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
                if (data[1] == "banned")
                {
                    userMaxPoints.Remove(data[0]);
                    continue;

                }
                string user = data[0];
                string language = data[1];
                int points = int.Parse(data[2]);
                if (userMaxPoints.ContainsKey(user) == false)
                {
                    userMaxPoints.Add(user, 0);
                   

                }
                if (points > userMaxPoints[user])
                {
                    userMaxPoints[user] = points;
                }
         
                if (languageSubmissionCount.ContainsKey(language) == false)
                {
                    languageSubmissionCount.Add(language,1);
                }
                else
                {
                    languageSubmissionCount[language]++;
                }

            }

            Console.WriteLine("Results:");
            foreach (var item in userMaxPoints.OrderByDescending(u=>u.Value).ThenBy(u=>u.Key))
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var item in languageSubmissionCount.OrderByDescending(l=>l.Value).ThenBy(l=>l.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
          
        }
    }
}
