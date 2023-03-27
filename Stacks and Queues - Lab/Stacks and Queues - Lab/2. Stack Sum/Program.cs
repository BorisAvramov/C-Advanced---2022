using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            //Stack<int> stack = new Stack<int>();

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    stack.Push(numbers[i]);
            //}

            while (true)
            {
                string input = Console.ReadLine().ToLower();

                if (input == "end")
                {
                    break;
                }

                string[] data = input.Split();
                string command = data[0];
                if (command == "add")
                {
                    int firstNum = int.Parse(data[1]);
                    int secondNum = int.Parse(data[2]);

                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else if (command == "remove")
                {
                    int count = int.Parse(data[1]);

                    if (stack.Count >= count)
                    {
                        for (int i = 1; i <= count; i++)
                        {
                            stack.Pop();

                        }

                    }
                }



            }
            //int sum = 0;

            //foreach (var item in stack)
            //{
            //    sum += item;

            //}


            //int sum = stack.Sum();



            int sum = 0;
            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
