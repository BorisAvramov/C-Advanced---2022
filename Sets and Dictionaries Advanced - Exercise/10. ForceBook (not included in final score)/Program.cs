using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._ForceBook__not_included_in_final_score_
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> sideUser = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Lumpawaroo")
                {
                    break;
                }
                if (input.Contains('|'))
                {
                    string[] data = input.Split(" | " );
                    string side = data[0];
                    string user = data[1];
                    if (!sideUser.ContainsKey(side))
                    {
                        sideUser.Add(side, new List<string>());
                       
                    }
                    if (!sideUser[side].Contains(user) && !sideUser.Values.Any(u=>u.Contains(user)))
                    {
                        sideUser[side].Add(user);
                    }


                }
                else
                {
                    string[] data = input.Split(" -> ");
                    string user = data[0];
                    string side = data[1];

                    foreach (var item in sideUser)
                    {
                        if (item.Value.Contains(user) && item.Key != side)
                        {
                            item.Value.Remove(user);


                        }
                    }
                    if (sideUser.Any(u=>u.Value.Contains(user)) == false)
                    {
                         if (!sideUser.ContainsKey(side))
                    {
                        sideUser.Add(side, new List<string>());
                    }
                    sideUser[side].Add(user);
                   
                    Console.WriteLine($"{user} joins the {side  } side!");
                    }
                   
                }


            }
            foreach (var item in sideUser.OrderByDescending(u=>u.Value.Count).ThenBy(u=>u.Key))
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                    foreach (var item2 in item.Value.OrderBy(u=>u))
                    {
                        Console.WriteLine($"! {item2}");
                    }

                }


            }   

        }
    }
}
