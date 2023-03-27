using System;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    class Program
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> continentsCountriesCities = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 1; i <= n; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = data[0];
                string country = data[1];
                string city = data[2];

                if (!continentsCountriesCities.ContainsKey(continent))
                {
                    continentsCountriesCities.Add(continent, new Dictionary<string, List<string>>());
                    continentsCountriesCities[continent].Add(country, new List<string>());
                    continentsCountriesCities[continent][country].Add(city);
                }
                else
                {
                    if (!continentsCountriesCities[continent].ContainsKey(country))
                    {
                        continentsCountriesCities[continent].Add(country, new List<string>());

                        continentsCountriesCities[continent][country].Add(city);
                    }
                    else
                    {
                        continentsCountriesCities[continent][country].Add(city);
                        //if (!continentsCountriesCities[continent][country].Contains(city))
                        //{
                        //    continentsCountriesCities[continent][country].Add(city);
                        //}
                    }
                }

            }
            foreach (var continent in continentsCountriesCities)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var countryCity in continent.Value)
                {
                    Console.WriteLine($"{countryCity.Key} -> {string.Join(", ", countryCity.Value)}");
                }


            }


        }
    }
}
