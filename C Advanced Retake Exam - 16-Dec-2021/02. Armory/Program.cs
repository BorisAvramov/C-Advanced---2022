using System;

namespace _02._Armory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            char[,] matrix = ReadMatrix(n);
            int rowArmyOfficer = 0;
            int colArmyOfficier = 0;

            int rowMirror1 = 0;
            int colMirror1 = 0;

            int rowMirror2 = 0;
            int colMirror2 = 0;

            int countMirros = 0;

            int goldCoins = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row,col] == 'A')
                    {
                        rowArmyOfficer = row;
                        colArmyOfficier = col;
                    }

                    if (countMirros < 2 && matrix[row, col] == 'M')
                    {
                        countMirros++;
                        if (countMirros == 1)
                        {
                            rowMirror1 = row;
                            colMirror1 = col;


                        }
                        if (countMirros == 2)
                        {
                            rowMirror2 = row;
                            colMirror2 = col;
                        }

                    }

                }
            }

            bool outOfTheArmory = false;

            string command = Console.ReadLine();

            while (goldCoins < 65)
            {
                int nextRow = NextRow(command,rowArmyOfficer);
                int nextCol = NextCol(command, colArmyOfficier);
                    if (!CheckOutOfArmory(command, matrix, nextRow, nextCol))
                {
                    matrix[rowArmyOfficer, colArmyOfficier] = '-';
                    outOfTheArmory = true;
                    break;
                }

                if (char.IsDigit(matrix[nextRow, nextCol]))
                {
                    int curInt = matrix[nextRow, nextCol] - '0';
                    goldCoins += curInt;

                    matrix[rowArmyOfficer, colArmyOfficier] = '-';
                    matrix[nextRow, nextCol] = 'A';

                    rowArmyOfficer = nextRow;
                    colArmyOfficier = nextCol;
                }

                else if (matrix[nextRow, nextCol] == 'M')
                {
                    matrix[nextRow, nextCol] = '-';
                    matrix[rowArmyOfficer, colArmyOfficier] = '-';

                    if (rowMirror1 == nextRow && colMirror1 == nextCol)
                    {
                        matrix[rowMirror2, colMirror2] = 'A';
                        rowArmyOfficer = rowMirror2;
                        colArmyOfficier = colMirror2;
                    }
                    else
                    {
                        matrix[rowMirror1, colMirror1] = 'A';
                        rowArmyOfficer = rowMirror1;
                        colArmyOfficier = colMirror1;
                    }

                }
                else
                {
                    matrix[rowArmyOfficer, colArmyOfficier] = '-';
                    matrix[nextRow, nextCol] = 'A';
                    rowArmyOfficer = nextRow;
                    colArmyOfficier = nextCol;
                }

               

                command = Console.ReadLine();
            }

            if (outOfTheArmory)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
            Console.WriteLine($"The king paid {goldCoins} gold coins.");
            PrintMatrix(matrix);
        }

        private static bool CheckOutOfArmory(string command, char[,] matrix, int nextRow, int nextCol)
        {
            return nextRow >= 0 && nextRow < matrix.GetLength(0)
                && nextCol >= 0 && nextCol < matrix.GetLength(1);
        }

        private static int NextCol(string command, int colArmyOfficer)
        {
            if (command == "right")
            {
                return ++colArmyOfficer;
            }
            if (command == "left")
            {
                return --colArmyOfficer;
            }
            return colArmyOfficer;

        }

        private static int NextRow(string command, int rowArmy)
        {
            if (command == "up")
            {
                return --rowArmy;
            }
            if (command == "down")
            {
                return ++rowArmy;
            }

            return rowArmy;
        }


        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }

        }

        private static char[,] ReadMatrix( int n)
        {
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] arr = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {

                    matrix[row, col] = arr[col];

                }
            }

            return matrix;
        }
    }
}
