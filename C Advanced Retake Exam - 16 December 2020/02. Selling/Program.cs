using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int rowCol = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rowCol,rowCol];

            matrix = ReadMatrix(matrix, rowCol);

            int rowS = 0;
            int colS = 0;

            bool isPillar = false;

            int firstPillRow = 0;
            int firstPillCol = 0;

            int secondPillRow = 0;
            int secondPillCol = 0;

            bool outOfTheBakery = false;
            bool collectMoney = false;

            int money = 0;

            for (int row = 0; row < rowCol; row++)
            {
                for (int col = 0; col < rowCol; col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        rowS = row;
                        colS = col;
                    }
                    if (matrix[row, col] == 'O')
                    {
                        if (isPillar == false)
                        {
                            firstPillRow = row;
                            firstPillCol = col;
                            isPillar = true;
                        }
                        else
                        {
                            secondPillRow = row;
                            secondPillCol = col;
                        }
                    }
                    
                }
            }

            while (true)
            {
                string direction = Console.ReadLine();
                int nextRow = NextRow(direction, rowS);
                int nextCol = NextCol(direction, colS);
                matrix[rowS, colS] = '-';

                if (!IsInRange(matrix, nextRow, nextCol))
                {
                    outOfTheBakery = true;
                    break;
                }

                if (matrix[nextRow, nextCol] == '-')
                {
                    matrix[nextRow, nextCol] = 'S';
                    rowS = nextRow;
                    colS = nextCol;
                    continue;
                }
                if (matrix[nextRow, nextCol] == 'O')
                {
                    matrix[nextRow, nextCol] = '-';

                    nextRow = FindOtherRowPill(matrix, nextRow, firstPillRow, secondPillRow);
                    nextCol = FindOtherCOlPill(matrix, nextCol, firstPillCol, secondPillCol);

                    matrix[nextRow, nextCol] = 'S';

                }
                if (char.IsDigit(matrix[nextRow, nextCol]))
                {
                    int price = matrix[nextRow, nextCol] - '0';

                    money += price;

                    matrix[nextRow, nextCol] = 'S';

                    if (money >= 50)
                    {
                        collectMoney = true;
                        break;
                    }

                }


                rowS = nextRow;
                colS = nextCol;
            }

            if (outOfTheBakery)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }

            if (collectMoney)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {money}");

            PrintMatrix(matrix);
        }

        private static int FindOtherCOlPill(char[,] matrix, int nextCol, int firstPillCol, int secondPillCol)
        {
            int nextColOtherPill = 0;

            if (nextCol == firstPillCol)
            {
                nextColOtherPill = secondPillCol;
            }
            else if (nextCol == secondPillCol)
            {
                nextColOtherPill = firstPillCol;
            }
            return nextColOtherPill;
        }

        private static int FindOtherRowPill(char[,] matrix, int nextRow,int firstPillRow,int secondPillRow)
        {
            int nextRowOtherPill = 0;

            if (nextRow == firstPillRow)
            {
                nextRowOtherPill = secondPillRow;
            }
            else if (nextRow == secondPillRow)
            {
                nextRowOtherPill = firstPillRow;
            }
            return nextRowOtherPill;
        }

        private static int NextCol(string command, int initialCol)
        {
            if (command == "right")
            {
                return ++initialCol;
            }
            if (command == "left")
            {
                return --initialCol;
            }
            return initialCol;

        }
        private static int NextRow(string command, int initialRow)
        {
            if (command == "up")
            {
                return --initialRow;
            }
            if (command == "down")
            {
                return ++initialRow;
            }

            return initialRow;
        }
        public static bool IsInRange(char[,] matrix, int row, int col)
        {
            return row >= 0
                && row < matrix.GetLength(0)
                && col >= 0
                && col < matrix.GetLength(1);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static char[,] ReadMatrix(char[,] matrix, int rowCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] charArr = Console.ReadLine().ToCharArray();


                for (int col = 0; col < charArr.Length; col++)
                {
                    matrix[row, col] = charArr[col];
                }

            }

            return matrix;
        }
    }
    
}
