using System;

namespace BucketExtensions.CLI
{
    public class CliModifier
    {
        // modifer class represents the options of a command
        public string Key { get; private set; }
        public string Description { get; private set; }

        public CliModifier(string key, string description)
        {
            Key = key;
            Description = description;
        }
    }
}