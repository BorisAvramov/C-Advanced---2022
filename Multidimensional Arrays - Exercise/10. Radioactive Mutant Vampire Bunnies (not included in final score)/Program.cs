using System;
using System.Collections.Generic;
using System.Linq;

namespace CONSOLEAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];
            char[,] matrix = new char[rows,cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] curRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = curRow[col];
                }
            }
            int playerRow = 0;
            int playerCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            bool win = false;
            bool died = false;

            string comands = Console.ReadLine();

            foreach (var curComand in comands)
            {
                int nextRow = playerRow;
                int nextCol = playerCol;
                if (curComand == 'U')
                {
                    nextRow--;

                }
                else if (curComand == 'D')
                {
                    nextRow++;
                }
                else if (curComand == 'R')
                {
                    nextCol++;
                }
                else if (curComand == 'L')
                {
                    nextCol--;
                }
                matrix[playerRow, playerCol] = '.';
                if (!IsRange(matrix, nextRow, nextCol))
                {
                    win = true;
                    
                   
                }
                if (IsRange(matrix, nextRow,nextCol))
                {
                    if (matrix[nextRow, nextCol] != 'B')
                    {
                        matrix[nextRow, nextCol] = 'P';
                    }
                    else
                    {
                        died = true;
                    }
                    
                }
                List<int[]> bunnies = new List<int[]>();
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            bunnies.Add(new int[] { row, col});
                        }
                    }
                }
                foreach (var curBunnie in bunnies)
                {
                    int row = curBunnie[0];
                    int col = curBunnie[1];
                    if (IsRange(matrix,row-1,col))
                    {
                        if (matrix[row - 1, col] == 'P')
                        {
                            died = true;
                        }
                        matrix[row - 1, col] = 'B';
                        
                    }
                    if (IsRange(matrix, row + 1, col))
                    {
                        if (matrix[row + 1, col] == 'P')
                        {
                            died = true;
                        }
                        matrix[row + 1, col] = 'B';
                    }
                    if (IsRange(matrix, row, col + 1))
                    {
                        if (matrix[row, col + 1] == 'P')
                        {
                            died = true;
                        }
                        matrix[row, col + 1] = 'B';
                    }
                    if (IsRange(matrix, row, col - 1))
                    {
                        if (matrix[row, col - 1] == 'P')
                        {
                            died = true;
                        }
                        matrix[row, col - 1] = 'B';
                    }
                }
                if (win)
                {
                    break;
                }
                playerRow = nextRow;
                playerCol = nextCol;

                if (died)
                {
                   
                    break;

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
            if (win)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
                
            }
            if (died)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
                

            }
        }
        private static bool IsRange(char[,] matrix, int nextRow, int nextCol)
        {
            return nextRow >= 0 && nextCol >= 0 && nextRow < matrix.GetLength(0) && nextCol < matrix.GetLength(1); 

        }
    }
}
