using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = rowsCols[0];
            int cols = rowsCols[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] curRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();


                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = curRow[col];
                }
            }

            string input = Console.ReadLine();
            bool isValid = false;
            while (input != "END")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
               
                if (data[0] == "swap" && data.Length == 5)
                {
                    isValid = true;
                    int row1 = int.Parse(data[1]);
                    int col1 = int.Parse(data[2]);
                    int row2 = int.Parse(data[3]);
                    int col2 = int.Parse(data[4]);
                    if (row1 >= 0 && row2 >= 0 && col1 >= 0 && col2 >= 0
                        && row1 < matrix.GetLength(0) && row2 < matrix.GetLength(0)
                        && col1 < matrix.GetLength(1) && col2 < matrix.GetLength(1))
                    {
                        string temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write(matrix[row, col] + " ");

                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        isValid = false;
                        
                    }

                }
                if (!isValid)
                {
                    Console.WriteLine("Invalid input!");
                }  
                
                
                input = Console.ReadLine();
            }


        }
    }
}
