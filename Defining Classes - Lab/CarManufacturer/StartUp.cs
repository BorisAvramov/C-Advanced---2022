using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {

        public static void Main(string[] args)
        {
            //Car myCar = new Car();

            //myCar.Make = "VW";

            //myCar.Model = "MK3";

            //myCar.Year = 1992;



            //myCar.FuelQuantity = 200;
            //myCar.FuelConsumtion = 200;
            //myCar.Drive(2000);

            //Console.WriteLine(myCar.WhoAmI());


            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumtion = double.Parse(Console.ReadLine());

            //Car Car = new Car();

            //Car herCar = new Car(make, model, year);

            //Car hisCar = new Car(make,model,year,fuelQuantity,fuelConsumtion);

            ////Console.WriteLine($"{Car.Make}, {Car.Model}, {Car.Year}, {Car.FuelQuantity}, {Car.FuelConsumtion}");

            ////Console.WriteLine($"{herCar.Make}, {herCar.Model}, {herCar.Year}, {herCar.FuelQuantity}, {herCar.FuelConsumtion}");

            ////Console.WriteLine($"{hisCar.Make}, {hisCar.Model}, {hisCar.Year}, {hisCar.FuelQuantity}, {hisCar.FuelConsumtion}");

            //Tire[] tires = new Tire[]
            //    {
            //        new Tire(1, 2.5),
            //        new Tire(1, 2.5),
            //        new Tire(2, 3.5),
            //        new Tire(2, 3.5)
            //    };

            //Engine engine = new Engine(125, 2000);

            //Car newCar = new Car("VW", "Passat", 2003, 50, 10, engine, tires);

            List<Tire[]> carsTires = new List<Tire[]>();
            List<Engine> carsEnines = new List<Engine>();
            List<Car> cars = new List<Car>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "No more tires")
                {
                    break;

                }

                string[] data = input.Split();
                List<Tire> curCarTires = new List<Tire>();
                for (int i = 0; i < data.Length; i += 2)
                {
                    int year = int.Parse(data[i]);
                    double prressure = double.Parse(data[i + 1]);
                    Tire curTire = new Tire(year, prressure);
                    curCarTires.Add(curTire);

                }
                carsTires.Add(curCarTires.ToArray());

            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Engines done")
                {
                    break;
                }
                string[] data = input.Split();
                int horsePower = int.Parse(data[0]);
                double cubicCapacity = double.Parse(data[1]);

                Engine curEngine = new Engine(horsePower, cubicCapacity);
                carsEnines.Add(curEngine);

            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Show special")
                {
                    break;

                }
                string[] data = input.Split();
                string make = data[0];
                string model = data[1];
                int year = int.Parse(data[2]);

                double fuelQuantity = double.Parse(data[3]);
                double fuelConsumption = double.Parse(data[4]);
                int engineIndex = int.Parse(data[5]);
                int tiresIndex = int.Parse(data[6]);

                Car curCar = new Car(make, model, year, fuelQuantity, fuelConsumption, carsEnines[engineIndex], carsTires[tiresIndex]);

                cars.Add(curCar);


            }

            //cars = cars
            //   .Where(x => x.Year >= 2017 && x.Engine.HorsePower > 330 && x.Tires.Sum(y => y.Pressure) >= 9 && x.Tires.Sum(y => y.Pressure) <= 10)
            //   .ToList();

            Func<Car, bool> valid = GetValid();

            cars = cars.Where(c => valid(c)).ToList();

            
            foreach (var car in cars)
            {
                car.Drive(20);

                //Console.WriteLine(car.WhoAmI());

                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");

            }
        } 

        private static Func<Car, bool> GetValid()
        {
            return car => car.Year >= 2017 && car.Engine.HorsePower > 330 && car.Tires.Sum(t => t.Pressure) >= 9 && car.Tires.Sum(t => t.Pressure) <= 10;

        }
    }
}
