using System;
using System.Linq;
using System.Collections.Generic;

namespace CLI.Helpers
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
        public void CallCommand(string commandRequest) 
        {
            var command = Functions.FirstOrDefault(x => x.Name.ToLower() == commandRequest.ToLower());
            if (command == null)
                throw new ArgumentException("command not found");

            command.Invoke();
        }
    }
}