using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> dict = new Dictionary<string, int>();

            dict.Add("Bread", 0);
            dict.Add("Cake", 0);
            dict.Add("Pastry", 0);
            dict.Add("Fruit Pie", 0);


            Queue<int> liquidQueue = new Queue<int>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));


            Stack<int> ingredientStack = new Stack<int>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));


            while (liquidQueue.Count > 0 && ingredientStack.Count > 0)
            {
                int curLiquid = liquidQueue.Peek(); 
                int curIngr = ingredientStack.Peek();

                liquidQueue.Dequeue();

                if (Cook(curIngr, curLiquid, dict))
                {
                    
                    ingredientStack.Pop();
                }
                else
                {
                    ingredientStack.Pop();
                    ingredientStack.Push(curIngr + 3);

                }

            }
            bool succeedCooking = true;

            foreach (var (key, value) in dict)
            {
                if (value == 0)
                {
                    succeedCooking = false;
                }
            }
            if (succeedCooking)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (liquidQueue.Count <= 0)
            {
                Console.WriteLine("Liquids left: none");

            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquidQueue)}");
            }
            if (ingredientStack.Count <= 0)
            {
                Console.WriteLine("Ingredients left: none");

            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredientStack)}");
            }

            foreach (var (key, value) in dict.OrderBy(c =>c.Key))
            {
                Console.WriteLine($"{key}: {value}");
            }
        }

        private static bool Cook(int curIngr, int curLiquid, Dictionary<string, int> dict)
        {
            int sum = curLiquid + curIngr;
            if (sum == 25)
            {
                dict["Bread"]++;
                return true;
            }
            if (sum == 50)
            {
                dict["Cake"]++;
                return true;

            }
            if (sum == 75)
            {
                dict["Pastry"]++;
                return true;

            }
            if (sum == 100)
            {
                dict["Fruit Pie"]++;
                return true;

            }
            return false;
        }
    }
}
