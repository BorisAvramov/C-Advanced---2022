using System;
using System.Linq;

namespace _02._Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowCol = 8;

            char[,] matrix = new char[rowCol,rowCol];

            matrix = ReadMatrix(matrix, rowCol);

            int wRow = 0;
            int wCol = 0;

            int bRow = 0;
            int bCol = 0;


            for (int row = 0; row < rowCol; row++)
            {
                for (int col = 0; col < rowCol; col++)
                {
                    if (matrix[row,col] == 'w')
                    {
                        wRow = row;
                        wCol = col;
                    }
                    if (matrix[row,col] == 'b')
                    {
                        bRow = row;
                        bCol = col;
                    }

                }
            }   


            while (true)
            {



                if (IsInRange(matrix, wRow - 1, wCol - 1) && matrix[wRow - 1, wCol - 1] == 'b' )
                {

                    string cordinates = GetCordinate(wRow - 1, wCol - 1);
                    Console.WriteLine($"Game over! White capture on {cordinates}.");

                 
                    break;

                }
                if (IsInRange(matrix, wRow - 1, wCol + 1) && matrix[wRow - 1, wCol + 1] == 'b' )
                {

                    string cordinates = GetCordinate(wRow - 1, wCol + 1);
                    Console.WriteLine($"Game over! White capture on {cordinates}.");

               
                    break;

                }
               
                if (wRow - 1 == 0)
                {


                    string coordinates = GetCordinate(wRow - 1, wCol);
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {coordinates}.");
                  
                    break;

                }
                matrix[wRow - 1, wCol] = 'w';
                matrix[wRow, wCol] = '-';
                wRow -= 1;


                if (IsInRange(matrix, bRow - 1, bCol - 1) && matrix[bRow - 1, bCol - 1] == 'w' )
                {

                    string cordinates = GetCordinate(bRow - 1, bCol - 1);
                    Console.WriteLine($"Game over! Black capture on {cordinates}.");

                
                    break;

                }
                if (IsInRange(matrix, bRow - 1, bCol + 1) && matrix[bRow - 1, bCol + 1] == 'w'  )
                {

                    string cordinates = GetCordinate(bRow - 1, bCol + 1);
                    Console.WriteLine($"Game over! Black capture on {cordinates}.");

                  
                    break;

                }
                if (IsInRange(matrix, bRow + 1, bCol - 1) && matrix[bRow + 1, bCol - 1] == 'w'  )
                {

                    string cordinates = GetCordinate(bRow + 1, bCol - 1);
                    Console.WriteLine($"Game over! Black capture on {cordinates}.");

                
                    break;

                }
                if (IsInRange(matrix, bRow + 1, bCol + 1) &&  matrix[bRow + 1, bCol + 1] == 'w' )
                {

                    string cordinates = GetCordinate(bRow + 1, bCol + 1);
                    Console.WriteLine($"Game over! Black capture on {cordinates}.");

                  
                    break;

                }

                
                if (bRow + 1 == 7)
                {
                    string coordinates = GetCordinate(bRow + 1, bCol);
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {coordinates}.");
                
                    break;

                }


               
                matrix[bRow + 1, bCol] = 'b';

                
                matrix[bRow, bCol] = '-';

                
                bRow += 1;

            }

        }

        private static bool IsInRange(char[,] matrix ,int row, int col)
        {

            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);

            
        }

        private static string GetCordinate(int row, int col)
        {
            string rowChess = "87654321";
            string colChess = "abcdefgh";
            

            string cordinates = "";

            cordinates += colChess[col];
            cordinates += rowChess[row];

            return cordinates;

           


            throw new NotImplementedException();
        }

        private static char[,] ReadMatrix(char[,] matrix, int rowCol)
        {

            for (int Row = 0; Row < rowCol ; Row++)
            {
                string arr = Console.ReadLine();

                for (int col = 0; col < rowCol; col++)
                {
                    matrix[Row, col] = arr[col];

                }
            }


            return matrix;
        }
    }
}
