namespace _08_Full_Directory_Traversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class FullDirectoryTraversal
    {
        public static void Main()
        {
            string directoryPath = Console.ReadLine();

            Dictionary<string, Dictionary<string, long>> filesByExtensions = TraverseDirectory(directoryPath);
            Dictionary<string, Dictionary<string, long>> filesFromCurrentDirectory = 
                new Dictionary<string, Dictionary<string, long>>();

            string[] subDirectories = Directory.GetDirectories(directoryPath);

            foreach (var subDirectory in subDirectories)
            {
                filesFromCurrentDirectory = TraverseDirectory(subDirectory);
                AddNewFilesToMainDictionary(filesByExtensions, filesFromCurrentDirectory);
            }

            while (subDirectories.Length != 0)
            {
                foreach (var subDir in subDirectories)
                {
                    subDirectories = Directory.GetDirectories(subDir);

                    foreach (var subDirectory in subDirectories)
                    {
                        filesFromCurrentDirectory = TraverseDirectory(subDirectory);
                        AddNewFilesToMainDictionary(filesByExtensions, filesFromCurrentDirectory);
                    }
                }
            }

            WriteFilesInfoToFile(filesByExtensions);
        }

        public static void AddNewFilesToMainDictionary(Dictionary<string, Dictionary<string, long>> filesByExtensions, Dictionary<string, Dictionary<string, long>> filesFromCurrentDirectory)
        {
            foreach (var extension in filesFromCurrentDirectory)
            {
                if (!filesByExtensions.ContainsKey(extension.Key))
                {
                    filesByExtensions.Add(extension.Key, new Dictionary<string, long>());
                }

                foreach (var file in extension.Value)
                {
                    if (!filesByExtensions[extension.Key].ContainsKey(file.Key))
                    {
                        filesByExtensions[extension.Key].Add(file.Key, 0);
                    }

                    filesByExtensions[extension.Key][file.Key] = file.Value;
                }
            }
        }

        public static Dictionary<string, Dictionary<string, long>> TraverseDirectory(string directoryPath)
        {
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

            return filesByExtensions;
        }

        public static void WriteFilesInfoToFile(Dictionary<string, Dictionary<string, long>> filesByExtensions)
        {
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
