using System;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {   /*1=========================================*/
            //Func<string, int> parcer = n => int.Parse(n);   

            //Func<int, bool> filter = n => n % 2 == 0;
            //int[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(parcer).Where(filter).OrderBy(n=>n).ToArray();


            //Console.WriteLine(string.Join(", ", numbers));
            //2=============================================== BELOW MTHODS USER
            //int[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(parcer).Where(filter).OrderBy(n => n).ToArray();
            ////(int n) => { return n % 2 == 0; }

            //Console.WriteLine(string.Join(", ", numbers));

            int[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).Where((n) => {return n % 2 == 0; }).OrderBy(n => n).ToArray();
            //(int n) => { return n % 2 == 0; }

            Console.WriteLine(string.Join(", ", numbers));
        }



        private static int parcer(string n)
        {
            return int.Parse(n);
        }
        private static bool filter (int n)
        {
            return n % 2 == 0;
        }
        
    }
}
