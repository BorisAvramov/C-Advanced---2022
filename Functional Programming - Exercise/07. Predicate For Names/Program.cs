using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());

            Predicate<int> filter = n => n <= lenght;

            /*tring[] names = Console.ReadLine().Split(" ").Where(n => filter(n.Length)).ToArray();*/

            string[] names = Console.ReadLine().Split(" ").Where(n => n.Length <= lenght).ToArray();

            //Console.WriteLine(string.Join("\n", names));

            foreach (var item in names)
            {
                Console.WriteLine(item);
            }



        }
    }
}
