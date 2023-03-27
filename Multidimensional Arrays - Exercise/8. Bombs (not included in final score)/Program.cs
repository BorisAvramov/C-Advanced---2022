using System;
using System.Linq;

namespace _8._Bombs__not_included_in_final_score_
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCols = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rowsCols,rowsCols];

            for (int row = 0; row < rowsCols; row++)
            {
                int[] curRow = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < rowsCols; col++)
                {
                    matrix[row, col] = curRow[col];
                }
            }

            int[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int aliveCells = 0;
            int sum = 0;

            for (int i = 0; i < input.Length; i+=2)
            {
                int curBombRow = input[i];
                int curBombRCol = input[i+1];
                
               
                if (matrix[curBombRow,curBombRCol] <= 0)
                {
                    continue;
                }
                int tempBombValue = matrix[curBombRow, curBombRCol];
                matrix[curBombRow, curBombRCol] = 0;
                //upcenter upLeft UpRight
                if (IsValidCord(matrix, curBombRow - 1, curBombRCol) &&  NotDied(matrix, curBombRow - 1, curBombRCol) )
                {
                    matrix[curBombRow - 1, curBombRCol] -= tempBombValue;
                }
                if (IsValidCord(matrix, curBombRow - 1, curBombRCol - 1) && NotDied(matrix, curBombRow - 1, curBombRCol - 1) )
                {
                    matrix[curBombRow - 1, curBombRCol - 1] -= tempBombValue;
                }
                if (IsValidCord(matrix, curBombRow - 1, curBombRCol + 1) && NotDied(matrix, curBombRow - 1, curBombRCol + 1) )
                {
                    matrix[curBombRow - 1, curBombRCol + 1] -= tempBombValue;
                }
                //Left Right
                if (IsValidCord(matrix, curBombRow, curBombRCol - 1) && NotDied(matrix, curBombRow, curBombRCol - 1) )
                {
                    matrix[curBombRow, curBombRCol - 1] -= tempBombValue;
                }
                if (IsValidCord(matrix, curBombRow, curBombRCol + 1) && NotDied(matrix, curBombRow, curBombRCol + 1) )
                {
                    matrix[curBombRow, curBombRCol + 1] -= tempBombValue;
                }
                //downcenter downLeft downRight
                if (IsValidCord(matrix, curBombRow + 1, curBombRCol) && NotDied(matrix, curBombRow + 1, curBombRCol))
                {
                    matrix[curBombRow + 1, curBombRCol] -= tempBombValue;
                }
                if ( IsValidCord(matrix, curBombRow + 1, curBombRCol - 1) && NotDied(matrix, curBombRow + 1, curBombRCol - 1) )
                {
                    matrix[curBombRow + 1, curBombRCol - 1] -= tempBombValue;
                }
                if (IsValidCord(matrix, curBombRow + 1, curBombRCol + 1) && NotDied(matrix, curBombRow + 1, curBombRCol + 1) )
                {
                    matrix[curBombRow + 1, curBombRCol + 1] -= tempBombValue;
                }
            }

            for (int row = 0; row < rowsCols; row++)
            {
                for (int col = 0; col < rowsCols; col++)
                {
                    if (matrix[row,col] > 0 )
                    {
                        aliveCells++;
                        sum += matrix[row, col];

                    }

                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            

            for (int row = 0; row < rowsCols; row++)
            {
                for (int col = 0; col < rowsCols; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }

        }

        private static bool IsValidCord(int[,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }

        private static bool NotDied(int[,] matrix, int row, int col)
        {
            return matrix[row, col] > 0;

        }
    }
}
