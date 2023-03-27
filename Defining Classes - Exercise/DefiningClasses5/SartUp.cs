using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses5
{
    public class SartUp
    {
        static void Main(string[] args)
        {
            int nEngines = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            List<Car> cars = new List<Car>();

            for (int i = 0; i < nEngines; i++)
            {
                string[] data = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                Engine curEngine = new Engine();

                string model = data[0];
                int power = int.Parse(data[1]);

                curEngine.Model = model;
                curEngine.Power = power;

                if (data.Length == 4)
                {
                    int displacement = int.Parse(data[2]);
                    string efficiency = data[3];

                    curEngine.Displacement = displacement;
                    curEngine.Efficiency = efficiency;
                }
                if (data.Length == 3)
                {
                    bool isInt = int.TryParse(data[2], out int result);

                    if (isInt)
                    {
                        int displacement = result;
                        curEngine.Displacement = displacement;
                    }
                    else
                    {
                        string efficiency = data[2];
                        curEngine.Efficiency = efficiency;
                    }

                }

                engines.Add(curEngine);
            }

            int nCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < nCars; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car curCar = new Car();

                string model = data[0];

                string modelEngine = data[1];

                Engine carEngine = engines.Where(e=>e.Model == modelEngine).FirstOrDefault();

                curCar.Model = model;
                curCar.Engine = carEngine;

                //foreach (var engine in engines)
                //{
                //    if (engine.Model == modelEngine)
                //    {
                //        carEngine = engine;
                //    }

                //}
                if (data.Length == 4)
                {
                    int weight = int.Parse(data[2]);
                    string color = data[3]; 
                    curCar.Weight = weight;
                    curCar.Color = color;

                }
                if (data.Length == 3)
                {
                    bool isInt = int.TryParse(data[2], out int result);
                    if (isInt)
                    {
                        curCar.Weight = result;

                    }
                    else
                    {
                        curCar.Color = data[2];
                    }

                }


                cars.Add(curCar);

            }

            

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                string dispplacementInfo = car.Engine.Displacement == null ?
                    $"    Displacement: n/a" :
                    $"    Displacement: {car.Engine.Displacement}";
                Console.WriteLine(dispplacementInfo);
                string efficiency = car.Engine.Efficiency == null ?
                    $"    Efficiency: n/a" :
                    $"    Efficiency: {car.Engine.Efficiency}";
                Console.WriteLine(efficiency);
                string weightInfo = car.Weight == null ?
                     $"  Weight: n/a" :
                     $"  Weight: {car.Weight}";
                Console.WriteLine(weightInfo);
                string colorInfo = car.Color == null ?
                     $"  Color: n/a" :
                     $"  Color: {car.Color}";
                Console.WriteLine(colorInfo);
            }


        }
    }
}
