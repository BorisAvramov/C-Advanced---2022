using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> dict = 
                new Dictionary<string, Dictionary<string, int>>();
            
            FillDict(dict,n);
            string[] clothToWear = Console.ReadLine().Split();
            PrintDict(dict, clothToWear);
            
        }

        private static void PrintDict(Dictionary<string, Dictionary<string, int>> dict, string[] clothToWear)
        {
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var item2 in item.Value)
                {
                    Console.Write($"* {item2.Key} - {item2.Value}");
                    if (clothToWear[0] == item.Key && item2.Key == clothToWear[1])
                    {
                        Console.Write($" (found!)");
                    }
                    Console.WriteLine();
                }

            }
        }

        private static Dictionary<string, Dictionary<string, int>> FillDict(Dictionary<string, Dictionary<string, int>> dict, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().
                    Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string color = data[0];
                if (!dict.ContainsKey(color))
                {
                    dict.Add(color,new Dictionary<string, int>());
                }
                for (int j = 1; j < data.Length; j++)
                {
                    string curCloth = data[j];
                    if (!dict[color].ContainsKey(curCloth))
                    {
                        dict[color].Add(curCloth, 0);
                    }
                    dict[color][curCloth]++;
                }
            }

            return dict;
        }
    }
}
