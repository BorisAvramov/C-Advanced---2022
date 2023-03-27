using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rows][];

            for (int row = 0; row < jagged.Length; row++)
            {
                int[] curRowNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jagged[row] = new int[curRowNums.Length];

                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = curRowNums[col]; 

                }
            }
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] data = input.Split();
                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);
                int value = int.Parse(data[3]);

                
                if (row >= 0 && row < jagged.Length && col >= 0)
                {
                    bool valid = true;
                    for (int curRow = 0; curRow < jagged.Length; curRow++)
                    {
                        int curRowLenght = jagged[curRow].Length;

                            if (col > curRowLenght - 1)
                            {
                            valid = false;
                            break;
                            }
                        
                    }
                    if (!valid)
                    {
                        Console.WriteLine("Invalid coordinates");
                        break;
                    }
                    if (input.StartsWith("Add"))
                    {

                        jagged[row][col] += value;

                    }
                    else if (input.StartsWith("Subtract"))
                    {
                        jagged[row][col] -= value;

                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
                

                input = Console.ReadLine();

            }


            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jagged[row]));
            }


            //===============================================

            //for (int row = 0; row < jagged.Length; row++)
            //{
            //    for (int col = 0; col < jagged[row].Length; col++)
            //    {
            //        Console.Write(jagged[row][col] + " ");
            //    }
            //    Console.WriteLine();

            //}


            //=====================================================
            //foreach (var item in jagged)
            //{

            //    Console.WriteLine(string.Join(" ", item));


            //}


        }
    }
}
