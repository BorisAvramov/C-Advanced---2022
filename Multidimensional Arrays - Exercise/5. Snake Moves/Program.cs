using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            string softuni = Console.ReadLine();
            Queue<char> queue = new Queue<char>(softuni);
            char[,] matrix = new char[rows, cols];

            int indeSnake = 0;
            bool leftToRight = true;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (leftToRight)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        char temp = queue.Dequeue();
                        matrix[row, col] = temp;
                        queue.Enqueue(temp);


                        //========================================================
                        //matrix[row, col] = softuni[indeSnake];
                        //indeSnake++;
                        //if (indeSnake == softuni.Length)
                        //{
                        //    indeSnake = 0;
                        //}

                    }

                    leftToRight = false;
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {

                        char temp = queue.Dequeue();
                        matrix[row, col] = temp;
                        queue.Enqueue(temp);

                        //========================================================
                        //matrix[row, col] = softuni[indeSnake];
                        //indeSnake++;
                        //if (indeSnake == softuni.Length)
                        //{
                        //    indeSnake = 0;
                        //}
                    }
                    leftToRight = true;
                }

             
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }


        }
    }
}
