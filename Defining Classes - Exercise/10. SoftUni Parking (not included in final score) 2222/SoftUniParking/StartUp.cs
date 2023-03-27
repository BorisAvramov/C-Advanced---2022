using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Parking parking = new Parking(5);

            Car car = new Car("Skoda", "Fabia", 65, "CC1856BG");

            Console.WriteLine(parking.AddCar(car));




            Console.WriteLine(car.ToString());



            //////Console.WriteLine(parking.RemoveCar("CC1856B"));

            Console.WriteLine(parking.GetCar("CC1856BG").ToString());

            List<string> regumbers = new List<string>();

            regumbers.Add("CC1856BG");

            parking.RemoveSetOfRegistrationNumber(regumbers);


        }
    }
}
