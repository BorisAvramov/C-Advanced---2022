namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordPath = @"C:\Users\Dell\source\C# Advanced - януари 2022\Streams, Files and Directories - Lab\01. Odd Lines\Skeleton\WordCount\Files\words.txt";
            string textPath = @"C:\Users\Dell\source\C# Advanced - януари 2022\Streams, Files and Directories - Lab\01. Odd Lines\Skeleton\WordCount\Files\text.txt";
            string outputPath = @"C:\Users\Dell\source\C# Advanced - януари 2022\Streams, Files and Directories - Lab\01. Odd Lines\Skeleton\WordCount\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            List<string> words = new List<string>();

            StreamReader readreWords = new StreamReader(wordsFilePath);
            using (readreWords)
            {
                string[] data = readreWords.ReadLine().Split();
                for (int i = 0; i < data.Length; i++)
                {
                    words.Add(data[i].ToLower());
                }


            }
            StreamReader texteReader = new StreamReader(textFilePath);
            List<string> textWords = new List<string>();
            using (texteReader)
            {
                string input = texteReader.ReadLine();
                char[] slits = {' ', ',','.','!','?','-'};
                while (input != null)
                {

                    string[] data = input.Split(slits,StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in data)
                    {
                        textWords.Add(item.ToLower());
                    }

                    input = texteReader.ReadLine();

                }


            }
            StreamWriter writer = new StreamWriter(outputFilePath);

            Dictionary<string, int> dict = new Dictionary<string, int>();
                for (int i = 0; i < words.Count; i++)
                {
                dict.Add(words[i], 0);
                    for (int j = 0; j < textWords.Count; j++)
                    {
                        if (words[i] == textWords[j])
                        {
                        dict[words[i]]++;

                        }

                    }
                    
                }
            using (writer)
            {
                foreach (var item in dict.OrderByDescending(i=>i.Value))
                {
                    writer.WriteLine($"{item.Key} - {item.Value}");
                }
                

            }
            
        }
    }
}
