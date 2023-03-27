using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> employees;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            employees = new List<Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => employees.Count;

        //Method Add(Employee employee) – adds an entity to the data if there is room for him/her.

        public void Add(Employee employee)
        {
            if (Capacity > employees.Count)
            {
                employees.Add(employee);
            }
        }
        //•	Method Remove(string name) – removes an employee by given name, if such exists, and returns bool.

        public bool Remove(string name)
        {

            return employees.Remove(employees.FirstOrDefault(e => e.Name == name));


        }
        // •	Method GetOldestEmployee() – returns the oldest employee.

        public Employee GetOldestEmployee()
        {
            int maxAge = int.MinValue;
            Employee oldestEmpl = null;

            foreach (var emp in employees)
            {
                if (emp.Age > maxAge)
                {
                    maxAge = emp.Age;
                    oldestEmpl = emp;
                }
            }
            return oldestEmpl;
        }

        //	Method GetEmployee(string name) – returns the employee with the given name.

        public Employee GetEmployee(string name)
        {

            return employees.FirstOrDefault(e => e.Name == name);
        }
        //•	Report() – returns a string in the following format:
        //o	"Employees working at Bakery {bakeryName}:
        //{Employee1
        //    }


        //}
        public string Report()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var employee in employees)
            {
                sb.AppendLine(employee.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
