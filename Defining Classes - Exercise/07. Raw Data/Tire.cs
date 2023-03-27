using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses4
{
    public class Tire
    {
        public Tire(int age, double pressure)
        {
            Age = age;
            Pressure = pressure;
        }

        public int Age { get; set; }
        public double Pressure { get; set; }


    }
}
