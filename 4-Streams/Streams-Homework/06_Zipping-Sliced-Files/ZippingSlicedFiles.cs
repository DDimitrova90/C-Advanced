namespace _06_Zipping_Sliced_Files
{
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;

    public class ZippingSlicedFiles
    {
        public static void Main()
        {
            string sourceFile = "../../sheep.jpg";
            string destinationDirectory = "../../FileParts";
            int parts = 5;

            SliceAndCompress(sourceFile, destinationDirectory, parts);

            List<string> files = new List<string>(); 

            for (int i = 0; i < parts; i++)
            {
                files.Add(destinationDirectory + $"/Part-{i}.jpg");
            }

            DecompressAndAssemble(files, destinationDirectory);
        }

        public static void DecompressAndAssemble(List<string> files, string destinationDirectory)
        {
            using (FileStream destination = new FileStream(destinationDirectory + "/assembled.jpg", FileMode.Create))
            {
                for (int i = 0; i < files.Count; i++)
                {
                    using (FileStream source = new FileStream(destinationDirectory + $"/Part-{i}.gz", FileMode.Open))
                    {
                        using (GZipStream decompress = new GZipStream(source, CompressionMode.Decompress, false))
                        {
                            byte[] buffer = new byte[4096];

                            while (true)
                            {
                                int readBytes = decompress.Read(buffer, 0, buffer.Length);

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
        }

        public static void SliceAndCompress(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream source = new FileStream(sourceFile, FileMode.Open))
            {
                int partSize = (int)source.Length / parts;
                byte[] buffer = new byte[partSize];
                int count = 0;

                while (true)
                {
                    int readBytes = source.Read(buffer, 0, buffer.Length);

                    if (readBytes == 0 || readBytes != partSize)
                    {
                        break;
                    }

                    using (FileStream destination = new FileStream(destinationDirectory + $"/Part-{count}.gz", FileMode.Create))
                    {
                        using (GZipStream compression = new GZipStream(destination, CompressionMode.Compress, false))
                        {
                            compression.Write(buffer, 0, readBytes);
                            count++;
                        }
                    }
                }
            }
        }
    }
}
