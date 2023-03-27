using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses4
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
                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);

                Engine curEngine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];

                Cargo curCargo = new Cargo(cargoType, cargoWeight);


                Tire[] tires = new Tire[4];

                int count = 0;
                for (int j = 5; j < 13; j+=2)
                {
                    double tirePressure = double.Parse(data[j]);
                    int tireAge = int.Parse(data[j+1]);
                    
                    Tire curTire = new Tire(tireAge, tirePressure);

                    tires[count] = curTire;

                    count++;
                }

                Car curCar = new Car(model, curEngine, curCargo, tires);

                cars.Add(curCar);
            }

            string command = Console.ReadLine();

            List<Car> filteredCars = new List<Car>();

            if (command == "fragile")
            {
                filteredCars = cars.Where(c => c.Cargo.Type == "fragile" && c.tires.Any(t => t.Pressure < 1)).ToList();
            }
            else
            {
                filteredCars = cars.Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250).ToList();
            }

            foreach (var car in filteredCars)
            {
                Console.WriteLine(car.Model);

            }


        }
    }
}
