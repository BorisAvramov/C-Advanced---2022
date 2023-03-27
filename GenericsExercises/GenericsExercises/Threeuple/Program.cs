using System;

namespace Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] stringElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] stringElements2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] stringElements3 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Threeuple<string, string, string> myTuple = new Threeuple<string, string, string>($"{stringElements[0]} {stringElements[1]}", stringElements[2], $"{stringElements[3]}");
            Threeuple<string, int, bool> myTuple2 = new Threeuple<string, int, bool>(stringElements2[0],int.Parse(stringElements2[1]),IsDrunk(stringElements2[2]) );
            Threeuple<string, double, string> myTuple3 = new Threeuple<string, double, string>(stringElements3[0], double.Parse(stringElements3[1]), stringElements3[2]);

            Console.WriteLine(myTuple.GetItems());
            Console.WriteLine(myTuple2.GetItems());
            Console.WriteLine(myTuple3.GetItems());

        }

        private static bool IsDrunk(string v)
        {
            return v == "drunk";
        }
    }
}
