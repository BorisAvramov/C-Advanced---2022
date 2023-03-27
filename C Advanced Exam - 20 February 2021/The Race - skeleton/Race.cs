using System;
using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> racers;


        private string name;
        private int capacity;

        public Race(string name, int capacity )
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




    }
}
