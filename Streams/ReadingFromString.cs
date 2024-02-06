namespace Streams
{
    public static class ReadingFromString
    {
        public static string ReadAllStreamContent(StringReader stringReader)
        {
            _ = stringReader ?? throw new ArgumentNullException(nameof(stringReader));
            return stringReader.ReadToEnd();
        }

        public static string ReadCurrentLine(StringReader stringReader)
        {
            _ = stringReader ?? throw new ArgumentNullException(nameof(stringReader));
            return stringReader!.ReadLine() ?? string.Empty;
        }

        public static bool ReadNextCharacter(StringReader stringReader, out char currentChar)
        {
            _ = stringReader ?? throw new ArgumentNullException(nameof(stringReader));
            int nextChar = stringReader.Read();
            currentChar = nextChar >= 0 ? Convert.ToChar(nextChar) : ' ';
            return nextChar >= 0;
        }

        public static bool PeekNextCharacter(StringReader stringReader, out char currentChar)
        {
            _ = stringReader ?? throw new ArgumentNullException(nameof(stringReader));
            int nextChar = stringReader.Peek();
            currentChar = nextChar >= 0 ? Convert.ToChar(nextChar) : ' ';
            return nextChar >= 0;
        }

        public static char[] ReadCharactersToBuffer(StringReader stringReader, int count)
        {
            _ = stringReader ?? throw new ArgumentNullException(nameof(stringReader));
            char[] buffer = new char[count];
            _ = stringReader.Read(buffer, 0, count);
            return buffer;
        }
    }
}
