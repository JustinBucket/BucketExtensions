using System;
using System.Collections.Generic;

namespace BucketExtensions.Consoles
{
    public class BucketMenu
    {
        public BucketConsole ParentConsole { get; }
        private char Bullet { get; set; }
        public string Title { get; }
        public List<String> MenuOptions { get; }
        public BucketMenu(char bullet, string title, BucketConsole console)
        {
            ParentConsole = console;
            Bullet = bullet;
            Title = title;
        }
        public string RetrieveUserOption() 
        {
            throw new NotImplementedException();
        }
        public bool ValidateUserOption() 
        {
            throw new NotImplementedException();
        }
        public void Exit()
        {
            throw new NotImplementedException();
        }
        public void DisplayMenuScreen()
        {
            Console.WriteLine("Menu options:");
            Console.WriteLine();
            
            if (MenuOptions == null) 
            {
                throw new ArgumentNullException("The menu does not have any options initialized");
            }

            foreach (var i in MenuOptions)
            {
                Console.WriteLine($"{Bullet}\t{i}");
            }
            Console.WriteLine();
        }

    }
}