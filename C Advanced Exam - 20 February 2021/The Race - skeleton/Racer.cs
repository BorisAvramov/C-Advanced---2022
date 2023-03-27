using System;
using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Racer
    {
        private string name;
        private int age;
        private string country;
        private Car car;

        public Racer(string name, int age,  string country, Car car )
        {
            Car = car;
            Country = country;
            Age = age;
            Name = name;
        }

        public Car Car
        {
            get { return car; }
            set { car = value; }
        }



        public string Country
        {
            get { return country; }
            set { country = value; }
        }


        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public override string ToString()
        {
            return $"Racer: {this.Name}, {this.Age} ({this.Country})";
        }




    }
}
