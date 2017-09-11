namespace _04_Copy_Binary_File
{
    using System.IO;

    public class CopyBinaryFile
    {
        public static void Main()
        {
            using (FileStream source = new FileStream("../../sheep.jpg", FileMode.Open))
            {
                using (FileStream destination = new FileStream("../../result.jpg", FileMode.Create))
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
}
