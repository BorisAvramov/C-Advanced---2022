using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bakery_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<double> waterQueue = new Queue<double>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            Stack<double> flourStack = new Stack<double>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));

            Dictionary<string, int> dictBakeryProducts = new Dictionary<string, int>();

            while (waterQueue.Count > 0 && flourStack.Count > 0)
            {
                double curWater = waterQueue.Peek();
                double curFlaour = flourStack.Peek();

                if (isValidRatio(curWater, curFlaour, dictBakeryProducts))
                {
                    waterQueue.Dequeue();
                    flourStack.Pop();
                }
                else
                {
                    if (!dictBakeryProducts.ContainsKey("Croissant"))
                    {
                        dictBakeryProducts.Add("Croissant", 0);
                    }
                    dictBakeryProducts["Croissant"]++;

                    if (curWater == curFlaour)
                    {
                        waterQueue.Dequeue();
                        flourStack.Pop();
                    }
                    if (curWater < curFlaour)
                    {
                        waterQueue.Dequeue();
                        flourStack.Pop();
                        flourStack.Push(curFlaour - curWater);
                    }
                    if (curFlaour < curWater)
                    {
                        flourStack.Pop();
                        waterQueue.Dequeue();
                        waterQueue.Enqueue(curWater - curFlaour);
                    }
                }
                

            }

            foreach (var product in dictBakeryProducts.OrderByDescending(p=>p.Value).ThenBy(p=>p.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }

            if (waterQueue.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", waterQueue)}");
            }
            if (flourStack.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flourStack)}");
            }
          

        }

        public static bool isValidRatio(double curWater, double curFlaour, Dictionary<string, int> dict)
        {
            double result = curWater + curFlaour;
            double perWater = curWater * 100 / result;
            double perFlour = curFlaour * 100 / result;

            if (perWater == 50 && perFlour == 50)
            {
                if (!dict.ContainsKey("Croissant"))
                {
                    dict.Add("Croissant", 0);
                }
                dict["Croissant"]++;
                return true;
            }
            if (perWater == 40 && perFlour == 60)
            {
                if (!dict.ContainsKey("Muffin"))
                {
                    dict.Add("Muffin", 0);
                }
                dict["Muffin"]++;
                return true;
            }
            if (perWater == 30 && perFlour == 70)
            {
                if (!dict.ContainsKey("Baguette"))
                {
                    dict.Add("Baguette", 0);
                }
                dict["Baguette"]++;
                return true;
            }
            if (perWater == 20 && perFlour == 80)
            {
                if (!dict.ContainsKey("Bagel"))
                {
                    dict.Add("Bagel", 0);
                }
                dict["Bagel"]++;
                return true;
            }
            return false;
        }
    }
}
