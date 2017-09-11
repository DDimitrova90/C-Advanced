namespace _07_Directory_Traversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        public static void Main()
        {
            string directoryPath = Console.ReadLine();

            string[] files = Directory.GetFiles(directoryPath);
            Dictionary<string, Dictionary<string, long>> filesByExtensions = 
                new Dictionary<string, Dictionary<string, long>>();

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;
                string fileName = fileInfo.Name;

                if (!filesByExtensions.ContainsKey(extension))
                {
                    filesByExtensions.Add(extension, new Dictionary<string, long>());
                }

                if (!filesByExtensions[extension].ContainsKey(fileName))
                {
                    filesByExtensions[extension].Add(fileName, 0);
                }

                filesByExtensions[extension][fileName] = fileInfo.Length / 1000;
            }

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            using (FileStream fileStream = new FileStream(desktopPath + "\\report.txt", FileMode.Create))
            {
                var orderedExtentions = filesByExtensions
                    .OrderByDescending(e => e.Value.Count()).ThenBy(e => e.Key);

                foreach (var extention in orderedExtentions)
                {
                    byte[] buffer = Encoding.ASCII.GetBytes(extention.Key + Environment.NewLine);
                    fileStream.Write(buffer, 0, buffer.Length);

                    foreach (var file in extention.Value.OrderBy(f => f.Value))
                    {
                        string line = $"--{file.Key} - {file.Value}kb" + Environment.NewLine;
                        buffer = Encoding.ASCII.GetBytes(line);
                        fileStream.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
