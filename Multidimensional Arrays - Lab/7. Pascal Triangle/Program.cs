using System;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] jagged = new long[rows][];

            jagged[0] = new long[1] {1};

            for (int row = 1; row < jagged.Length; row++)
            {
                jagged[row] = new long[jagged[row - 1].Length + 1];
                int lenghtCurRow = jagged[row].Length;

                for (int col = 0; col < lenghtCurRow; col++)
                {
                    if (jagged[row - 1].Length > col)
                    {
                        jagged[row][col] += jagged[row - 1][col];

                    }
                    if (col > 0)
                    {
                        jagged[row][col] += jagged[row - 1][col - 1];
                    }



                    //===================================
                   // if (col == 0)
                   // {
                   //     jagged[row][col] = 1;
                   // }
                   // else if (jagged[row].Length > jagged[row - 1].Length && col == lenghtCurRow - 1)
                   // {
                   //     jagged[row][col] = 0 + jagged[row - 1][col - 1];
                   // }
                   //else
                   // {
                   //     jagged[row][col] = jagged[row - 1][col] + jagged[row - 1][col - 1];
                   // }
                   


                }

            }

            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jagged[row]));
            }
        }
    }
}
