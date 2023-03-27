namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"C:\Users\Dell\source\C# Advanced - януари 2022\Streams, Files and Directories - Lab\01. Odd Lines\Skeleton\SplitMergeBinaryFile\Files\example.png";
            string joinedFilePath = @"C:\Users\Dell\source\C# Advanced - януари 2022\Streams, Files and Directories - Lab\01. Odd Lines\Skeleton\SplitMergeBinaryFile\Files\example-joined.png";
            string partOnePath = @"C:\Users\Dell\source\C# Advanced - януари 2022\Streams, Files and Directories - Lab\01. Odd Lines\Skeleton\SplitMergeBinaryFile\Files\part-1.bin";
            string partTwoPath = @"C:\Users\Dell\source\C# Advanced - януари 2022\Streams, Files and Directories - Lab\01. Odd Lines\Skeleton\SplitMergeBinaryFile\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            FileStream fileStream = new FileStream(sourceFilePath,FileMode.Open);
            using (fileStream)
            {
                int fileLenght = (int)fileStream.Length / 2;
                
                    FileStream partOneFileStream = new FileStream(partOneFilePath, FileMode.Create);
                    using (partOneFileStream)
                    {
                        byte[] data = new byte[fileLenght];
                        fileStream.Read(data, 0, fileLenght);
                        partOneFileStream.Write(data, 0, fileLenght);
                    }
                FileStream partTwoFileStream = new FileStream(partTwoFilePath, FileMode.Create);
                using (partTwoFileStream)
                {
                    byte[] data = new byte[fileLenght];
                    fileStream.Read(data, 0, fileLenght);
                    partTwoFileStream.Write(data, 0, fileLenght);
                }
                
            }
            
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            StreamWriter result = new StreamWriter(joinedFilePath);

            using (result)
            {
               using StreamReader partOne = new StreamReader(partOneFilePath);
                using StreamReader partTwo = new StreamReader(partTwoFilePath);
                string line = partOne.ReadLine();
                while (line != null)
                {
                    result.WriteLine(line);

                    line = partOne.ReadLine();
                }
                string line2 = partTwo.ReadLine();
                while (line2 != null)
                {
                    result.WriteLine(line2);
                    line2 = partTwo.ReadLine();
                }


            }

        }
    }
}