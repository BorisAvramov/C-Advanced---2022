using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Func<string, bool> Upper = w => char.IsUpper(w[0]);

            List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(Upper).ToList();

            Action<List<string>> print = w => Console.WriteLine(string.Join("\n", w));

            print(input);

            //input.ForEach (w=>Console.WriteLine(w));
            

            //Predicate<string> Upper = w => char.IsUpper(w[0]);

            //string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Where(w => Upper(w)).ToArray();

            //foreach (var item in input)
            //{
            //    Console.WriteLine(item);

            //}


        }
    }
}
