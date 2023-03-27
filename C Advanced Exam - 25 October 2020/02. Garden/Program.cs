using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] intElements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rowM = intElements[0];
            int colM = intElements[1];

            int[,] matrix = new int[rowM,colM];



            List<int> flowersCordinates = new List<int>();
            string input = Console.ReadLine();
            while (input != "Bloom Bloom Plow")
            {
                int[] curPos = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();    
                int curRow = curPos[0];
                int curCol = curPos[1];

                if (!IsInRange(matrix, curRow, curCol))
                {
                    Console.WriteLine("Invalid coordinates.");
                    input = Console.ReadLine();
                    continue;
                }

                flowersCordinates.Add(curRow);
                flowersCordinates.Add(curCol);

                matrix[curRow, curCol]++;

                input = Console.ReadLine();

            }

          

            for (int i = 0; i < flowersCordinates.Count; i+=2)
            {
                int curRow = flowersCordinates[i];
                int curCol = flowersCordinates[i + 1];

                //up
                for (int row = curRow - 1; row >= 0; row--)
                {
                    matrix[row, curCol]++;
                }
                //down
                for (int row = curRow + 1; row < matrix.GetLength(0); row++)
                {
                    matrix[row, curCol]++;
                }

                //right
                for (int col = curCol + 1; col < matrix.GetLength(1); col++)
                {
                    matrix[curRow, col]++;
                }

                //left
                for (int col = curCol - 1; col >= 0; col--)
                {
                    matrix[curRow, col]++;
                }

            }



            PrintMatrix(matrix);

        }


        public static bool IsInRange(int[,] matrix, int row, int col)
        {
            return row >= 0
                && row < matrix.GetLength(0)
                && col >= 0
                && col < matrix.GetLength(1);
        }
        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
