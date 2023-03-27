namespace MergeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class MergeFiles
    {
        static void Main(string[] args)
        {
            var firstInputFilePath = @"C:\Users\Dell\source\C# Advanced - януари 2022\Streams, Files and Directories - Lab\01. Odd Lines\Skeleton\MergeFiles\Files\input1.txt";
            var secondInputFilePath = @"C:\Users\Dell\source\C# Advanced - януари 2022\Streams, Files and Directories - Lab\01. Odd Lines\Skeleton\MergeFiles\Files\input2.txt";
            var outputFilePath = @"C:\Users\Dell\source\C# Advanced - януари 2022\Streams, Files and Directories - Lab\01. Odd Lines\Skeleton\MergeFiles\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            StreamReader readerFkrst = new StreamReader(firstInputFilePath);
           StreamReader readerSecond = new StreamReader(secondInputFilePath);

            List<string> firsList = new List<string>();
            List<string> secondList = new List<string>();

            using (readerFkrst)
            {
                while (!readerFkrst.EndOfStream)
                {
                    firsList.Add(readerFkrst.ReadLine());

                }

            }
            using (readerSecond)
            {
                while (!readerSecond.EndOfStream)
                {
                    secondList.Add(readerSecond.ReadLine());

                }

            }

            StringBuilder sb = new StringBuilder();

            int smallLenght = Math.Min(firsList.Count, secondList.Count);
            List<string> maxList = new List<string>();
            if (firsList.Count > secondList.Count)
            {
                maxList = firsList;
            }
            else
            {
                maxList = secondList;
            }
            for (int i = 0; i < smallLenght; i++)
            {
                sb.AppendLine(firsList[i]);
                sb.AppendLine(secondList[i]);
            }
            if (firsList.Count != secondList.Count)
            {
                for (int i = smallLenght; i < maxList.Count; i++)
                {
                    sb.AppendLine(maxList[i]);
                }
            }
            StreamWriter writer = new StreamWriter(outputFilePath);

            using (writer)
            {
                writer.WriteLine(sb.ToString().Trim());


            }

        }
    }
}
