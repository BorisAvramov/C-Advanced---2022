using System;
using System.Collections;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Queue<string> queueCustomer = new Queue<string>();


            while (input != "End")
            {
                if (input != "Paid")
                {
                    queueCustomer.Enqueue(input);
                }
                else
                {
                    while (queueCustomer.Count > 0)
                    {
                        Console.WriteLine(queueCustomer.Dequeue());
                    }
                       
                    

                }




                input = Console.ReadLine();
            }
            Console.WriteLine($"{queueCustomer.Count} people remaining.");

        }
    }
}
