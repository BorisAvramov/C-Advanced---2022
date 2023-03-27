using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            char[,] matrix = new char[rows, cols];


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] currRoq = Console.ReadLine().Split();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = char.Parse(currRoq[col]);

                }
            }

            int sumEqual = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
               
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row < matrix.GetLength(0) - 1 && col < matrix.GetLength(1) - 1)
                    {
                        if (matrix[row, col] == matrix[row, col + 1] && matrix[row, col] == matrix[row + 1, col] && matrix[row, col] == matrix[row + 1, col + 1])
                        {
                            sumEqual++;
                        }
                    }

                    

                    
                }
                  

            }
            Console.WriteLine(sumEqual);



        }

    }
}
