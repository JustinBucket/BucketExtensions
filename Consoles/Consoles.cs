using System;

namespace BucketExtensions.Consoles
{
    public class BucketConsole
    {
        public int ColumnCount { get; set; }
        public string Title { get; set; }
        public char Delimiter { get; set; }
        public BucketConsole(int columnCount, string title, char delimiter) 
        {
            ColumnCount = columnCount;
            Title = title;
            Delimiter = delimiter;
        }
        public void DisplayConsoleTitle() 
        {
            Console.WriteLine(new String('*', ColumnCount));
            Console.WriteLine(Delimiter + new String(' ', ColumnCount - 2) + Delimiter);

            int charsToAdd = (int)Math.Floor(((double)ColumnCount - (double)Title.Length)/2);

            var returnString = Delimiter + Title.PadLeft(Title.Length + charsToAdd - 1, ' ');
            returnString = returnString.PadRight(returnString.Length + charsToAdd - 1, ' ') + Delimiter;

            if (returnString.Length < ColumnCount)
                returnString.Replace(" *", "  *");

            Console.WriteLine(returnString);

            Console.WriteLine(Delimiter + new String(' ', ColumnCount - 2) + Delimiter);
            Console.WriteLine(new String(Delimiter, ColumnCount));
        }
    }
}