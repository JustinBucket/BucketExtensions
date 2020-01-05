using System;
using System.Linq;

namespace BucketExtensions.Consoles
{
    public class BucketMenu
    {
        public String[] MenuOptions { get; set; }
        public String Title { get; set; }
        public BucketMenu(string[] menuOptions)
        {
            MenuOptions = menuOptions;
        }

        public bool ValidateCommand(string command) 
        {
            var option = MenuOptions.FirstOrDefault(x => x.ToLower() == command.ToLower());

            if (!String.IsNullOrWhiteSpace(option))
                return true;

            return false;
        }
    }
}