using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace BucketExtensions.CLI
{
    public class BucketCliMenu
    {
        public string Title { get; set; }
        public List<BucketCliMenu> SubMenus { get; set; }
        public List<BucketCliCommand> Commands { get; set; }
        public BucketCliMenu()
        {
            SubMenus = new List<BucketCliMenu>();
            Commands = new List<BucketCliCommand>();
        }
        public BucketCliMenu Dig(string title)
        {
            return SubMenus.Find(x => x.Title.ToLower() == title.ToLower());
        }
        public void CallCommand(string commandRequest) 
        {
            var command = Commands.FirstOrDefault(x => x.Name.ToLower() == commandRequest.ToLower());
            if (command == null)
                throw new ArgumentException("command not found");

            command.Invoke();
        }
    }
}