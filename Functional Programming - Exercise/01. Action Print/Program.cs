    using System;

    namespace _01._Action_Print
    {
        class Program
        {
            static void Main(string[] args)
            {

                //string[] input = Console.ReadLine().Split(" ");

                //Action<string> print = s => Console.WriteLine(s);

                //foreach (var item in input)
                //{
                //    print(item);
                //}
                //=================================================================
                
                string[] input = Console.ReadLine().Split(" ");
                Action<string[]> print = names => Console.WriteLine(string.Join("\n", names));

                    print(input);


            }
        }
    }
