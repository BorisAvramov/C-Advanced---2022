using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCarsPAssedGreenLight = int.Parse(Console.ReadLine());

            Queue<string> queueCars = new Queue<string>();
            int countPasses = 0;

            while (true)
            {
                string car = Console.ReadLine();
                if (car == "end")
                {
                    break;
                }

                if (car == "green")
                {
                    
                            for (int i = 1; i <= numCarsPAssedGreenLight; i++)
                            {
                            if (queueCars.Count == 0)
                            {
                                break;
                            }
                           
                                countPasses++;
                                Console.WriteLine($"{queueCars.Dequeue()} passed!");
                            


                            }

                }
                else
                {
                    queueCars.Enqueue(car);
                }

            }

            Console.WriteLine($"{countPasses} cars passed the crossroads.");

        }
    }
}
