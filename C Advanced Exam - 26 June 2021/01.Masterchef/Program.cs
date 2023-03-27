using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> freshness = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> dishesCount = new Dictionary<string, int>();
            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                int curIngr = ingredients.Peek();
                int curfresh = freshness.Peek();
                int multiplication = curIngr * curfresh;
                if (curIngr == 0)
                {
                    ingredients.Dequeue();

                    continue;

                }
                if (MakeDish(multiplication, dishesCount))
                {
                    ingredients.Dequeue();
                    
                }
                else
                {
                    ingredients.Dequeue();
                    ingredients.Enqueue(curIngr + 5);
                }
                freshness.Pop();


            }

            if (dishesCount.Count == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingredients.Count > 0)
            {
                int incrSum = ingredients.Sum();
                Console.WriteLine($"Ingredients left: {incrSum}");

            }
            foreach (var item in dishesCount.OrderBy(d=>d.Key))
            {
                Console.WriteLine($" # {item.Key} --> {item.Value}");
            }

        }

        private static bool MakeDish(int multiplication,Dictionary<string, int> dishesCount )
        {

            //return multiplication == 150
            //|| multiplication == 250
            //|| multiplication == 300
            //|| multiplication == 400;


            if (multiplication == 150)
            {
                if (!dishesCount.ContainsKey("Dipping sauce"))
                {
                    dishesCount.Add("Dipping sauce", 0);
                }

                dishesCount["Dipping sauce"]++;
                return true;
            }
            else if (multiplication == 250)
            {
                if (!dishesCount.ContainsKey("Green salad"))
                {
                    dishesCount.Add("Green salad", 0);
                }

                dishesCount["Green salad"]++;
                return true;
            }
            else if (multiplication == 300)
            {
                if (!dishesCount.ContainsKey("Chocolate cake"))
                {
                    dishesCount.Add("Chocolate cake", 0);
                }

                dishesCount["Chocolate cake"]++;
                return true;
            }
            else if (multiplication == 400)
            {
                if (!dishesCount.ContainsKey("Lobster"))
                {
                    dishesCount.Add("Lobster", 0);
                }

                dishesCount["Lobster"]++;
                return true;
            }
            else return false;
        }
    }
}
