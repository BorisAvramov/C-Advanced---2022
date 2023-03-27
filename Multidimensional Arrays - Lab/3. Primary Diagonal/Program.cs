using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int columns = n;
            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {

                int[] curRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = curRow[col];

                }


            }

            int sum = 0;


            for (int rowCol = 0; rowCol < n; rowCol++)
            {
                sum += matrix[rowCol, rowCol];


            }


            Console.WriteLine(sum);

            


        }
    }
}
