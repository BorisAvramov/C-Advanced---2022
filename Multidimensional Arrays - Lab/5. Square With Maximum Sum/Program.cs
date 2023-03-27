using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[rowsCols[0], rowsCols[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] curRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = curRow[col];

                }
            }

            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                
                
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int curSum = 0;
                    curSum += matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (curSum > maxSum)
                    {
                        maxSum = curSum;
                        maxRow = row;
                        maxCol = col;
                    }

                }
            }

            Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol+1]}");
            Console.WriteLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol+1]}");
            Console.WriteLine(maxSum);


        }
    }
}
