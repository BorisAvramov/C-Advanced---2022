using System;
using System.Linq;

namespace GenericsExercises
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int intValue = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();

            for (int i = 0; i < intValue; i++)
            {

                box.Add(double.Parse(Console.ReadLine()));


            }

            //int[] intElements = Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();
            //int index1 = intElements[0];
            //int index2 = intElements[1];
            //box.Swap(index1, index2);

            double elementToCompare = double.Parse(Console.ReadLine());
            Console.WriteLine(box.Compare(elementToCompare));

            //Console.WriteLine( box.ToString()); 
        }

        
    }
}
