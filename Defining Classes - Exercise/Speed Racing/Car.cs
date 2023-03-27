using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses3
{
   public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double travelledDistance)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = travelledDistance;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }


        public void Drive(double amountOfKilometers) 
        {
           
                    if (FuelAmount >= amountOfKilometers * FuelConsumptionPerKilometer)
                    {
                        FuelAmount -= amountOfKilometers * FuelConsumptionPerKilometer;
                        TravelledDistance += amountOfKilometers;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient fuel for the drive") ;
                    }             
        
        }
        
    }
}
