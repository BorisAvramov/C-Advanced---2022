using System;

namespace _02._The_Battle_of_The_Five_Armies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());




            char[,] matrix = ReadMatrix(n);

            int armyRow = 0;
            int armyCol = 0;

            int rowDefeated = 0;
            int colDefeated = 0;


            bool mordor = false;
            bool defeated = false;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row,col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }

                }
            }

            while (true)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


                string direction = data[0];
                int spawnRow = int.Parse(data[1]);
                int spawnCol = int.Parse(data[2]);

                matrix[spawnRow, spawnCol] = 'O';

                int nextRow = armyRow;
                int nextCol = armyCol;


                if (direction == "up")
                {
                    nextRow--;
                }
                else if (direction == "left")
                {
                    nextCol--;
                }
                else if (direction == "right")
                {
                    nextCol++;
                }
                else
                {
                    nextRow++;
                    }

                if (!IsInRange(matrix, nextRow, nextCol))
                {
                    armor--;
                    
                    continue;
                }

                if (matrix[nextRow, nextCol] == 'M')
                {
                    armor--;
                    matrix[nextRow, nextCol] = '-';
                    matrix[armyRow, armyCol] = '-';
                    mordor = true;
                    break;

                }

                if (matrix[nextRow, nextCol] == 'O')
                {
                    armor -= 3;

                    if (armor <= 0)
                    {
                        defeated = true;
                        matrix[armyRow, armyCol] = '-';
                        matrix[nextRow, nextCol] = 'X';
                        rowDefeated = nextRow;
                        colDefeated = nextCol;

                        break;
                    }
                    else
                    {
                        matrix[armyRow, armyCol] = '-';
                        matrix[nextRow, nextCol] = 'A';

                        armyRow = nextRow;
                        armyCol = nextCol;
                    }
                   
                }
                if (matrix[nextRow, nextCol] == '-')
                {
                    armor--;
                    matrix[armyRow, armyCol] = '-';
                    matrix[nextRow, nextCol] = 'A';

                    armyRow = nextRow;
                    armyCol = nextCol;
                }


                    
                


            }



            if (mordor)
            {


                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
            }
            if (defeated)
            {

                Console.WriteLine($"The army was defeated at {rowDefeated};{colDefeated}.");
            }







            PrintMatrix(matrix);


        }

        private static bool IsInRange(char[,] matrix, int nextRow, int nextCol)
        {
            return nextRow >= 0 && nextRow < matrix.GetLength(0) &&
                nextCol >= 0 && nextCol < matrix.GetLength(1);


            throw new NotImplementedException();
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

        private static char[,] ReadMatrix(int n)
        {
            char[,] matrix = new char[n,n];

            for (int row = 0; row < n; row++)
            {
                string curRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = curRow[col];

                }
            }
            return matrix;
        }
    }
}
