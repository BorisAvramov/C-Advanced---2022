using System;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowCols = int.Parse(Console.ReadLine());
            char[,] board = new char[rowCols,rowCols];
            for (int row = 0; row < board.GetLength(0); row++)
            {
                string curRow = Console.ReadLine();
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = curRow[col];

                }
            }

            int removed = 0;
            while (true)
            {
                int maxAttack = 0;
                int knightRow = 0;
                int knightCol = 0;

                for (int row = 0; row < rowCols; row++)
                {
                    for (int col = 0; col < rowCols; col++)
                    {
                        int curAttack = 0;
                        if (board[row, col] == 'K')
                        {
                            //upLeft  upRight
                            if (IsValid(board,row-2, col-1)&& board[row - 2, col - 1] == 'K')
                            {
                                curAttack++;
                            }
                            if (IsValid(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
                            {
                                curAttack++;
                            }

                            //downLeft downRight
                            if (IsValid(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
                            {
                                curAttack++;
                            }
                            if (IsValid(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
                            {
                                curAttack++;
                            }
                            //leftUp leftDown
                            if (IsValid(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
                            {
                                curAttack++;
                            }
                            if (IsValid(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
                            {
                                curAttack++;
                            }
                            //rightUp rightDown
                            if (IsValid(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
                            {
                                curAttack++;
                            }
                            if (IsValid(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
                            {
                                curAttack++;
                            }

                        }
                        if (curAttack > maxAttack)
                        {
                            maxAttack = curAttack;
                            knightRow = row;
                            knightCol = col;
                        }


                    }

                   
                }

                if (maxAttack == 0)
                {
                    break;
                }
                else
                {
                    board[knightRow, knightCol] = '0';
                    removed++;
                }


            }
            Console.WriteLine(removed);
            //for (int row = 0; row < rowCols; row++)
            //{
            //    for (int col = 0; col < rowCols; col++)
            //    {
            //        Console.Write(board[row,col]);
            //    }
            //    Console.WriteLine();
            //}

        }

        private static bool IsValid(char[,] board, int row, int col)
        {
            return row >= 0 && col >= 0 && row < board.GetLength(0) && col < board.GetLength(1);

        }
    }
}
