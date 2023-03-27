using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Birthday_Celebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> guestCapacity = new LinkedList<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            //Queue<int> guestCapacity = new Queue<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
           
            Stack<int> platesFood = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int wasted = 0;

            while (guestCapacity.Count > 0 && platesFood.Count > 0)
            {
                int curGuest = guestCapacity.First();
                int curPlate = platesFood.Peek();

                if (curGuest == curPlate)
                {
                    guestCapacity.add();
                    //guestCapacity.Dequeue();
                    platesFood.Pop();

                }
                if (curGuest > curPlate)
                {
                    platesFood.Pop();

                    guestCapacity.RemoveFirst();
                    guestCapacity.AddFirst(curGuest - curPlate);

                    //guestCapacity.Dequeue();
                    //guestCapacity = new Queue<int>(guestCapacity.Reverse());
                    //guestCapacity.Enqueue(curGuest - curPlate);
                    //guestCapacity = new Queue<int>(guestCapacity.Reverse());

                }
                if (curPlate > curGuest)
                {
                    guestCapacity.RemoveFirst();
                    //guestCapacity.Dequeue();
                    platesFood.Pop();
                    wasted +=  curPlate - curGuest;


                }


            }

            if (guestCapacity.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guestCapacity)}");
                Console.WriteLine($"Wasted grams of food: {wasted}");
            }
            if (platesFood.Count > 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", platesFood)}");
                Console.WriteLine($"Wasted grams of food: {wasted}");
            }

        }

    }
}
