using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\copyMe.png";
            string outputPath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputPath, outputPath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using FileStream fielStream = new FileStream(inputFilePath, FileMode.Open);
            using FileStream newfielStream = new FileStream(outputFilePath, FileMode.Create);

            byte[] bytes = new byte[256];

            while (true)
            {

                int currentBytes = fielStream.Read(bytes, 0, bytes.Length);
                if (currentBytes == 0)
                {
                    break;
                }
                newfielStream.Write(bytes, 0, bytes.Length);
            }
            



        }
    }
}
