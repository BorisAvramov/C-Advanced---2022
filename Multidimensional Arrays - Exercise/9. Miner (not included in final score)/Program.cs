using System;
using System.Linq;

namespace _9._Miner__not_included_in_final_score_
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCols = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            char[,] matrix = new char[rowsCols, rowsCols];

            matrix = ReadMatrix(matrix, rowsCols, rowsCols);

            int rowStartPosition = 0;
            int colStartPosition = 0;
            int numCoals = 0;
            int collectedCoals = 0;
            bool collectedAll = false;
            bool gameOver = false;

            for (int row = 0; row < rowsCols; row++)
            {
                for (int col = 0; col < rowsCols; col++)
                {
                    if (matrix[row,col] == 's')
                    {
                        rowStartPosition = row;
                        colStartPosition = col;
                    }
                    if (matrix[row, col] == 'c')
                    {
                        
                        numCoals++;
                    }
                }
            }

            foreach (var curCommand in commands)
            {
                

                if (curCommand == "up" && IsValid(matrix, rowStartPosition - 1))
                {
                    if (matrix[rowStartPosition - 1, colStartPosition] == 'c')
                    {
                        collectedCoals++;
                        numCoals--;
                        matrix[rowStartPosition - 1, colStartPosition] = '*';
                        
                    }
                    if (matrix[rowStartPosition - 1, colStartPosition] == 'e')
                    {
                        gameOver = true;
                        rowStartPosition = rowStartPosition - 1;
                        break;

                    }
                    rowStartPosition = rowStartPosition - 1;
                }
                else if (curCommand == "down" && IsValid(matrix, rowStartPosition + 1))
                {
                    if (matrix[rowStartPosition + 1, colStartPosition] == 'c')
                    {
                        collectedCoals++;
                        numCoals--;
                        matrix[rowStartPosition + 1, colStartPosition] = '*';
                       
                    }
                    if (matrix[rowStartPosition + 1, colStartPosition] == 'e')
                    {
                        gameOver = true;
                        rowStartPosition = rowStartPosition + 1;
                        break;

                    }
                    rowStartPosition = rowStartPosition + 1;
                }
                else if (curCommand == "right" && IsValid(matrix, colStartPosition + 1))
                {
                    if (matrix[rowStartPosition, colStartPosition + 1] == 'c')
                    {
                        collectedCoals++;
                        numCoals--;
                        matrix[rowStartPosition, colStartPosition + 1] = '*';
                        
                    }
                    if (matrix[rowStartPosition, colStartPosition + 1] == 'e')
                    {
                        gameOver = true;
                        colStartPosition = colStartPosition + 1;
                        break;

                    }
                    colStartPosition = colStartPosition + 1;
                }
                else if (curCommand == "left" && IsValid(matrix, colStartPosition - 1))
                {
                    if (matrix[rowStartPosition, colStartPosition - 1] == 'c')
                    {
                        collectedCoals++;
                        numCoals--;
                        matrix[rowStartPosition, colStartPosition - 1] = '*';
                        
                    }
                    if (matrix[rowStartPosition, colStartPosition - 1] == 'e')
                    {
                        gameOver = true;
                        colStartPosition = colStartPosition - 1;
                        break;

                    }
                    colStartPosition = colStartPosition - 1;
                }
                if (numCoals == 0)
                {
                    collectedAll = true;
                    break;
                }

            }
            if (collectedAll)
            {
                Console.WriteLine($"You collected all coals! ({rowStartPosition}, {colStartPosition})");
            }
            else if (gameOver)
            {
                Console.WriteLine($"Game over! ({rowStartPosition}, {colStartPosition})");
            }
            else
            {
                Console.WriteLine($"{numCoals} coals left. ({rowStartPosition}, {colStartPosition})");
            }

        }

        private static bool IsValid(char[,] matrix, int rowOrCol)
        {
            return rowOrCol >= 0 && rowOrCol < matrix.GetLength(0);

        }

        private static char[,] ReadMatrix(char[,] matrix, int rowsCols1, int rowsCols2)
        {
            for (int row = 0; row < rowsCols1; row++)
            {
                char[] curRow = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < rowsCols2; col++)
                {
                    matrix[row, col] = curRow[col];

                }
            }
            return matrix;


        }
    }
}
