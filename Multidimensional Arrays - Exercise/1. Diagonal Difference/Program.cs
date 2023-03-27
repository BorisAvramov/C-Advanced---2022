using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rowsCols, rowsCols];

            for (int row = 0; row < rowsCols; row++)
            {
                int[] curRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < rowsCols; col++)
                {
                    matrix[row, col] = curRow[col];
                }
            }

            int sumPrimeDiag = 0;
            int sumSecDiag = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                sumPrimeDiag += matrix[i, i];
                sumSecDiag += matrix[i, matrix.GetLength(1) - 1 - i];

            }

          //  int sumPrimeDiag = 0;
          //  int sumSecDiag = 0;

          //  int curRowIndex = -1;
          //for (int col = 0; col < matrix.GetLength(1); col++)
          //{
          //      curRowIndex++;
          //      sumPrimeDiag += matrix[curRowIndex, col];
                
          //}
          //  curRowIndex = -1;
          //  for (int col = rowsCols - 1; col >= 0; col--)
          //  {
          //      curRowIndex++;
          //      sumSecDiag += matrix[curRowIndex, col];

          //  }

            int diffrence = Math.Abs(sumPrimeDiag - sumSecDiag);
            Console.WriteLine(diffrence);
        }
    }
}
