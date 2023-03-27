using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int rowCol = int.Parse(Console.ReadLine());


            char[,] matrix = new char[rowCol,rowCol];

            
            string input = Console.ReadLine();

            matrix = ReadMatrix(matrix, rowCol);

            string[] attackCordinates = input.Split(',', StringSplitOptions.RemoveEmptyEntries);

            int totalShipsDestroyed = 0;

            int countOfShipsFirstPlayer = 0;
            int countOfShipsSecondPlayer = 0;

            bool playerFirstWin = false;
            bool playerSecondWin = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == '<')
                    {
                        countOfShipsFirstPlayer++;
                    }
                    if (matrix[row, col] == '>')
                    {
                        countOfShipsSecondPlayer++;
                    }


                }

            }

            for (int i = 0; i < attackCordinates.Length; i++)
            {
                int[] curAttackCord = attackCordinates[i].Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (!IsInRange( matrix, curAttackCord[0],  curAttackCord[1]))
                {

                    continue;

                }



                if (matrix[curAttackCord[0], curAttackCord[1]] == '#')
                {
                    matrix[curAttackCord[0], curAttackCord[1]] = 'X';
                    int row = curAttackCord[0];
                    int col = curAttackCord[1];

                    if (IsInRange(matrix, row, col + 1))
                    {
                        if (matrix[row, col + 1] == '<')
                        {
                            countOfShipsFirstPlayer--;
                            totalShipsDestroyed++;
                            matrix[row, col + 1] = 'X';
                        }
                        if (matrix[row, col + 1] == '>')
                        {
                            countOfShipsSecondPlayer--;
                            totalShipsDestroyed++;
                            matrix[row, col + 1] = 'X';
                        }

                    }
                    if (IsInRange(matrix, row, col - 1))
                    {
                        if (matrix[row, col - 1] == '<')
                        {
                            countOfShipsFirstPlayer--;
                            totalShipsDestroyed++;
                            matrix[row, col - 1] = 'X';
                        }
                        if (matrix[row, col - 1] == '>')
                        {
                            countOfShipsSecondPlayer--;
                            totalShipsDestroyed++;
                            matrix[row, col - 1] = 'X';
                        }

                    }
                    if (IsInRange(matrix, row + 1, col))
                    {
                        if (matrix[row + 1, col] == '<')
                        {
                            countOfShipsFirstPlayer--;
                            totalShipsDestroyed++;
                            matrix[row + 1, col] = 'X';
                        }
                        if (matrix[row + 1, col] == '>')
                        {
                            countOfShipsSecondPlayer--;
                            totalShipsDestroyed++;
                            matrix[row + 1, col] = 'X';
                        }

                    }
                    if (IsInRange(matrix, row - 1, col))
                    {
                        if (matrix[row - 1, col] == '<')
                        {
                            countOfShipsFirstPlayer--;
                            totalShipsDestroyed++;
                            matrix[row - 1, col] = 'X';
                        }
                        if (matrix[row - 1, col] == '>')
                        {
                            countOfShipsSecondPlayer--;
                            totalShipsDestroyed++;
                            matrix[row - 1, col] = 'X';
                        }

                    }
                    if (IsInRange(matrix, row + 1, col + 1))
                    {
                        if (matrix[row + 1, col + 1] == '<')
                        {
                            countOfShipsFirstPlayer--;
                            totalShipsDestroyed++;
                            matrix[row + 1, col + 1] = 'X';
                        }
                        if (matrix[row + 1, col + 1] == '>')
                        {
                            countOfShipsSecondPlayer--;
                            totalShipsDestroyed++;
                            matrix[row + 1, col + 1] = 'X';
                        }

                    }
                    if (IsInRange(matrix, row - 1, col - 1))
                    {
                        if (matrix[row - 1, col - 1] == '<')
                        {
                            countOfShipsFirstPlayer--;
                            totalShipsDestroyed++;
                            matrix[row - 1, col - 1] = 'X';
                        }
                        if (matrix[row - 1, col - 1] == '>')
                        {
                            countOfShipsSecondPlayer--;
                            totalShipsDestroyed++;
                            matrix[row - 1, col - 1] = 'X';
                        }

                    }
                    if (IsInRange(matrix, row - 1, col + 1))
                    {
                        if (matrix[row - 1, col + 1] == '<')
                        {
                            countOfShipsFirstPlayer--;
                            totalShipsDestroyed++;
                            matrix[row - 1, col + 1] = 'X';
                        }
                        if (matrix[row - 1, col + 1] == '>')
                        {
                            countOfShipsSecondPlayer--;
                            totalShipsDestroyed++;
                            matrix[row - 1, col + 1] = 'X';
                        }

                    }
                    if (IsInRange(matrix, row + 1, col - 1))
                    {
                        if (matrix[row + 1, col - 1] == '<')
                        {
                            countOfShipsFirstPlayer--;
                            totalShipsDestroyed++;
                            matrix[row + 1, col - 1] = 'X';
                        }
                        if (matrix[row + 1, col - 1] == '>')
                        {
                            countOfShipsSecondPlayer--;
                            totalShipsDestroyed++;
                            matrix[row + 1, col - 1] = 'X';
                        }

                    }


                }
                if (matrix[curAttackCord[0], curAttackCord[1]] == '>')
                {
                    countOfShipsSecondPlayer--;
                    totalShipsDestroyed++;
                    matrix[curAttackCord[0], curAttackCord[1]] = 'X';


                }
                if (matrix[curAttackCord[0], curAttackCord[1]] == '<')
                {
                    countOfShipsFirstPlayer--;
                    totalShipsDestroyed++;
                    matrix[curAttackCord[0], curAttackCord[1]] = 'X';
                }

                if (countOfShipsFirstPlayer <= 0)
                {
                    playerSecondWin = true;
                    break;
                }


                if (countOfShipsSecondPlayer <= 0)
                {
                    playerFirstWin = true;
                    break;
                }
             


            }

            if (playerFirstWin)
            {
                Console.WriteLine($"Player One has won the game! {totalShipsDestroyed} ships have been sunk in the battle.");
            }
            else if (playerSecondWin)
            {
                Console.WriteLine($"Player Two has won the game! {totalShipsDestroyed} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {countOfShipsFirstPlayer} ships left. Player Two has {countOfShipsSecondPlayer} ships left.");
            }



        }

 
        public static bool IsInRange(char[,] matrix, int row, int col)
        {
            return row >= 0
                && row < matrix.GetLength(0)
                && col >= 0
                && col < matrix.GetLength(1);
        }

        private static char[,] ReadMatrix(char[,] matrix, int rowCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] charArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();


                for (int col = 0; col < charArr.Length; col++)
                {
                    matrix[row, col] = charArr[col];
                }

            }

            return matrix;
        }


     
    }
    
}
