using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Beaver_at_Work
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n,n];

            matrix = ReadMatrix(n, matrix);

            int countWoodBraches = 0;
            int startRowPosition = 0;
            int startColPosition = 0;

            Stack<char> branches = new Stack<char>();

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (char.IsLower(matrix[row, col]) && char.IsLetter(matrix[row, col]))
                    {
                        countWoodBraches++;

                    }
                    if (matrix[row, col] == 'B')
                    {
                        startRowPosition = row;
                        startColPosition = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "end" && countWoodBraches > 0)
            {
                //matrix[startRowPosition, startColPosition] = '-'
                

                if (!IsInRange(command, startRowPosition, startColPosition, matrix))
                {
                    
                    if (branches.Count > 0)
                    {
                        
                        branches.Pop();
                      
                    }
                    command = Console.ReadLine();
                    continue;
                }
                char nextPositin = GetNextDirection(command, startRowPosition, startColPosition, matrix);
                if (char.IsLower(nextPositin) && char.IsLetter(nextPositin))
                {
                    countWoodBraches--;
                    branches.Push(nextPositin);

                    matrix[startRowPosition, startColPosition] = '-';
                    

                    startRowPosition = GetNewRow(command, startRowPosition);
                    startColPosition = GetNewCol(command, startColPosition);

                    matrix[startRowPosition, startColPosition] = 'B';

                }
                else if (nextPositin == 'F')
                {
                    matrix[startRowPosition, startColPosition] = '-';
                    startRowPosition = GetNewRow(command, startRowPosition);
                    startColPosition = GetNewCol(command, startColPosition);
                    matrix[startRowPosition, startColPosition] = '-';
                    if (IsLastIndex(startRowPosition, startColPosition, matrix, command))
                    {
                        if (command == "up")
                        {
                            startRowPosition = matrix.GetLength(0) - 1;
                        }
                        if (command == "down")
                        {
                            startRowPosition = 0;
                        }
                        if (command == "right")
                        {
                            startColPosition = 0;
                        }
                        if (command == "left")
                        {
                            startColPosition = matrix.GetLength(1) - 1;
                        }

                        if (char.IsLetter(matrix[startRowPosition, startColPosition]) && char.IsLower(matrix[startRowPosition, startColPosition]))
                        {
                            countWoodBraches--;
                            branches.Push(matrix[startRowPosition, startColPosition]);
                        }
                        matrix[startRowPosition, startColPosition] = 'B';
                    }
                    else
                    {
                        if (command == "up")
                        {
                          
                            startRowPosition = 0;
                            matrix[startRowPosition, startColPosition] = 'B';

                        }
                        if (command == "down")
                        {
                            startRowPosition = matrix.GetLength(0);
                            matrix[startRowPosition, startColPosition] = 'B';
                        }
                        if (command == "right")
                        {
                               

                            startColPosition = matrix.GetLength(1);
                            matrix[startRowPosition, startColPosition] = 'B';
                        }
                        if (command == "left")
                        {
                            
                            startColPosition = matrix.GetLength(1);
                            matrix[startRowPosition, startColPosition] = 'B';
                        }

                        //if (char.IsLetter(matrix[startRowPosition, startColPosition]) && char.IsLower(matrix[startRowPosition, startColPosition]))
                        //{
                        //    countWoodBraches--;
                        //    branches.Push(matrix[startRowPosition, startColPosition]);
                        //}
                        //matrix[startRowPosition, startColPosition] = 'B';
                    }
                    

                }
                else
                {
                    matrix[startRowPosition, startColPosition] = '-';
                    startRowPosition = GetNewRow(command, startRowPosition);
                    startColPosition = GetNewCol(command, startColPosition);
                    matrix[startRowPosition, startColPosition] = 'B';
                }

                command = Console.ReadLine();
            }


            if (countWoodBraches == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {countWoodBraches} branches left.");
            }

            PritnMatrix(matrix, n);

            



        }

        private static bool IsLastIndex(int startRowPosition, int startColPosition, char[,] matrix, string command)
        {
            if (command == "up")
            {
                return startRowPosition == 0;
                
            }
            if (command == "down")
            {
                return startRowPosition == matrix.GetLength(0) - 1;
            }
            if (command == "right")
            {
                return startColPosition  == matrix.GetLength(1) - 1;
            }
            
             return startColPosition  == 0;
            


                
        }

        private static int GetNewCol(string command, int startColPosition)
        {

            if (command == "right")
            {
                startColPosition += 1;
            }
            if (command == "left")
            {
                startColPosition -= 1;
            }
            return startColPosition;
        }

        private static int GetNewRow(string command, int startRowPosition)
        {
            if (command == "up")
            {
                startRowPosition -= 1;

            }
            if (command == "down")
            {
                startRowPosition += 1;
            }
            return startRowPosition;
           
        }

        private static bool IsInRange(string command, int startRowPosition, int startColPosition, char[,] matrix)
        {
            
            if (command == "up")
            {
                if (startRowPosition - 1 >=0)
                {
                    return true;
                }

            }
            if (command == "down")
            {
                if (startRowPosition + 1 < matrix.GetLength(0))
                {
                    return true;
                }
            }
            if (command == "right")
            {
                if (startColPosition + 1 < matrix.GetLength(1))
                {
                    return true;
                }
            }
            if (command == "left")
            {
                if (startColPosition - 1 >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        private static char GetNextDirection(string command, int startRowPosition, int startColPosition, char[,] matrix)
        {
            if (command == "up")
            {
                
                return matrix[startRowPosition - 1, startColPosition];
            }
            if (command == "down")
            {
                return matrix[startRowPosition + 1, startColPosition];
            }
            if (command == "right")
            {
                return matrix[startRowPosition, startColPosition + 1];
            }
            return matrix[startRowPosition, startColPosition - 1];
           
        }

        private static void PritnMatrix(char[,] matrix, int n)
        {
            for (int row = 0; row < n; row++)
            {

                for (int col = 0; col < n; col++)
                {

                    Console.Write(matrix[row, col] + " ");

                }
                Console.WriteLine();
            }
        }

        private static char[,] ReadMatrix(int n, char[,]matrix)
        {
            for (int row = 0; row < n; row++)
            {
                char[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {

                    matrix[row, col] = arr[col];

                }
            }
            return matrix;
        }
    }
}
