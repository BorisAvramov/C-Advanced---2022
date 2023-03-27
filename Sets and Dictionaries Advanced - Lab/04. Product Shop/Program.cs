using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopProductsPrice = new Dictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();
            while (input != "Revision")
            {
                string[] data = input.Split(", ");
                string shop = data[0];
                string product = data[1];
                double price = double.Parse(data[2]);

                if (!shopProductsPrice.ContainsKey(shop))
                {
                    shopProductsPrice.Add(shop, new Dictionary<string, double>());
                }
                shopProductsPrice[shop].Add(product, price);



                input = Console.ReadLine();
            }
            shopProductsPrice = shopProductsPrice.OrderBy(s => s.Key).ToDictionary(s=>s.Key, s=>s.Value);

            foreach (var shop in shopProductsPrice)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }


            }

        }
    }
}
