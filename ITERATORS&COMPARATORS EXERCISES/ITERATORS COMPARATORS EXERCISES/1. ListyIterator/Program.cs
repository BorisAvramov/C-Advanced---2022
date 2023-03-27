using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {


            List<string> stringList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList();

            ListyIterator<string> myListy = new ListyIterator<string>(stringList);

            string input = Console.ReadLine();
            try
            {
                while (input != "END")
                {

                    if (input == "Move")
                    {
                        Console.WriteLine(myListy.Move());
                    }
                    if (input == "HasNext")
                    {
                        Console.WriteLine(myListy.HasNext());
                    }
                    if (input == "Print")
                    {
                        myListy.Print();
                    }
                    if (input == "PrintAll")
                    {
                        myListy.PrintAll();
                    }

                    input = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


        }
    }
}
