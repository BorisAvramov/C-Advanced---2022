using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {

        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();

        }

        public List<Drone> Drones { get; set; }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public int Count => Drones.Count;


        public  string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Brand) || string.IsNullOrEmpty(drone.Name) || (drone.Range < 5 || drone.Range > 15) )
            {
                return "Invalid drone.";
            }

            else if (Capacity == Count)
            {
                return "Airfield is full.";
            }
            else
            {

                Drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";


            }

           
        }

        public bool RemoveDrone(string name) 
        {




            foreach (var drone in Drones)
            {
                if (drone.Name == name)
                {
                    Drones.Remove(drone);
                    return true;
                }

            }
            return false;
        }

        public Drone FlyDrone(string name)
        {
            foreach (var drone in Drones)
            {
                if (drone.Name == name)
                {
                    drone.Available = false;

                    return drone;
                }
            }
            return null;


        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flyDrones = new List<Drone>();

            foreach (var dron in Drones)
            {
                if (dron.Range >= range)
                {
                    flyDrones.Add(dron);
                    dron.Available = false;

                }
            }
            return flyDrones;

        }
        public int RemoveDroneByBrand(string brand)
        {
            int countRemoved = 0;

            foreach (var drone in Drones)
            {
                if (drone.Brand == brand)
                {
                    countRemoved++;
                }
            }

            Drones.RemoveAll(d=>d.Brand == brand);
            if (countRemoved > 0)
            {
                return countRemoved;
            }
            else
            {
                return 0;

            }
        }
        public string Report()
        {
            StringBuilder st = new StringBuilder();

            st.AppendLine($"Drones available at {Name}:");
            foreach (var drone in Drones)
            {
                if (drone.Available == true)
                {
                    st.AppendLine(drone.ToString());
                }
            }

            return st.ToString().Trim();

        }
    }
}
