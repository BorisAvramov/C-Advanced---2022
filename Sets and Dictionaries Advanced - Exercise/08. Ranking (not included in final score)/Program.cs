using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking__not_included_in_final_score_
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPass = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> userContestPoints = new Dictionary<string, Dictionary<string, int>>();

            string contestPassInput = Console.ReadLine();
            while (contestPassInput != "end of contests")
            {
                string[] data = contestPassInput.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = data[0];
                string pass = data[1];
                contestPass.Add(contest,pass);
                contestPassInput = Console.ReadLine();
            }
            string submission = Console.ReadLine();
            while (submission != "end of submissions")
            {
                string[] data = submission.Split("=>",StringSplitOptions.RemoveEmptyEntries);
                string contest = data[0];
                string pass = data[1];
                string user = data[2];
                int points = int.Parse(data[3]);
                
                if (contestPass.ContainsKey(contest) && contestPass[contest] == pass)
                {
                    if (!userContestPoints.ContainsKey(user))
                    {
                        userContestPoints.Add(user, new Dictionary<string, int>());
                    }
                    if (!userContestPoints[user].ContainsKey(contest))
                    {
                        userContestPoints[user].Add(contest, points);
                    }
                    else
                    {
                        if (points > userContestPoints[user][contest])
                        {
                            userContestPoints[user][contest] = points;
                            //userTotalPoints[user] = points;
                        }
                    }

                }

                submission = Console.ReadLine();
            }
            string bestUser = "";
            int bestPoints = 0;

            foreach (var user in userContestPoints)
            {
                int curPoint = 0;
                foreach (var item in user.Value)
                {
                    curPoint += item.Value;
                    if (curPoint > bestPoints)
                    {
                        bestPoints = curPoint;
                        bestUser = user.Key;
                    }
                }

                
            }
            Console.WriteLine($"Best candidate is {bestUser} with total {bestPoints} points.");
            
            Console.WriteLine("Ranking: ");
            foreach (var item in userContestPoints.OrderBy(n=>n.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var item2 in item.Value.OrderByDescending(p=>p.Value))
                {
                    Console.WriteLine($"#  {item2.Key} -> {item2.Value}");

                }


            }

        }
    } 
}
