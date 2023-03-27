using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int numRows = input[0];
            int numColumns = input[1];

            int[,] matrix = new int[numRows, numColumns];
            int sum = 0;

                                       //numRows
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                                                // numColumns
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = currRow[column];
                    sum += matrix[row, column];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
