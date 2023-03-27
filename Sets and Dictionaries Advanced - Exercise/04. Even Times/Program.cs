using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> dict = new Dictionary<int, int>();
            GetDict(dict, n);
            PrintNumbers(dict);
        }
        private static void PrintNumbers(Dictionary<int, int> dict)
        {
            foreach (var kvp in dict.Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine(kvp.Key);
            }
            //foreach (var item in dict)
            //{
            //    if (item.Value % 2 == 0)
            //    {
            //        Console.WriteLine(item.Key);
            //    }
            //}
        }
        private static Dictionary<int, int> GetDict(Dictionary<int, int> dict, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!dict.ContainsKey(num))
                {
                    dict.Add(num,0);
                }
                
                dict[num]++;
                
                

            }
            return dict;
        }
    }
}
