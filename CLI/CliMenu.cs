using System;
using System.Linq;
using System.Collections.Generic;

namespace BucketExtensions.CLI
{
    public class CliMenu
    {
        public string Title { get; private set; }
        public List<CliMenu> SubMenus { get; set; }
        public List<CliFunction> Functions { get; set; }
        public CliMenu(string title)
        {
            SubMenus = new List<CliMenu>();
            Functions = new List<CliFunction>();
            Title = title;
        }
        public CliMenu Dig(string[] menus, int menuLevel)
        {
            CliMenu menu = null;
            if (menuLevel != menus.Length - 1)
            {
                var lowerLevel = SubMenus.Find(X => X.Title.ToLower() == menus[menuLevel + 1]);
                menu = lowerLevel.Dig(menus, menuLevel + 1);
            }
            else
                menu = this;
            
            return menu;
        }
        public void CallCommand(CliCommand command) 
        {
            var function = Functions.FirstOrDefault(x => x.Name.ToLower() == command.FunctionName.ToLower());
            
            if (function == null)
                InvalidCommandDisplay(command.FunctionName);

            else
                function.Invoke(command.Modifiers);
        }
        public void DisplayHelp() 
        {
            Console.WriteLine();
            Console.WriteLine("available functions:");
            Console.WriteLine();
            foreach (var i in Functions)
            {
                Console.WriteLine($"\t- {i.Name}: {i.Description}");
            }
        }
        public void InvalidCommandDisplay(string function)
        {
            Console.WriteLine();
            Console.WriteLine($"function '{function}' is not recognized");
            DisplayHelp();
        }

    }
}