using System;
using System.Collections.Generic;

namespace BucketExtensions.Consoles
{
    public class BucketConsole
    {
        public int ColumnCount { get; set; }
        public int RowCount { get; set; }
        public string Title { get; set; }
        public char Delimiter { get; set; }
        private string FillerLine { get; set; }
        private string EdgeLine { get; set; }
        public List<BucketMenu> Menus { get; private set; }
        public BucketConsole(int columnCount, int rowCount, string title, char delimiter) 
        {
            ColumnCount = columnCount;
            Title = title;
            Delimiter = delimiter;
            RowCount = rowCount;
            FillerLine = Delimiter + new String(' ', ColumnCount - 2) + Delimiter;
            EdgeLine = new String(delimiter, ColumnCount);
        }
        public void DisplayConsoleTitle() 
        {
            
            var titleLine = GenerateTitleLine();

            Console.WriteLine(EdgeLine);
            Console.WriteLine(FillerLine);
            Console.WriteLine(titleLine);

            for (int i = 0; i < RowCount - 5; i++)
            {
                Console.WriteLine(FillerLine);
            }

            Console.WriteLine(FillerLine);
            Console.WriteLine(EdgeLine);
        }
        private string GenerateTitleLine()
        {
            int charsToAdd = (int)Math.Floor(((double)ColumnCount - (double)Title.Length)/2);

            var titleLine = Delimiter + Title.PadLeft(Title.Length + charsToAdd - 1, ' ');
            titleLine = titleLine.PadRight(titleLine.Length + charsToAdd - 1, ' ') + Delimiter;

            if (titleLine.Length < ColumnCount)
                titleLine.Replace(" *", "  *");

            return titleLine;
        }
        public BucketMenu GenerateMenu(char bullet, string title)
        {
            var newMenu = new BucketMenu(bullet, title, this);
            
            Menus.Add(newMenu);
            
            return newMenu;
        }
    }
}