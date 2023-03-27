using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int rowCol = int.Parse(Console.ReadLine());
            int nCom = int.Parse(Console.ReadLine());
            char[,] matrix = new char[rowCol, rowCol];

            matrix = ReadMatrix(matrix, rowCol);

            int[] playerInitilanCordinate = new int[2];
            int[] bonusInitilanCordinate = new int[2];
            int[] trapInitilanCordinate = new int[2];
            int[] finishMarkInitilanCordinate = new int[2];

            bool win = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        playerInitilanCordinate[0] = row;
                        playerInitilanCordinate[1] = col;
                    }
                    if (matrix[row, col] == 'B')
                    {
                        bonusInitilanCordinate[0] = row;
                        bonusInitilanCordinate[1] = col;
                    }
                    if (matrix[row, col] == 'T')
                    {

                        trapInitilanCordinate[0] = row;
                        trapInitilanCordinate[1] = col;
                    }
                    if (matrix[row, col] == 'F')
                    {
                        finishMarkInitilanCordinate[0] = row;
                        finishMarkInitilanCordinate[1] = col;
                    }

                }
            }
            for (int i = 0; i < nCom; i++)
            {
                string command = Console.ReadLine();

                matrix[playerInitilanCordinate[0], playerInitilanCordinate[1]] = '-';
               
                int[] nextCordinates = GetCordinates(command, playerInitilanCordinate);
                if (!IsInRange(matrix, nextCordinates[0], nextCordinates[1]))
                {
                    nextCordinates = GetCordinatesInRange(matrix, nextCordinates);

                }

                if (CheckBonus(matrix, nextCordinates))
                {

                    nextCordinates = GetCordinates(command, nextCordinates);

                    if (!IsInRange(matrix, nextCordinates[0], nextCordinates[1]))
                    {
                        nextCordinates = GetCordinatesInRange(matrix, nextCordinates);

                    }

                }
                else if (CheckTrap(matrix, nextCordinates))
                {
                    nextCordinates = GetCordinatesOppozite(command, nextCordinates);

                    if (!IsInRange(matrix, nextCordinates[0], nextCordinates[1]))
                    {
                        nextCordinates = GetCordinatesInRange(matrix, nextCordinates);

                    }

                }
                if (CheckWin(matrix, nextCordinates))
                {
                    win = true;
                    matrix[nextCordinates[0], nextCordinates[1]] = 'f';
                    break;
                }
                matrix[nextCordinates[0], nextCordinates[1]] = 'f';

                playerInitilanCordinate[0] = nextCordinates[0];
                playerInitilanCordinate[1] = nextCordinates[1];

            }


            if (win)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            PrintMatrix(matrix);


            

        }

        private static int[] GetCordinatesOppozite(string command, int[] nextCordinates)
        {
            if (command == "up")
            {
                nextCordinates[0]++;

            }
            if (command == "down")
            {
                nextCordinates[0]--;
            }
            if (command == "right")
            {
                nextCordinates[1]--;
            }
            if (command == "left")
            {
                nextCordinates[1]++;
            }

            return nextCordinates;
        }

        private static int[] GetCordinatesInRange(char[,] matrix,int[] nextCordinates)
        {
            if (nextCordinates[0] < 0)
            {
                nextCordinates[0] = matrix.GetLength(0) - 1;
            }
            if (nextCordinates[0] > matrix.GetLength(0) - 1)
            {
                nextCordinates[0] = 0;
            }
            if (nextCordinates[1] < 0)
            {
                nextCordinates[1] = matrix.GetLength(1) - 1;
            }
            if (nextCordinates[0] > matrix.GetLength(0) - 1)
            {
                nextCordinates[1] = 0;
            }
            return nextCordinates;
        }

        public static bool IsInRange(char[,] matrix, int row, int col)
        {
            return row >= 0
                && row < matrix.GetLength(0)
                && col >= 0
                && col < matrix.GetLength(1);
        }

        private static bool CheckTrap(char[,] matrix, int[] nextCordinates)
        {
            return matrix[nextCordinates[0], nextCordinates[1]] == 'T';
        }

        private static bool CheckBonus(char[,] matrix, int[] nextCordinates)
        {
            return matrix[nextCordinates[0], nextCordinates[1]] == 'B';
        }

        private static bool CheckWin(char[,] matrix, int[] nextCordinates)
        {
            return matrix[nextCordinates[0], nextCordinates[1]] == 'F';
        }


        private static int[] GetCordinates(string command, int[] initialCordinates)
        {

            if (command == "up")
            {
                initialCordinates[0]--;

            }
            if (command == "down")
            {
                initialCordinates[0]++;
            }
            if (command == "right")
            {
                initialCordinates[1]++;
            }
            if (command == "left")
            {
                initialCordinates[1]--;
            }

            return initialCordinates;

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


        

       
    }
       
    
}
