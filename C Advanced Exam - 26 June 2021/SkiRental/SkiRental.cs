using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {

        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }
        //public int Count { get { return data.Count; } private set { ; } }
        public int Count => data.Count;

        public bool Remove(string manufacturer, string model)
        {
            if (data.Any(s => s.Manufacturer == manufacturer && s.Model == model))
            {
                data.Remove(data.Where(s=>s.Manufacturer == manufacturer && s.Model == model).FirstOrDefault());
                return true;
            }
            else
            {
                return false;
            }


            
        }

        public Ski GetNewestSki()
        {
            if (!data.Any())
            {
                return null;
            }

            Ski newest = null;
            int maxYear = 0;

            foreach (var ski in data)
            {
                if (ski.Year > maxYear)
                {
                    maxYear = ski.Year;
                    newest = ski;
                }
            }
            return newest;

        }

        internal string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");

            foreach (var ski in data)
            {
                sb.AppendLine(ski.ToString());
            }



            return sb.ToString().Trim();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return data.Where(s => s.Manufacturer == manufacturer && s.Model == model).FirstOrDefault();

            
        }

        public void Add(Ski ski)
        {
            if (Capacity > Count)
            {
                data.Add(ski);
            }
            else
            {
                throw new InvalidOperationException();
            }

            
        }

    }
}
