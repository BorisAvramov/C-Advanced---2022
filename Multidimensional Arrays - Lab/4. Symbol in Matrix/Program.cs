using System;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCols = int.Parse(Console.ReadLine());

            char[,] charMatrix = new char[rowsCols, rowsCols];

            for (int row = 0; row < rowsCols; row++)
            {
                char[] curRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < rowsCols; col++)
                {
                    charMatrix[row, col] = curRow[col];
                }

            }

            char occurChar = char.Parse(Console.ReadLine());
            bool charOccured = false;
            int indexRow = 0;
            int indexCol = 0;

            for (int row = 0; row < rowsCols; row++)
            {
                for (int col = 0; col < rowsCols; col++)
                {
                    if (charMatrix[row, col] == occurChar)
                    {
                        charOccured = true;
                        indexRow = row;
                        indexCol = col;
                        break;
                    }

                }
                if (charOccured)
                {
                    break;
                }

            }
            if (charOccured)
            {
                Console.WriteLine($"({indexRow}, {indexCol})");
            }
            else
            {
                Console.WriteLine($"{occurChar} does not occur in the matrix ");
            }



        }
    }
}
