using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = input[0];
            int columns = input[1];

            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                int[] currrow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int column = 0; column < columns; column++)
                {
                    matrix[row, column] = currrow[column];
                }

            }

            for (int column = 0; column < columns; column++)
            {
                int currSumColumn = 0;
                for (int row = 0; row < rows; row++)
                {

                    currSumColumn += matrix[row, column];

                }
                Console.WriteLine(currSumColumn);
            }

        }
    }
}
