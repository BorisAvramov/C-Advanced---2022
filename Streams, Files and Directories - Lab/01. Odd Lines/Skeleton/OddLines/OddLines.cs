
namespace OddLines
{
    using System;
    using System.IO;
    public class OddLines
    {
        static void Main()
        {
            string inputPath = @"C:\Users\Dell\source\C# Advanced - януари 2022\Streams, Files and Directories - Lab\01. Odd Lines\Skeleton\OddLines\Files\input.txt";
            string outputPath = @"C:\Users\Dell\source\C# Advanced - януари 2022\Streams, Files and Directories - Lab\01. Odd Lines\Skeleton\OddLines\Files\output.txt";

            ExtractOddLines(inputPath, outputPath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);

            using (reader)
            {
                string line = reader.ReadLine();
                int counter = 0;
                using (writer)
                {
                    while (line != null)
                    {
                        if (counter % 2 == 1)
                        {

                            writer.WriteLine(line);


                        }
                        counter++;

                        line = reader.ReadLine();
                    }
                }


            }
        }
    }
}
