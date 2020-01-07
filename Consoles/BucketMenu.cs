using System;
using System.Collections.Generic;

namespace BucketExtensions.Consoles
{
    public static class BucketMenu
    {
        public static void DisplayMenuOptions(this IBucketMenu menu, char bullet)
        {
            Console.WriteLine("Menu options:");
            Console.WriteLine();
            
            if (menu.MenuOptions == null) 
            {
                throw new ArgumentNullException("The menu does not have any options initialized");
            }

            foreach (var i in menu.MenuOptions)
            {
                Console.WriteLine($"\t{bullet}\t{i}");
            }
            Console.WriteLine();
        }
    }
}