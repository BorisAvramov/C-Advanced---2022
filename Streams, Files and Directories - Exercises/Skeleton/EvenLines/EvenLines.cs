namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
          using  StreamReader reader = new StreamReader(inputFilePath);
            StringBuilder sb = new StringBuilder();
            int counter = 0;

            while (true)
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }
                if (counter % 2 == 0)
                {
                    line = ReplaceSymbols(line);
                    line = ReverseWords(line);

                    sb.AppendLine(line);
                    
                }
                counter++;
            
                

            }

            return sb.ToString();

        }
        private static string ReverseWords(string line)
        {
            string[] lineArray = line.Split();
            line = string.Join(" ", lineArray.Reverse());
            return line;

        }

        private static string ReplaceSymbols(string line)
        {
            char[] symbols = new char[] { '-', ',', '.', '!', '?' };
            foreach (var item in line)
            {
                if (symbols.Contains((char)item))
                {
                    line = line.Replace((char)item, '@');
                }
            }
            return line;
        }
    }

}
