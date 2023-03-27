using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue <string> mealsQueue = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            //string[] iput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //Queue queue = new Queue(iput);

            //string exmQueq = mealsQueue.Dequeue().ToString();
            //mealsQueue.Enqueue("morkov");
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> dailyCaloriesStack = new Stack<int>(input);

            //int num =  (int)dailyCaloriesStack.Pop();

            Dictionary<string, int> dictMealCalories = new Dictionary<string, int>();
            dictMealCalories.Add("salad", 350);
            dictMealCalories.Add("soup", 490);
            dictMealCalories.Add("pasta", 680);
            dictMealCalories.Add("steak", 790);

            int mealCount = 0;

            while (mealsQueue.Count > 0 && dailyCaloriesStack.Count > 0 )
            {
                string curMeal = mealsQueue.Peek();
                int curMealCalories = dictMealCalories[curMeal];
                int curDayCal = (int)dailyCaloriesStack.Peek(); 
                if (curDayCal - curMealCalories > 0)
                {
                   
                    dailyCaloriesStack.Pop();
                    dailyCaloriesStack.Push(curDayCal - curMealCalories);

                    mealsQueue.Dequeue();
                    mealCount++;
                    dictMealCalories[curMeal] = GetDefault(curMeal);
                    
                }
                if (curDayCal - curMealCalories == 0)
                {
                    
                    dailyCaloriesStack.Pop();
                    mealsQueue.Dequeue();
                    mealCount++;
                    dictMealCalories[curMeal] = GetDefault(curMeal);
                }
               
                if (curDayCal - curMealCalories < 0)
                {
                    dailyCaloriesStack.Pop();

                    dictMealCalories[curMeal] = Math.Abs(curDayCal - curMealCalories);
                   
                    //dictMealCalories[curMeal] = Math.Abs(curDayCal - dictMealCalories[curMeal]);


                }

            }

            if (dailyCaloriesStack.Count == 0)
            {
                if (dictMealCalories[mealsQueue.Peek()] < GetDefault(mealsQueue.Peek()) )
                {
                    mealsQueue.Dequeue();
                    mealCount++;
                }

                
                Console.WriteLine($"John ate enough, he had {mealCount} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", mealsQueue)}.");

            }
            if (mealsQueue.Count == 0)
            {
                Console.WriteLine($"John had {mealCount} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", dailyCaloriesStack)} calories.");
            }

        }

        

        private static int GetDefault(string meal)
        {
            
            switch (meal)
            {
                case "salad":
                    return 350;
                case "soup":
                    return 490;
                case "pasta":
                    return 680;
                case "steak":
                    return 790;
                default:
                    return 0;
                    
                    

            }


        }
    }
}
