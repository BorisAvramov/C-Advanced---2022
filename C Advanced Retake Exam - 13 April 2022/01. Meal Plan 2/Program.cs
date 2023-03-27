using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan_2
{
      class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Queue<Meal> mealsQueue = new Queue<Meal>();

            foreach (var item in input)
            {
                int calories = GetCalories(item);
                Meal curMeal = new Meal(item, calories);
                mealsQueue.Enqueue(curMeal);

            }

            int[] input2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<Day> dailyCaloriesStack = new Stack<Day>();
            foreach (var item in input2)
            {
                Day day = new Day();
                day.Calories = item;
                dailyCaloriesStack.Push(day);

            }
            

            int mealCount = 0;

            while (mealsQueue.Count > 0 && dailyCaloriesStack.Count > 0)
            {
                Meal curMeal = mealsQueue.Peek();
                Day curDayCal = dailyCaloriesStack.Peek();

                if (curDayCal.Calories - curMeal.Calories > 0)
                {

                    curDayCal.Calories -= curMeal.Calories;
                 

                    mealsQueue.Dequeue();
                    mealCount++;
                    //dictMealCalories[curMeal] = GetDefault(curMeal);

                }
                else if (curDayCal.Calories - curMeal.Calories == 0)
                {

                    dailyCaloriesStack.Pop();
                    mealsQueue.Dequeue();
                    mealCount++;
                    //dictMealCalories[curMeal] = GetDefault(curMeal);
                }
                else if (curDayCal.Calories - curMeal.Calories < 0)
                {
                    dailyCaloriesStack.Pop();

                    curMeal.Calories = Math.Abs(curDayCal.Calories - curMeal.Calories);

                    //dictMealCalories[curMeal] = Math.Abs(curDayCal - dictMealCalories[curMeal]);


                }
            }
            if (dailyCaloriesStack.Count == 0)
            {
                if (mealsQueue.Peek().Calories < GetCalories(mealsQueue.Peek().Name))
                {
                    mealsQueue.Dequeue();
                    mealCount++;
                }


                Console.WriteLine($"John ate enough, he had {mealCount} meals.");
                List<string> list = new List<string>();
                foreach (var item in mealsQueue)
                {
                    list.Add(item.Name);
                }
                Console.WriteLine($"Meals left: {string.Join(", ", list)}.");

            }
            if (mealsQueue.Count == 0)
            {
                List<int> list = new List<int>();
                foreach (var item in dailyCaloriesStack)
                {
                    list.Add(item.Calories);
                }

                Console.WriteLine($"John had {mealCount} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", list)} calories.");
            }
        }

        private static int GetCalories(string meal)
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

      class Meal
    {
        public Meal(string name, int calories)
        {
            Name = name;
            Calories = calories;
        }

        public string Name { get; set; }
        public int Calories { get; set; }


    }

    class Day
    {

        public int Calories { get; set; }

    }
}
