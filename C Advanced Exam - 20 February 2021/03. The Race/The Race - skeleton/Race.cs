using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> racers;


        private string name;
        private int capacity;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            racers = new List<Racer>();

        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Count => racers.Count;


        //Add(Racer Racer) – adds an entity to the data if there is room for him/her.


        public void Add(Racer racer) 
        {
            if (capacity > racers.Count)
            {
                racers.Add(racer);
            }
        
        
        }

        //•	Method Remove(string name) – removes an Racer by given name, if such exists, and returns bool.

        public bool Remove(string name) 
        
        {
            if (racers.Any(r => r.Name == name))
            {
                racers.Remove(racers.FirstOrDefault(r=>r.Name == name));
                return true;
            }
            return false;
        
        }

        //•	Method GetOldestRacer() – returns the oldest Racer.

        public Racer GetOldestRacer()
        {
            Racer oldest = null;
            int maxAge = int.MinValue;

            foreach (var racer in racers)
            {
                if (racer.Age > maxAge)
                {
                    maxAge = racer.Age;
                    oldest = racer;

                }
            }
            return oldest;

        }

        //•	Method GetRacer(string name) – returns the Racer with the given name.

        public Racer GetRacer(string name)
        {
            return racers.FirstOrDefault(r => r.Name == name);

        }

        //•	Method GetFastestRacer() – returns the Racer whose car has the highest speed.

        public Racer GetFastestRacer()
        {
            Racer fastestRacer = null;
            int maxSpeed = int.MinValue;

            foreach (var racer in racers)
            {
                if (racer.Car.Speed > maxSpeed)
                {
                    maxSpeed = racer.Car.Speed;
                    fastestRacer = racer;
                }
            }

            return fastestRacer;

        }

        //•	Report() – returns a string in the following format:
        //o	"Racers participating at {RaceName}:
//{Racer1
//    }
//{Racer2
//}
        public string Report()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {Name}:");

            foreach (var racer in racers)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();

        }

    }
}
