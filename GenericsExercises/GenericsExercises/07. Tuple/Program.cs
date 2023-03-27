using System;

namespace Tuples
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] stringElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Mytuple<string, string> myTuple = new Mytuple<string, string>($"{stringElements[0]} {stringElements[1]}", stringElements[2]);

            string[] stringElements2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Mytuple<string, int> myTuple2 = new Mytuple<string, int>(stringElements2[0], int.Parse(stringElements2[1]));


            string[] stringElements3 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Mytuple<int, double> myTuple3 = new Mytuple<int, double>(int.Parse(stringElements3[0]), double.Parse(stringElements3[1]));

             
            Console.WriteLine(myTuple.GetItem());
            Console.WriteLine(myTuple2.GetItem());
            Console.WriteLine(myTuple3.GetItem());
          
         

        }
    }
}
