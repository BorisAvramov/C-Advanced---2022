using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> dict = new Dictionary<string, int>();

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int curSteel = steel.Peek();
                int curCarbon = carbon.Peek();

                ForgeSwors(dict, curSteel, curCarbon, steel, carbon);
                    


            }

            if (dict.Any())
            {
                int count = 0;
                foreach (var sword in dict)
                {
                    count += sword.Value;
                }
                Console.WriteLine($"You have forged {count} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            string toPrint = steel.Any() ? $"Steel left: {string.Join(", ", steel)}" : "Steel left: none";
            Console.WriteLine(toPrint);

            string roPrint2 = carbon.Any() ? $"Carbon left: {string.Join(", ", carbon)}" : "Carbon left: none";
            Console.WriteLine(roPrint2);

            foreach (var sword in dict.OrderBy(s=>s.Key))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");

            }
        }

        private static void ForgeSwors(Dictionary<string, int> dict, int curSteel, int curCarbon, Queue<int> steel, Stack<int> carbon)
        {
            int result = curCarbon + curSteel;

            bool isForged = false;

            if (result == 70)
            {
                if (!dict.ContainsKey("Gladius"))
                {
                    dict.Add("Gladius", 0);
                }
                dict["Gladius"]++;
                isForged = true;
            }


            if (result == 80)
            {
                if (!dict.ContainsKey("Shamshir"))
                {
                    dict.Add("Shamshir", 0);
                }
                dict["Shamshir"]++;
                isForged = true;

            }

            if (result == 90)
            {
                if (!dict.ContainsKey("Katana"))
                {
                    dict.Add("Katana", 0);
                }
                dict["Katana"]++;
                isForged = true;

            }

            if (result == 110)
            {
                if (!dict.ContainsKey("Sabre"))
                {
                    dict.Add("Sabre", 0);
                }
                dict["Sabre"]++;
                isForged = true;

            }

            if (result == 150)
            {
                if (!dict.ContainsKey("Broadsword"))
                {
                    dict.Add("Broadsword", 0);
                }
                dict["Broadsword"]++;
                isForged = true;

            }

            steel.Dequeue();
            if (isForged)
            {
               
                carbon.Pop();
            }
            else
            {
                carbon.Pop();
                carbon.Push(curCarbon + 5);
            }
          
        }
    }
}
