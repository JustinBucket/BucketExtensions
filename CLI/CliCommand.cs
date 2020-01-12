using System;
using System.Collections.Generic;

namespace BucketExtensions.CLI
{
    public class CliCommand
    {
        public string[] Menus { get; set; }
        public string FunctionName { get; set; }
        public string Command { get; set; }
        public string[] Modifiers { get; set; }
        public CliCommand(string command) 
        {
            Command = command;
            ParseCommand();
        }
        private void ParseCommand()
        {
            string[] splitCommand;

            if (Command.Contains("-"))
            {
                splitCommand = Command.Substring(0, Command.IndexOf("-")).Trim().Split(' ');
                Modifiers = RetrieveModifiers(Command);
            }
            else
                splitCommand = Command.Split(' ');
            
            Menus = new string[splitCommand.Length - 1];
            FunctionName = splitCommand[splitCommand.Length - 1];
            Array.Copy(splitCommand, Menus, splitCommand.Length - 1);
        }
        private string[] RetrieveModifiers(string command)
        {
            var startPoint = command.IndexOf("-");

            return command.Substring(startPoint).Replace("-", "").Split(' ');
        }
    }
}
