using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            //5 4 | 8 6 | 3 8 | 7 7 | 9
            //16 16 16 16 16

            //1 7 8 2 | 5 4 7 | 8 9 | 6 3 2 5 4 | 6
            //    20 20  20 20 20

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();

            int capacityRack = int.Parse(Console.ReadLine());
            int numRack = 1;
            int sum = 0;


            for (int i = 0; i < input.Length; i++)
            {

                stack.Push(input[i]);
                int currPiece = stack.Peek();

                if (sum + currPiece <= capacityRack)
                {
                    sum += currPiece;

                 
                }
                else if (sum + currPiece > capacityRack)
                {

                    sum = 0;
                    numRack++;
                    stack.Pop();
                    i--;

                }
               

            }
            Console.WriteLine(numRack);
        }
    } }
