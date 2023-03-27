using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();
            Dictionary<char, int> dict = new Dictionary<char, int>();

            FillDict(dict, text);
            PrintSymbol(dict);

        }

        private static void PrintSymbol(Dictionary<char, int> dict)
        {
            foreach (var symbol in dict.OrderBy(s => s.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }

        }

        private static Dictionary<char, int> FillDict(Dictionary<char, int> dict, char[] text)
        {
            foreach (var symbol in text)
            {
                if (!dict.ContainsKey(symbol))
                {
                    dict.Add(symbol, 0);
                }
                dict[symbol]++;
            }


            return dict;
        }
    }
}
