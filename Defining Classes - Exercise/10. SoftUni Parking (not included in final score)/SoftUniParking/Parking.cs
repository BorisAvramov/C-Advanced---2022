using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;



        public Parking(int capacity)
        {
            Capacity = capacity;
            Cars = new List<Car>();
        }

        public List<Car> Cars { get { return cars; } set { cars = value; } }
        public int Capacity { get { return capacity; } set { capacity = value; } }
        public int Count => Cars.Count; 

        public string AddCar(Car car)
        {
            if (Cars.Count > 0 && Cars.Any( c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";

            }
            else
            {
                if (Cars.Count >= Capacity)
                {
                    return"Parking is full!";
                }
                else
                {
                    Cars.Add(car);
                    //Count++;
                    Capacity--;
                    return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
                }
            }
        }
        public string RemoveCar(string registrationNumber) 
        {
            if (Cars.Any(c=>c.RegistrationNumber == registrationNumber))
            {
                Cars.RemoveAll(c=>c.RegistrationNumber == registrationNumber);
                //Count--;
                Capacity++;
                return $"Successfully removed {registrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }
        public string GetCar(string registrationNumber) 
        {
            Car car = Cars.Where(c => c.RegistrationNumber == registrationNumber).FirstOrDefault();

            return $"Make: {car.Make}\nModel: {car.Model}\nHorsePower: {car.HorsePower}\nRegistrationNumber: {car.RegistrationNumber}";

        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers) 
        {
            foreach (var item in registrationNumbers)
            {
                foreach (var car in Cars)
                {
                    if (car.RegistrationNumber == item)
                    {
                        Cars.Remove(car);
                        //Count--;
                        break;
                    }


                }

            }
        
        }

    }
}
