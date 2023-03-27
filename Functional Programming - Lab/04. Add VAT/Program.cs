    using System;
    using System.Linq;

    namespace _04._Add_VAT
    {
        class Program
        {
            static void Main(string[] args)
            {

                //Func<string, double> GetVat = (p) =>
                //{
                //    double pr = double.Parse(p);
                //    return pr += pr * 0.2;
                //};
                //double[] prices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(GetVat).ToArray();

                //foreach (var item in prices)
                //{
                //    Console.WriteLine($"{item:f2}");
                //}


                double[] prices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

                prices = prices.Select(p => p += p * 0.2).ToArray();

            foreach (var item in prices)
            {
                Console.WriteLine($"{item:f2}");
            }
           }
        }
    }
