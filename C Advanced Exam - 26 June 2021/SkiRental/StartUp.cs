using System;

namespace SkiRental
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SkiRental skiRental = new SkiRental("New Alpine ski rental", 5);

            Ski firstSkiSet = new Ski("Rossignol", "XC70", 2017);

            Console.WriteLine(firstSkiSet); // Rossignol - XC70 - 2017


            skiRental.Add(firstSkiSet);

            Console.WriteLine(skiRental.Remove("Rossignol", "XC90")); // False
            Console.WriteLine(skiRental.Remove("Rossignol", "XC70"));//True

            Ski secondSkiSet = new Ski("Fischer", "SpeedMax", 2018);
            Ski thirdSkiSet = new Ski("Salomon", "TopLine", 2020);

            skiRental.Add(secondSkiSet);
            skiRental.Add(thirdSkiSet);

            Ski newestSki = skiRental.GetNewestSki();
            Console.WriteLine(newestSki); // Salomon - TopLine - 2020

            Ski salomonTopLine = skiRental.GetSki("Salomon", "TopLine");
            Console.WriteLine(salomonTopLine); // Salomon - TopLine - 2020

            // Count
            Console.WriteLine(skiRental.Count); // 2

            Console.WriteLine(skiRental.GetStatistics());
            // The skis stored in New Alpine ski rental:
            // Fischer - SpeedMax – 2018
            // Salomon - TopLine - 2020



        }
    }
}
