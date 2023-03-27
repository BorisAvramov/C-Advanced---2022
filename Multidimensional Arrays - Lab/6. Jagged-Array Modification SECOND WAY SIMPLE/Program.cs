using System;
using System.Linq;

namespace _6._Jagged_Array_Modification_SECOND_WAY_SIMPLE
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = ReadJagged(rows);

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] data = input.Split();
                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);
                int value = int.Parse(data[3]);

                if (row < 0 || col < 0 || row > jagged.Length - 1 && col > jagged[row].Length - 1)
                {
                    Console.WriteLine("Invalid coordinates");

                }
                else
                {
                    if (data[0] == "Add")
                    {

                        jagged[row][col] += value;

                    }
                    else if (data[0] == "Subtract")
                    {
                        jagged[row][col] -= value;

                    }
                }

                input = Console.ReadLine();
            }
            PrintJagged(jagged);

        }

        private static void PrintJagged(int[][] jagged)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jagged[row]));
            }

        }

        private static int[][] ReadJagged(int rows)
        {
            int[][] jagged = new int[rows][];

            for (int row = 0; row < jagged.Length; row++)
            {
                int[] curRowNums =   Console.ReadLine().Split().Select(int.Parse).ToArray();
                jagged[row] = new int[curRowNums.Length];

                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = curRowNums[col];

                }

            }

            return jagged;
        }
    }
}
