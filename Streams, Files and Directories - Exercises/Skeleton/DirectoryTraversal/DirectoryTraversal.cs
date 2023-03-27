namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        public static object StrigBuilder { get; private set; }

        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {

            string[] filesPath = Directory.GetFiles(inputFolderPath, "*");
            Dictionary<string, Dictionary<string, double>> filesInfo = new Dictionary<string, Dictionary<string, double>>();
            StringBuilder sb = new StringBuilder();
            foreach (var file in filesPath)
            {
                FileInfo fileInfo = new FileInfo(file);
                string extensine = fileInfo.Extension;
                string fileName = fileInfo.FullName;
                double size = fileInfo.Length / 1024.0;

                if (filesInfo.ContainsKey(extensine) == false)
                {
                    filesInfo.Add(extensine, new Dictionary<string, double>());
                }

                filesInfo[extensine].Add(fileName, size);
                
            }
            foreach (var item in filesInfo.OrderByDescending(i=>i.Value.Count).ThenBy(i=>i.Key))
            {
                sb.AppendLine(item.Key);
                foreach (var file in item.Value.OrderBy(f=>f.Value))
                {
                    sb.AppendLine($"--{file.Key} - {file.Value:f3}kb");
                }

            }

           
            return sb.ToString().TrimEnd();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            File.WriteAllText(desktopPath, textContent);
        }

    }
}
