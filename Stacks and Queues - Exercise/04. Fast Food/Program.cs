using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(input);

            Console.WriteLine(orders.Max());


            while (orders.Count > 0  && foodQuantity > 0)
            {
                if (foodQuantity >= orders.Peek())
                {
                    foodQuantity -= orders.Dequeue();

                }
                else
                {
                    break;
                }
            }

            //int count = orders.Count;
            //for (int i = 0; i < count; i++)
            //{
            //    if (foodQuantity >= orders.Peek())
            //    {
            //        foodQuantity -= orders.Dequeue();

            //    }
            //    else
            //    {
            //        break;
            //    }
            //}



            if (orders.Count > 0)
            {

                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                
            }
            else
            {
                Console.WriteLine("Orders complete");
            }


        }
    }
}
