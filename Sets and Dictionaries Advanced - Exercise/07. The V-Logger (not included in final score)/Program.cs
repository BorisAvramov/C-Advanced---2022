using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger__not_included_in_final_score_
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Dictionary<string, List<string>> dictFollowers = new Dictionary<string, List<string>>();
            Dictionary<string, int []> numFollowersFolowing = new Dictionary<string, int[]>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Statistics")
                {
                    break;
                }
                string[] data = input.Split();

                if (data[1] == "joined")
                {
                    string vlogger = data[0];
                    if (!dictFollowers.ContainsKey(vlogger))
                    {
                        dictFollowers.Add(data[0], new List<string>());
                    }
                    if (!numFollowersFolowing.ContainsKey(vlogger))
                    {
                        numFollowersFolowing.Add(vlogger, new int[2]);
                    }
                }
                if (data[1] == "followed")
                {
                    string follower = data[0];
                    string following = data[2];
                    if ((!dictFollowers.ContainsKey(follower) || ! dictFollowers.ContainsKey(following)) 
                        || follower == following || dictFollowers[following].Contains(follower) )
                    {
                        continue;
                    }
                    dictFollowers[following].Add(follower);
                    numFollowersFolowing[following][0]++;
                    numFollowersFolowing[follower][1]++;


                }

               
            }
            Console.WriteLine($"The V-Logger has a total of {dictFollowers.Count} vloggers in its logs.");

            int count = 1;
            
            //Dictionary<string, int[]> ordereddict = numFollowersFolowing.OrderByDescending(f => f.Value[0]).ThenBy(f => f.Value[1]).ToDictionary(f => f.Key, f => f.Value);
            
            int countFamousFollowers = 0;
            
            foreach (var item in numFollowersFolowing.OrderByDescending(f => f.Value[0]).ThenBy(f=>f.Value[1]))
            {
                
                Console.WriteLine($"{count}. {item.Key} : {item.Value[0]} followers, {item.Value[1]} following");
                count++;
                if (countFamousFollowers < 1)
                {
                    foreach (var item2 in dictFollowers)
                    {
                        countFamousFollowers++;
                        if (item2.Key == item.Key)
                        {
                            foreach (var item3 in item2.Value.OrderBy(f=>f))
                            {
                                Console.WriteLine($"*  {item3}");
                            }
                        }

                    }
                }
               
                
            }
        

        }
    }
}
