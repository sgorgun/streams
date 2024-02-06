using System.Text;

namespace Streams
{
    public static class ReadingFromStream
    {
        public static string ReadAllStreamContent(StreamReader streamReader)
        {
            return new string(streamReader?.ReadToEnd());
        }

        public static string[] ReadLineByLine(StreamReader streamReader)
        {
            _ = streamReader ?? throw new ArgumentNullException(nameof(streamReader));
            var lines = new List<string>();
            string? line;
            while ((line = streamReader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            return lines.ToArray();
        }

        public static StringBuilder ReadOnlyLettersAndNumbers(StreamReader streamReader)
        {
            _ = streamReader ?? throw new ArgumentNullException(nameof(streamReader));
            var stringBuilder = new StringBuilder();

            int nextChar;
            while ((nextChar = streamReader.Peek()) != -1)
            {
                char c = (char)nextChar;
                if (char.IsLetterOrDigit(c))
                {
                    _ = stringBuilder.Append(c);
                    _ = streamReader.Read();
                }
                else
                {
                    break;
                }
            }

            return stringBuilder;
        }

        public static char[][] ReadAsCharArrays(StreamReader streamReader, int arraySize)
        {
            _ = streamReader ?? throw new ArgumentNullException(nameof(streamReader));
            var charArrays = new List<char[]>();
            char[] buffer = new char[arraySize];
            int readChars;
            while ((readChars = streamReader.Read(buffer, 0, arraySize)) > 0)
            {
                char[] copy = new char[readChars];
                Array.Copy(buffer, copy, readChars);
                charArrays.Add(copy);
            }

            return charArrays.ToArray();
        }
    }
}
