using System;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
 
            HashSet<string> cars = new HashSet<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                string[] data = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = data[0];
                string carNumber = data[1];
                if (direction == "IN")
                {
                    cars.Add(carNumber);

                }
                else if (direction == "OUT")
                {
                        cars.Remove(carNumber);
                    

                }


            }
            if (cars.Count > 0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }

            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }

        }
    }
}
