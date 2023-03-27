    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace _05._Applied_Arithmetics
    {
        class Program
        {
            static void Main(string[] args)
            {
                //List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

                //while (true)
                //{
                //    string command = Console.ReadLine();
                //    if (command == "end")
                //    {
                //        break;
                //    }

                //    if (command == "print")
                //    {
                //        Console.WriteLine(string.Join(" ", numbers));
                //    }
                //    else
                //    {
                //        Func<int, int> apllyCommand = ApplyCommand(command);
                //        numbers = numbers.Select(n => apllyCommand(n)).ToList();
                //    }

                //}
                //===============================================================================================


                List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

                Action<List<int>> add = numbers =>
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] += 1;

                    }

                };
                Action<List<int>> multuply = numbers =>
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] *= 2;

                    }

                };
                Action<List<int>> subtract = numbers =>
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] -= 1;

                    }

                };
                Action<List<int>> print = numbers => Console.WriteLine(string.Join(" ", numbers));

                while (true)
                {
                    string command = Console.ReadLine();
                    if (command == "end")
                    {
                        break;
                    }

               

                    if (command == "add")
                    {
                          add(numbers);
                    }
                    else if (command == "multiply")
                    {
                        multuply(numbers);
                    }
                    else if (command == "subtract")
                    {
                        subtract(numbers);
                    }
                    else if (command == "print")
                    {
                        print(numbers);
                    }


                }


            }

            private static Func<int, int> ApplyCommand(string command)
            {
                switch (command)
                {
                    case "add":
                        return n => n + 1;
                    case "multiply":
                        return n => n * 2;
                    case "subtract":
                        return n => n - 1;
                    case "print":
                   
                    default:
                        return null;
                     
                }

            }
        }
    }
