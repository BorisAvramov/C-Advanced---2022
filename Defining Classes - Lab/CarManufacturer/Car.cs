using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;

        private double fuelQuantity;
        private double fuelConsumtion;

        private Engine engine;
        private Tire[] tires;

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumtion = 10;

        }

        public Car(string make, string model, int year) 
            : this()
        {
            this.Make = make; 
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumtion) 
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumtion = fuelConsumtion;


        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumtion, Engine engine, Tire[]tires)
            : this(make, model, year, fuelQuantity, fuelConsumtion)
        {
            this.Engine = engine;
            this.Tires = tires;

        }



        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int Year { get { return year; } set { year = value; } }
        public double FuelQuantity { get { return fuelQuantity; } set { fuelQuantity = value; } }
        public double FuelConsumtion { get { return fuelConsumtion; } set { fuelConsumtion = value; } }
        public Engine Engine { get { return engine;} set { engine = value;} }
        public Tire[] Tires { get { return tires;} set {tires = value; } }




        public void Drive(double distance)
        {
            if (fuelQuantity - (distance / 100.0) * fuelConsumtion > 0)
            {
                fuelQuantity -= (distance/100.0) * fuelConsumtion;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {

            return $"Make: {this.Make} Model: {this.Model} Year: {this.Year} Fuel: {this.FuelQuantity:f2}";

        }
    }
}
