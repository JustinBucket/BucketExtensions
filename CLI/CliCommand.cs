using System;
using System.Collections.Generic;

namespace CLI.Helpers
{
    public class CliCommand
    {
        public string[] Menus { get; set; }
        public string FunctionName { get; set; }
        public string Command { get; set; }
        public CliCommand(string command) 
        {
            Command = command;
            ParseCommand();
        }
        private void ParseCommand()
        {
            var splitCommand = Command.Split(' ');
            Menus = new string[splitCommand.Length - 1];
            FunctionName = splitCommand[splitCommand.Length - 1];
            Array.Copy(splitCommand, Menus, splitCommand.Length - 1);
        }
    }
}
