namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            StringBuilder sb = new StringBuilder();
            int counter = 1;
            foreach (var item in lines)
            {
                int countLett = item.Count(char.IsLetter);
                int countPunct = item.Count(char.IsPunctuation);

                sb.AppendLine($"Line {counter}: {item} ({countLett})({countPunct})");
                counter++;
            }

            File.WriteAllText(outputFilePath, sb.ToString().TrimEnd());
        }
    }
}
