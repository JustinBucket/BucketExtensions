using System;

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
                Console.WriteLine($"{bullet}\t{i}");
            }
            Console.WriteLine();
        }
    }
}