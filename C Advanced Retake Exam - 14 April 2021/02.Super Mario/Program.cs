using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Super_Mario
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int lives = int.Parse(Console.ReadLine());


            int rows = int.Parse(Console.ReadLine());

            char [][] matrix = new char[rows][];
            matrix = ReadJagged(matrix, rows);

            //char[,] matrix = new char[rows,rows];

            //matrix = ReadMatrix(matrix, rows);

            int initialRow = 0;
            int initialCow = 0;

            bool died = false;

            int deadRow = 0;
            int deadCol = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {

                    if (matrix[row][col] == 'M')
                    {
                        initialRow = row;
                        initialCow = col;
                    }

                }
            }

            //for (int row = 0; row < rows; row++)
            //{
            //    for (int col = 0; col < rows; col++)
            //    {

            //        if (matrix[row] [col] == 'M')
            //        {
            //            initialRow = row;
            //            initialCow = col;
            //        }

            //    }
            //}

            while (true)
            {
               
                char[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                char direction = cmd[0];
                int rowB = (int)cmd[1] - '0';
                int colB = (int)cmd[2] - '0';
                matrix[rowB][colB] = 'B';


                int nextRow = NextRow(direction, initialRow);
                int nextCol = NextCol(direction, initialCow);

                if (!IsInRange(matrix, nextRow, nextCol))
                {
                    lives--;

                    if (lives <= 0)
                    {
                        died = true;
                        matrix[initialRow][ initialCow] = 'x';
                        break;
                    }
                    continue;
                }
                else
                {
                    lives--;
                    matrix[initialRow][ initialCow] = '-';
                }

                if (matrix[nextRow][nextCol] == 'P')
                {
                    matrix[nextRow][nextCol] = '-';
                    break;
                }

                if (matrix[nextRow][nextCol] == 'B')
                {
                    if (lives - 2 <= 0)
                    {
                        died = true;
                        matrix[nextRow][nextCol] = 'X';
                        deadRow = nextRow;
                        deadCol = nextCol;
                        break;
                    }
                    else
                    {
                        lives -= 2;
                        matrix[nextRow][nextCol] = 'M';

                    }

                }
                if (matrix[nextRow][nextCol] == '-')
                {
                    if (lives <= 0)
                    {
                        died = true;
                        matrix[nextRow][nextCol] = 'X';
                        deadRow = nextRow;
                        deadCol = nextCol;
                        break;
                    }
                    else
                    {
                        matrix[nextRow][nextCol] = 'M';



                    }
                }
                
                initialRow = nextRow;
                initialCow = nextCol;

            }

            if (died)
            {
                Console.WriteLine($"Mario died at {deadRow};{deadCol}.");
            }
            else
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }

            PrintJagged(matrix);


            

        }


        private static int NextCol(char command, int initialCol)
        {
            if (command == 'D')
            {
                return ++initialCol;
            }
            if (command == 'A')
            {
                return --initialCol;
            }
            return initialCol;

        }
        private static int NextRow(char command, int initialRow)
        {
            if (command == 'W')
            {
                return --initialRow;
            }
            if (command == 'S')
            {
                return ++initialRow;
            }

            return initialRow;
        }
        public static bool IsInRange(char[][] matrix, int row, int col)
        {
            return row >= 0
                && row < matrix.Length
                && col >= 0
                && col < matrix[row].Length;
        }

        private static void PrintJagged(char[][] jagged)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col]);
                }
                Console.WriteLine();
            }
        }
        //private static void PrintMatrix(char[,] matrix)
        //{
        //    for (int row = 0; row < matrix.GetLength(0); row++)
        //    {
        //        for (int col = 0; col < matrix.GetLength(1); col++)
        //        {
        //            Console.Write(matrix[row, col]);
        //        }
        //        Console.WriteLine();
        //    }
        //}


        private static char[][] ReadJagged(char[][] jagged, int r)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                string curRow = Console.ReadLine();
                jagged[row] = new char[curRow.Length];
                for (int col = 0; col < curRow.Length; col++)
                {
                    jagged[row][col] = curRow[col];
                }

            }


            return jagged;
        }
        //private static char[,] ReadMatrix(char[,] matrix, int rowCol)
        //{
        //    for (int row = 0; row < matrix.GetLength(0); row++)
        //    {
        //        char[] charArr = Console.ReadLine().ToCharArray();


        //        for (int col = 0; col < charArr.Length; col++)
        //        {
        //            matrix[row, col] = charArr[col];
        //        }

        //    }

        //    return matrix;
        //}
    
    }
}
