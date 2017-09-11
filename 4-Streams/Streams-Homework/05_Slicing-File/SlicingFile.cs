namespace _05_Slicing_File
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class SlicingFile
    {
        public static void Main()
        {
            string sourceFile = "../../sheep.jpg";
            string destinationDirectory = "../../FileParts";
            int parts = 5;

            Slice(sourceFile, destinationDirectory, parts);

            List<string> files = new List<string>();

            for (int i = 0; i < parts; i++)
            {
                files.Add(destinationDirectory + $"/Part-{i}.jpg");
            }

            Assemble(files, destinationDirectory);
        }

        public static void Assemble(List<string> files, string destinationDirectory)
        {
            using (FileStream destination = new FileStream(destinationDirectory + "/assembled.jpg", FileMode.Create))
            {
                for (int i = 0; i < files.Count; i++)
                {
                    using (FileStream source = new FileStream(destinationDirectory + $"/Part-{i}.jpg", FileMode.Open))
                    {
                        byte[] buffer = new byte[4096];

                        while (true)
                        {
                            int readBytes = source.Read(buffer, 0, buffer.Length);

                            if (readBytes == 0)
                            {
                                break;
                            }

                            destination.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }

        public static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream source = new FileStream(sourceFile, FileMode.Open))
            {
                int partSize = (int)Math.Ceiling((double)source.Length / parts);
                byte[] buffer = new byte[partSize];
                int count = 0;

                while (true)
                {
                    int readBytes = source.Read(buffer, 0, buffer.Length);

                    if (readBytes == 0)
                    {
                        break;
                    }

                    using (FileStream destination = new FileStream(destinationDirectory + $"/Part-{count}.jpg", FileMode.Create))
                    {
                        destination.Write(buffer, 0, readBytes);
                        count++;
                    }
                }
            }
        }
    }
}
