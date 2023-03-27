using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles__not_included_in_final_score_
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queeCupsCap = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> stackBottlesWithWater = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int wastedWater = 0;

            while (queeCupsCap.Any() && stackBottlesWithWater.Any())
            {
                
                int curCap = queeCupsCap.Peek();
                while (curCap > 0 )
                {
                    int curBotlle = stackBottlesWithWater.Peek();
                    if (curBotlle >= curCap)
                    {
                        queeCupsCap.Dequeue();
                        stackBottlesWithWater.Pop();
                        wastedWater += curBotlle - curCap;

                        break;
                    }
                    else
                    {
                        curCap -= curBotlle;
                        stackBottlesWithWater.Pop();

                    }
                }
               
            }
            if (queeCupsCap.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", queeCupsCap)}");
                
            }
            if (stackBottlesWithWater.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", stackBottlesWithWater)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");

        }
    }
}
