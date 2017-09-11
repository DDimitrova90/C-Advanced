namespace _03_Word_Count
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordCount
    {
        public static void Main()
        {
            Dictionary<string, int> words = new Dictionary<string, int>();

            using (StreamReader wordsReader = new StreamReader("../../words.txt"))
            {
                string currWord = wordsReader.ReadLine();

                while (currWord != null)
                {
                    using (StreamReader textReader = new StreamReader("../../text.txt"))
                    {
                        string line = textReader.ReadLine();

                        while (line != null)
                        {
                            if (line.ToLower().Contains(currWord.ToLower()))
                            {
                                if (!words.ContainsKey(currWord))
                                {
                                    words.Add(currWord, 0);
                                }

                                words[currWord] += 1;
                            }

                            line = textReader.ReadLine();
                        }

                        currWord = wordsReader.ReadLine();
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter("../../result.txt"))
            {
                foreach (var word in words.OrderByDescending(w => w.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
