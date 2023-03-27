using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jagged = new double[rows][];

            for (int row = 0; row < jagged.Length; row++)
            {
                int[] curRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jagged[row] = new double[curRow.Length];

                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = curRow[col];


                }
            }

            for (int row = 0; row < jagged.Length - 1; row++)
            {
                
                    if (jagged[row].Length == jagged[row+1].Length)
                    {
                    
                             for (int curRow = row; curRow < row + 2; curRow++)
                             {
                                    for (int curCol = 0; curCol < jagged[curRow].Length; curCol++)
                                    {
                                                jagged[curRow][curCol] *= 2;
                                    }
                             }

                    }
                    else
                    {
                        for (int curRow = row; curRow < row + 2; curRow++)
                        {
                            for (int curCol = 0; curCol < jagged[curRow].Length; curCol++)
                            {
                                jagged[curRow][curCol] /= 2;
                            }
                        }
                    }
                
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);
                int value = int.Parse(data[3]);
                
                if (row >= 0  && row < jagged.Length)
                {
                    if (col >= 0 && col < jagged[row].Length)
                    {
                        if (command == "Add")
                        {
                            jagged[row][col] += value;
                        }
                        else if (command == "Subtract")
                        {
                            jagged[row][col] -= value;
                        }

                    }


                }


                input = Console.ReadLine();
            }



            foreach (var item in jagged)
            {
                Console.WriteLine(string.Join(" ", item));
            }

        }
    }
}
