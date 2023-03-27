using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;

            Participants = new HashSet<Car>();


        }

        public HashSet<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public int Count => Participants.Count;


        public void Add(Car car)

        {
            if (Count < Capacity && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }


        }
        public bool Remove(string licensePlate)
        {
            Car car = null;
            if (Participants.Any(c=>c.LicensePlate == licensePlate))
            {

                car = Participants.Where(c => c.LicensePlate == licensePlate).FirstOrDefault();

                Participants.Remove(car);
                return true;
            }
            else
            {
                return false;
            }


        }
        public Car GetMostPowerfulCar()
        {
            if (Participants.Any())
            {
                Car maxHorsePowerCar = null;
                int mahPower = 0;

                foreach (var car in Participants)
                {
                    if (car.HorsePower > mahPower)
                    {
                        mahPower = car.HorsePower;
                        maxHorsePowerCar = car;
                    }
                }
                return maxHorsePowerCar;
            }
            else
            {
                return null;
            }
        }

        public Car FindParticipant(string licensePlate)
        {
            return Participants.Where(c => c.LicensePlate == licensePlate).FirstOrDefault();


        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var car in Participants)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString();
        }
    }
}
