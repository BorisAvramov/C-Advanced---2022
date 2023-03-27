using System;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {   
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            matrix = REadMatrix(matrix, n);

            
            int armyRow = 0;
            int armyCol = 0;

            int rowDefeated = 0;
            int colDefeated = 0;


            bool mordor = false;
            bool defeated = false;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'A')
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

                matrix[spawnRow][ spawnCol] = 'O';

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
                    if (armor <= 0)
                    {
                        defeated = true;
                        matrix[armyRow][armyCol] = '-';
                        matrix[nextRow][nextCol] = 'X';
                        rowDefeated = nextRow;
                        colDefeated = nextCol;

                        break;
                    }
                    else
                    {
                        continue;

                    }
                }

                if (matrix[nextRow][nextCol] == 'M')
                {
                    armor--;
                    matrix[nextRow][ nextCol] = '-';
                    matrix[armyRow][ armyCol] = '-';
                    mordor = true;
                    break;

                }

                if (matrix[nextRow][ nextCol] == 'O')
                {
                    armor -= 3;

                    if (armor <= 0)
                    {
                        defeated = true;
                        matrix[armyRow][ armyCol] = '-';
                        matrix[nextRow][nextCol] = 'X';
                        rowDefeated = nextRow;
                        colDefeated = nextCol;

                        break;
                    }
                    else
                    {
                        matrix[armyRow][ armyCol] = '-';
                        matrix[nextRow][ nextCol] = 'A';

                        armyRow = nextRow;
                        armyCol = nextCol;
                    }

                }
                if (matrix[nextRow][ nextCol] == '-')
                {
                    armor--;
                    if (armor <= 0)
                    {
                        defeated = true;
                        matrix[armyRow][armyCol] = '-';
                        matrix[nextRow][nextCol] = 'X';
                        rowDefeated = nextRow;
                        colDefeated = nextCol;

                        break;
                    }

                    matrix[armyRow][ armyCol] = '-';
                    matrix[nextRow][ nextCol] = 'A';

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



            PrintMAtrix(matrix);

        }
        private static bool IsInRange(char[][] matrix, int nextRow, int nextCol)
        {
            bool row = false;
            
            if (nextRow >= 0 && nextRow < matrix.Length)
            {
                row = true;
            }
            bool col = true;

            for (int row1 = 0; row1 < matrix.Length; row1++)
            {
                if (nextCol == matrix[row1].Length)
                {
                    col = false;
                }
            }

            if (row && col)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }
        private static void PrintMAtrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();

            }

            
        }

        private static char[][] REadMatrix(char[][] matrix, int n)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                string arr = Console.ReadLine();
                
                matrix[row] = new char[arr.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {

                    matrix[row][col] = arr[col];

                }


            }
            return matrix;
        }
    }
}
