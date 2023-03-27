using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads__not_included_in_final_score_
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());

            Queue<string> queueCars = new Queue<string>();

            int carsPassed = 0;

            while (true)
            {
                string car = Console.ReadLine();
                if (car == "END")
                {
                    break;
                }
                if (car == "green")
                {
                    int currGreenLightSec = greenLightSeconds;
                    int currFreeWindowSec = freeWindowSeconds;

                    while (queueCars.Any())
                    {
                        string currCar = queueCars.Peek();
                        if (currCar.Length > currFreeWindowSec &&  currGreenLightSec == 0)
                        {
                            break;
                        }
                            bool passedCurrCar = true;

                            for (int i = 0; i < currCar.Length; i++)
                            {


                                if (currGreenLightSec - 1 >= 0 || currFreeWindowSec - 1 >= 0)
                                {
                                    if (currGreenLightSec > 0)
                                    {
                                        currGreenLightSec -= 1;
                                    }
                                    else
                                    {
                                        currFreeWindowSec -= 1;
                                    }


                                }
                                else
                                {
                                    Console.WriteLine($"A crash happened!");
                                    Console.WriteLine($"{currCar} was hit at {currCar[i]}.");
                                    return;
                                }



                            }

                            if (passedCurrCar)
                            {
                                carsPassed++;
                                queueCars.Dequeue();
                            }   
          
                      
                    }


                }
                else
                {

                    queueCars.Enqueue(car);
                }

            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
