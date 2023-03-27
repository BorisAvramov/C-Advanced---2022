using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Truffle_Hunter
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            int row = sizeMatrix;
            int col = sizeMatrix;

            char[,] matrixChar = new char[row, col];

            matrixChar = ReadMatrix(row, col);

            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict.Add('B', 0);
            dict.Add('S', 0);
            dict.Add('W', 0);

            int eaten = 0;


            string input = Console.ReadLine();
            while (input != "Stop the hunt")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int rowCom = int.Parse(data[1]);
                int colCom = int.Parse(data[2]);
                char curPos = matrixChar[rowCom, colCom];
                if (input.StartsWith("Collect"))
                {
                    if (curPos !=  '-')
                    {
                        dict[curPos]++;
                        matrixChar[rowCom, colCom] = '-';
                    }

                }
                if (input.StartsWith("Wild_Boar"))
                {
                    string direction = data[3];


                    if (direction == "up")
                    {
                        for (int rowBoard = rowCom; rowBoard >= 0; rowBoard-=2)
                        {
                            if (matrixChar[rowBoard, colCom] != '-')
                            {
                                eaten++;
                                matrixChar[rowBoard, colCom] = '-';
                            }
                        }
                    }
                    if (direction == "right")
                    {
                        for (int coBoard = colCom; coBoard < matrixChar.GetLength(1); coBoard+=2)
                        {
                            if (matrixChar[rowCom, coBoard] != '-')
                            {
                                eaten++;
                                matrixChar[rowCom, coBoard] = '-';
                            }
                        }


                    }
                    if (direction == "down")
                    {
                        for (int rowBoard = rowCom; rowBoard < matrixChar.GetLength(0); rowBoard += 2)
                        {
                            if (matrixChar[rowBoard, colCom] != '-')
                            {
                                eaten++;
                                matrixChar[rowBoard, colCom] = '-';
                            }
                        }

                    }
                    if (direction == "left")
                    {
                        for (int coBoard = colCom; coBoard >= 0; coBoard -= 2)
                        {
                            if (matrixChar[rowCom, coBoard] != '-')
                            {
                                eaten++;
                                matrixChar[rowCom, coBoard] = '-';
                            }
                        }
                    }
                }



                input = Console.ReadLine();
            }
            Console.WriteLine($"Peter manages to harvest {dict['B']} black, {dict['S']} summer, and {dict['W']} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eaten} truffles.");

            for (int i = 0; i < matrixChar.GetLength(0); i++)
            {
                for (int j = 0; j < matrixChar.GetLength(1); j++)
                {
                    Console.Write(matrixChar[i, j] + " ");
                }
                Console.WriteLine();

            }

            //int count = 1;
            //foreach (var item in matrixChar)
            //{
            //    Console.Write(item + " ");
            //    if (count % sizeMatrix == 0 )
            //    {
            //        Console.WriteLine();
            //    }
            //    count++;
            //}
        }

        

        private static char[,] ReadMatrix(int rowLenght, int colLenght)
        {
            char[,] matrix = new char[rowLenght, colLenght];
            for (int row = 0; row < rowLenght; row++)
            {
                char[] curColElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < colLenght; col++)
                {

                    matrix[row, col] = curColElements[col];
                }
            }

            return matrix;
        }
    }
}
