using System;
using System.Linq;

namespace CustomComparator
{
    internal class Program 
    {
        static void Main(string[] args)
        {

            int[] intElements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            Func<int, int, int> func = (x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }
                else if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }
                else
                {
                    if (x>y)
                    {
                        return 1;
                    }
                    else if(x<y)
                    {
                        return -1;
                    }


                }
                return 0;


            };

            Array.Sort(intElements, (x, y) => func(x, y));

            Console.WriteLine(String.Join(" ", intElements));


        }

        
    }
}
