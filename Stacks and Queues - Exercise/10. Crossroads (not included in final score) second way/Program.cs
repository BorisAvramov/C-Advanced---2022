using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads__not_included_in_final_score__second_way
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string car = Console.ReadLine();
            int carPassed = 0;
            bool crash = false;
            while (car != "END")
            {
                if (car!= "green")
                {
                    cars.Enqueue(car);
                    car = Console.ReadLine();
                    continue;
                    
                }
                else
                {
                    int currGreenLight = greenLight;
                    int currFreeWindow = freeWindow;
                    

                    while (cars.Any() && currGreenLight  > 0)
                    {
                        string curCAr = cars.Peek();
                        if (currGreenLight >= curCAr.Length)
                        {
                            currGreenLight -= curCAr.Length;
                            carPassed++;
                            cars.Dequeue();

                        }

                        else if (currGreenLight + currFreeWindow >= curCAr.Length)
                        {

                            //currFreeWindow =  (currGreenLight + currFreeWindow) - curCAr.Length;
                            currGreenLight = 0;
                            carPassed++;

                            cars.Dequeue();
                        }
                      else
                        {
                            int hittedChar = currFreeWindow + currGreenLight;

                            Console.WriteLine($"A crash happened!");
                            Console.WriteLine($"{curCAr} was hit at {curCAr[hittedChar]}.");
                            crash = true;
                            break;

                        }


                    }
                }

                if (crash)
                {
                    break;
                }
                car = Console.ReadLine();
            }

            if (!crash)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carPassed} total cars passed the crossroads.");
            }
          



        }
    }
}
