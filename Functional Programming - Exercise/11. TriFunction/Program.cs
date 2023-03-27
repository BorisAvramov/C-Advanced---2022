using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


                    
            List<string> names = Console.ReadLine().Split(" ").ToList();

            //1st WAY and 2nd WAY ===============================================================
            //1st
            //Func<string, bool> funcIsEqualOrLarger = IsEqualOrlarger(n);
            //2nd
            //string firstName = names.Where(n => funcIsEqualOrLarger(n)).FirstOrDefault();
            //Console.WriteLine(firstName);

            //1st
            //Func<List<string>, Func<string, bool>, string> getName = GetName();
            //1st
            //var name = getName(names, funcIsEqualOrLarger);
            //Console.WriteLine(name);


            Func<string, int, bool> isEqualLarger = (name, sum) => name.Sum(c => c) >= sum;

            Func<List<string>,int,  Func<string, int, bool>, string> getName = (names, sum,func) => names.Where(n => func(n, sum)).FirstOrDefault();

            string name =  getName(names, n, isEqualLarger);
            Console.WriteLine(name);
        }

        private static Func<List<string>, Func<string, bool>, string> GetName()
        {
            return (names, func) => names.Where(n => func(n)).FirstOrDefault();


          
        }

        private static Func<string, bool> IsEqualOrlarger(int n)
        {
            return (name) => name.Sum(x => x) >= n; 
        }
    }
}
