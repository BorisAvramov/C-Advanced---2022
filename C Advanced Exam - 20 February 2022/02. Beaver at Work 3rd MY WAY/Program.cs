using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Beaver_at_Work_3rd_MY_WAY
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = ReadMatrix(size);

            int countWoodBranches = 0;
            int beaverRow = 0;
            int beaverCol = 0;
            List<char> branches = new List<char>();

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                         beaverRow = row;
                         beaverCol = col;
                    }
                    if (char.IsLower(matrix[row, col]))
                    {
                        countWoodBranches++;
                    }

                }
            }
            

            string command = Console.ReadLine();
            while (command != "end" && countWoodBranches > 0)
            {
                if (command == "up")
                {
                    Move(- 1, 0, beaverRow, beaverCol, matrix, branches, command, countWoodBranches );
                }
                if (command == "down")
                {
                    Move(1, 0,  beaverRow, beaverCol, matrix, branches, command, countWoodBranches);

                }
                if (command == "right")
                {
                    Move(0, 1, beaverRow, beaverCol, matrix, branches, command, countWoodBranches);

                }
                if (command == "left")
                {
                    Move(0, -1, beaverRow, beaverCol, matrix, branches, command, countWoodBranches);

                }

                command = Console.ReadLine();
            }

            if (countWoodBranches > 0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {countWoodBranches} branches left.");
            }
            else
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches)}.");
            }



            PrintMatrix(matrix, size);


        }

        private static void Move(int row, int col, int beaverRow, int beaverCol, char[,] matrix, List<char> branches, string command, int countWoodBranches)
        {
            if (!isValid(beaverRow  + row , beaverCol + col, matrix))
            {
                if (branches.Count > 0)
                {
                    branches.Remove(branches[branches.Count - 1]);

                }
            }
            else if (matrix[beaverRow + row, beaverCol + col] == '-')
            {
                matrix[beaverRow, beaverCol] = '-';
                beaverRow += row;
                beaverCol += col;

                matrix[beaverRow, beaverCol] = 'B';

            }
            else if (char.IsLower(matrix[beaverRow + row, beaverCol + col]))
            {
                

                matrix[beaverRow, beaverCol] = '-';
                beaverRow += row;
                beaverCol += col;
                branches.Add(matrix[beaverRow, beaverCol]);
                countWoodBranches--;
                matrix[beaverRow, beaverCol] = 'B';

            }
            else if (matrix[beaverRow + row, beaverCol + col] == 'F')
            {
                matrix[beaverRow , beaverCol] = '-';
                matrix[beaverRow + row, beaverCol + col] = '-';


                if (command == "up")
                {
                    if (beaverRow + row == 0)
                    {
                        beaverRow = matrix.GetLength(0) - 1;
                        beaverCol = beaverCol + col;

                        if (char.IsLower(matrix[beaverRow, beaverCol]))
                        {
                            branches.Add(matrix[beaverRow, beaverCol]);
                            countWoodBranches--;


                           

                        }
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        beaverRow = 0;
                        beaverCol += col;

                        if (char.IsLower(matrix[beaverRow, beaverCol]))
                        {
                            branches.Add(matrix[beaverRow, beaverCol]);
                            countWoodBranches--;


                        }
                        matrix[beaverRow, beaverCol] = 'B';

                    }
                     

                }

                else if (command == "down")
                {
                    
                        if (beaverRow + row == matrix.GetLength(0) - 1)
                        {
                            beaverRow = 0;
                            beaverCol = beaverCol + col;

                            if (char.IsLower(matrix[beaverRow, beaverCol]))
                            {
                                branches.Add(matrix[beaverRow, beaverCol]);
                                countWoodBranches--;



                            }
                        matrix[beaverRow, beaverCol] = 'B';

                    }
                    else
                        {
                            beaverRow = matrix.GetLength(0) - 1;
                            beaverCol += col;

                            if (char.IsLower(matrix[beaverRow, beaverCol]))
                            {
                                branches.Add(matrix[beaverRow, beaverCol]);
                                countWoodBranches--;


                            }
                            matrix[beaverRow, beaverCol] = 'B';

                        }

                    
                }
                else if (command == "right")
                {
                    if (beaverRow + col == matrix.GetLength(1) - 1)
                    {
                        beaverRow = beaverRow + row ;
                        beaverCol = 0;

                        if (char.IsLower(matrix[beaverRow, beaverCol]))
                        {
                            branches.Add(matrix[beaverRow, beaverCol]);
                            countWoodBranches--;


                            matrix[beaverRow, beaverCol] = 'B';

                        }
                        matrix[beaverRow, beaverCol] = 'B';

                    }
                    else
                    {
                        beaverRow = beaverRow + row;
                        beaverCol = matrix.GetLength(1);

                        if (char.IsLower(matrix[beaverRow, beaverCol]))
                        {
                            branches.Add(matrix[beaverRow, beaverCol]);
                            countWoodBranches--;


                        }
                        matrix[beaverRow, beaverCol] = 'B';

                    }
                }
                else if (command == "left")
                {
                    if(beaverRow + col == 0)
                    {
                        beaverRow = beaverRow + row;
                        beaverCol = matrix.GetLength(1) - 1;

                        if (char.IsLower(matrix[beaverRow, beaverCol]))
                        {
                            branches.Add(matrix[beaverRow, beaverCol]);
                            countWoodBranches--;



                        }
                        matrix[beaverRow, beaverCol] = 'B';

                    }
                    else
                    {
                        beaverRow = beaverRow + row;
                        beaverCol = 0;

                        if (char.IsLower(matrix[beaverRow, beaverCol]))
                        {
                            branches.Add(matrix[beaverRow, beaverCol]);
                            countWoodBranches--;


                        }
                        matrix[beaverRow, beaverCol] = 'B';

                    }
                }

            }
           

            
        }

        private static bool isValid(int beaverRow, int beaverCol, char[,] matrix)
        {
            return beaverRow >= 0 && beaverRow < matrix.GetLength(0) && beaverCol >= 0 && beaverCol < matrix.GetLength(1);
        }

        private static void PrintMatrix(char[,] matrix, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col] + " " );
                }
                Console.WriteLine();
            }
        }

        private static char[,] ReadMatrix(int size)
        {
            char[,] matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                char[] arr = Console.ReadLine().Split(" ").Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            return matrix;
        }
    }
}
