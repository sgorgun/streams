using System.Text;

namespace Streams
{
    public static class WritingToStream
    {
        public static void ReadAndWriteIntegers(StreamReader streamReader, StreamWriter outputWriter)
        {
            _ = streamReader ?? throw new ArgumentNullException(nameof(streamReader));
            _ = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));
            while (!streamReader.EndOfStream)
            {
                int value = streamReader.Read();
                if (value >= 0)
                {
                    outputWriter.Write(value);
                }
            }
        }

        public static void ReadAndWriteChars(StreamReader streamReader, StreamWriter outputWriter)
        {
            _ = streamReader ?? throw new ArgumentNullException(nameof(streamReader));
            _ = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));

            while (!streamReader.EndOfStream)
            {
                int value = streamReader.Read();
                if (value >= 0)
                {
                    outputWriter.Write((char)value);
                }
            }

            outputWriter.Flush();
        }

        public static void TransformBytesToHex(StreamReader contentReader, StreamWriter outputWriter)
        {
            _ = contentReader ?? throw new ArgumentNullException(nameof(contentReader));
            _ = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));
            while (!contentReader.EndOfStream)
            {
                int value = contentReader.Read();
                if (value != -1)
                {
                    outputWriter.Write($"{value:X2}");
                }
            }
        }

        public static void WriteLinesWithNumbers(StreamReader contentReader, StreamWriter outputWriter)
        {
            _ = contentReader ?? throw new ArgumentNullException(nameof(contentReader));
            _ = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));
            int lineNumber = 1;
            while (!contentReader.EndOfStream)
            {
                string? line = contentReader.ReadLine();
                outputWriter.WriteLine($"{lineNumber:D3} {line}");
                lineNumber++;
            }

            outputWriter.Flush();
        }

        public static void RemoveWordsFromContentAndWrite(StreamReader contentReader, StreamReader wordsReader, StreamWriter outputWriter)
        {
            _ = contentReader ?? throw new ArgumentNullException(nameof(contentReader));
            _ = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));
            _ = wordsReader ?? throw new ArgumentNullException(nameof(wordsReader));
            StringBuilder content = new StringBuilder();
            while (!contentReader.EndOfStream)
            {
                _ = content.Append((char)contentReader.Read());
            }

            contentReader.BaseStream.Position = 0;

            while (!wordsReader.EndOfStream)
            {
                string? word = wordsReader.ReadLine();
                _ = content.Replace(word!, string.Empty);
            }

            outputWriter.Write(content.ToString());
        }
    }
}
