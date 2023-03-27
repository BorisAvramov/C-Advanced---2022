using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CodeSnippets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //cr
            Console.ReadLine();
            //crs
            string stringValue = Console.ReadLine();
            //crd
            double doubleValue = double.Parse(Console.ReadLine());
            //cri
            int intValue = int.Parse(Console.ReadLine());
            //crda
            double[] doubleElements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            //cria

            int[] intElements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            //crsa

            string[] stringElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[,] matrix = new string[4, 5];
           
           
            //crqi


            Queue<int> intQueue = new Queue<int>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));
            //crqd


            Queue<double> doubleQueue = new Queue<double>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(double.Parse));

            //crqs

            Queue<string> stringQueue = new Queue<string>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries));
            //crqc

            Queue<char> charQueue = new Queue<char>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(char.Parse));

            Stack<int> intStack = new Stack<int>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));

            Stack<double> doubleStack = new Stack<double>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(double.Parse));

            Stack<string> stringStack = new Stack<string>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries));

            Stack<char> charStack = new Stack<char>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(char.Parse));
            //dict
            Dictionary<string, int> dict = new Dictionary<string, int>();

            //list
            List<string> stringList = new List<string>();


            //sb
            StringBuilder sb = new StringBuilder();


        }
        //mrange
        public static bool IsInRange<T>(T[,] matrix, int row, int col)
        {
            return row >= 0
                && row < matrix.GetLength(0)
                && col >= 0
                && col < matrix.GetLength(1);
        }


        private static bool IsInRange(int row, int col, char[][] jagged)
        {
            return row >= 0 && col >= 0
               && row < jagged.Length && col < jagged[row].Length;

        }


        //rjm


        private static char[][] ReadJagged(char[][] jagged, int r)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                char[] curRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                jagged[row] = new char[curRow.Length];
                for (int col = 0; col < curRow.Length; col++)
                {
                    jagged[row][col] = curRow[col];
                }

            }


            return jagged;
        }

        //pjm
        private static void PrintJagged(char[][] jagged)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col] + " ");
                }
                Console.WriteLine();
            }
        }

        //rmm

        private static char[][] REadMatrix(char[][] matrix, int n)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                string arr = Console.ReadLine();

                matrix[row] = new char[arr.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {

                    matrix[row][col] = arr[col];

                }


            }
            return matrix;
        }

        //pmm
        private static void PrintMAtrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();

            }
        }


        //nextrow
        private static int NextRow(string command, int initialRow)
        {
            if (command == "up")
            {
                return --initialRow;
            }
            if (command == "down")
            {
                return ++initialRow;
            }

            return initialRow;
        }


        private static int NextCol(string command, int initialCol)
        {
            if (command == "right")
            {
                return ++initialCol;
            }
            if (command == "left")
            {
                return --initialCol;
            }
            return initialCol;

        }

        //getcordinates


        private static int[] GetCordinates(string command, int startRowPosition, int startColPosition)
        {
            int[] cordinates = new int[2];
            if (command == "up")
            {
                cordinates[0]--;

            }
            if (command == "down")
            {
                cordinates[0]++;
            }
            if (command == "right")
            {
                cordinates[1]++;
            }
            else
            {
                cordinates[1]--;
            }

            return cordinates;

        }
        




    }
}
