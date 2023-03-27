namespace P05FashionBoutique
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int capacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(input);
            int sum = 0;
            int rank = 1;

            while (stack.Count > 0)
            {
                if (sum + stack.Peek() <= capacity)
                {

                    sum += stack.Peek();
                    stack.Pop();
                        
                }
                else
                {
                    sum = 0;
                    rank++;


                }


            }
            Console.WriteLine(rank);
        }
    }
}