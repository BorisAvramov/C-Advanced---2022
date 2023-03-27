namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"C:\Users\Dell\source\C# Advanced - януари 2022\Streams, Files and Directories - Lab\01. Odd Lines\Skeleton\LineNumbers\Files\input.txt";
            string outputPath = @"C:\Users\Dell\source\C# Advanced - януари 2022\Streams, Files and Directories - Lab\01. Odd Lines\Skeleton\LineNumbers\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);
            using (reader)
            {
                string line = reader.ReadLine();

                using (writer)
                {
                    int counter = 1;

                    while (line != null)
                    {
                       
                        writer.WriteLine($"{counter}. {line}");

                        counter++;

                        line = reader.ReadLine();
                    }

                }


                

            }


        }
    }
}
