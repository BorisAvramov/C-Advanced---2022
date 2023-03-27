using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses3
{
    public class StartUp

    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                string model = data[0];
                double fuelAmount = double.Parse(data[1]);
                double fuelConsumptionPerKilometer = double.Parse(data[2]);
                double travelledDistance = 0;

                Car curCar = new Car(model, fuelAmount, fuelConsumptionPerKilometer, travelledDistance );
                cars.Add(curCar);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] data = input.Split();

                string carModel = data[1];
                double amountOfKm = double.Parse(data[2]);


                foreach (var car in cars)
                {

                    if (car.Model == carModel)
                    {
                        car.Drive(amountOfKm);

                    }

                }


            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }

        }
    }
}
