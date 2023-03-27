using System;

namespace DefiningClasses2
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int result =  DateModifier.GetDiff(firstDate, secondDate);

            Console.WriteLine(result);
        }
    }
}
