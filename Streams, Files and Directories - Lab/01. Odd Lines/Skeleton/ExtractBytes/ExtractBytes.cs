namespace ExtractBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class ExtractBytes
    {
        static void Main(string[] args)
        {
            string binaryFilePath = @"C:\Users\Dell\source\C# Advanced - януари 2022\Streams, Files and Directories - Lab\01. Odd Lines\Skeleton\ExtractBytes\Files\example.png";
            string bytesFilePath = @"C:\Users\Dell\source\C# Advanced - януари 2022\Streams, Files and Directories - Lab\01. Odd Lines\Skeleton\ExtractBytes\Files\bytes.txt";
            string outputPath = @"C:\Users\Dell\source\C# Advanced - януари 2022\Streams, Files and Directories - Lab\01. Odd Lines\Skeleton\ExtractBytes\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
         {
           using StreamReader reader = new StreamReader(bytesFilePath);

            List<string> byteList = new List<string>();

            string line = reader.ReadLine();
            while (line != null)
            {
                byteList.Add(line);

                line = reader.ReadLine();
            }

            byte[] fileBytes = File.ReadAllBytes(binaryFilePath);
            StringBuilder sb = new StringBuilder();
            foreach (var item in fileBytes)
            {

                if (byteList.Contains(item.ToString()))
                {
                    sb.AppendLine(item.ToString());
                }

            }
           using StreamWriter writer = new StreamWriter(outputPath);

            writer.WriteLine(sb.ToString().Trim());
        }
    }
}
