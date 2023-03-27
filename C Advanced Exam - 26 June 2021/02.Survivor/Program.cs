using System;
using System.Linq;

namespace _02.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int r = int.Parse(Console.ReadLine());

            char[][] jagged = new char[r][];

            jagged = ReadJagged(jagged, r);


            int myT = 0;
            int oppT = 0;

            

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Gong")
                {
                    break;
                }

                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int curRow = int.Parse(data[1]);
                int curCol = int.Parse(data[2]);
                string command = data[0];
                if (!IsValid(curRow,curCol, jagged))
                {
                    continue;
                }

                if (command == "Find")
                {
                    if (jagged[curRow] [curCol] == 'T')
                    {
                        myT++;
                        jagged[curRow][curCol] = '-';
                    }

                }

                if (command == "Opponent")
                {
                    if (jagged[curRow][curCol] == 'T')
                    {
                        oppT++;
                        jagged[curRow][curCol] = '-';
                    }
                    string direction = data[3];

                    int[] cordinates = GetCordinates(jagged, direction, curRow, curCol);

                    if (direction == "up")
                    {
                        for (int i = curRow - 1; i >=cordinates[0]; i--)
                        {
                            if (jagged[i][curCol] == 'T')
                            {
                                jagged[i][curCol] = '-';
                                oppT++;
                            }
                        }
                    }
                    if (direction == "down")
                    {
                        for (int i = curRow + 1; i <= cordinates[0]; i++)
                        {
                            if (jagged[i][curCol] == 'T')
                            {
                                jagged[i][curCol] = '-';
                                oppT++;
                            }
                        }
                    }
                    if (direction == "right")
                    {
                        for (int i = curCol + 1; i <= cordinates[1]; i++)
                        {
                            if (jagged[curRow][i] == 'T')
                            {
                                jagged[curRow][i] = '-';
                                oppT++;
                            }

                        }
                    }
                    if (direction == "left")
                    {
                        for (int i = curCol - 1; i >= cordinates[1]; i--)
                        {
                            if (jagged[curRow][i] == 'T')
                            {
                                jagged[curRow][i] = '-';
                                oppT++;
                            }
                        }
                    }
                }

            }

           

            PrintJagged(jagged);
            Console.WriteLine($"Collected tokens: {myT}");
            Console.WriteLine($"Opponent's tokens: {oppT}");
        }

        private static int[] GetCordinates(char[][] jagged, string direction, int curRow, int curCow)
        {
            int[] cordinates = new int[2];
            if (direction == "up")
            {
                cordinates[1] = curCow;
                if (curRow - 3 < 0)
                {
                    cordinates[0] = 0;
                }
                else
                {
                    cordinates[0] = curRow - 3;
                }

            }
            if (direction == "down")
            {
                cordinates[1] = curCow;
                if (curRow + 3 > jagged.Length - 1)
                {
                    cordinates[0] = jagged.Length - 1;
                }
                else
                {
                    cordinates[0] = curRow + 3;
                }
            }
            if (direction == "right")
            {
                cordinates[0] = curRow;

                if (curCow + 3 > jagged[curRow].Length - 1)
                {
                    cordinates[1] = jagged[curRow].Length - 1;

                }
                else
                {
                    cordinates[1] = curCow + 3;
                }


            }
            if (direction == "left")
            {
                cordinates[0] = curRow;

                if (curCow - 3 < 0)
                {
                    cordinates[1] = 0;

                }
                else
                {
                    cordinates[1] = curCow - 3;
                }
            }

            return cordinates;
        }

        private static bool IsValid(int curRow, int curCol, char[][] jagged)
        {
            return curRow >= 0 && curCol >= 0
               && curRow < jagged.Length && curCol < jagged[curRow].Length; 


            
        }

        private static void PrintJagged(char[][] jagged)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col] + " ");

                }
                Console.WriteLine();
            }


            
        }

        private static char[][] ReadJagged(char[][] jagged, int r)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                char[] curRow = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                jagged[row] = new char[curRow.Length];
                for (int col = 0; col < curRow.Length; col++)
                {
                    jagged[row][col] = curRow[col];
                }

            }


            return jagged;
        }
    }
}
