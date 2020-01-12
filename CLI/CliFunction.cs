using System;

namespace BucketExtensions.CLI
{
    public abstract class CliFunction
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public CliModifier[] Modifiers { get; protected set; }
        public abstract void Invoke(string[] modifiers = null);
        protected abstract void Run();
        protected void DisplayHelp()
        {
            Console.WriteLine();
            Console.WriteLine("Help:");
            Console.WriteLine($"  {Name}: {Description}");
            DisplayModifiers();
        }
        protected void DisplayModifiers()
        {
            Console.WriteLine();
            Console.WriteLine("  modifiers:");
            foreach (var i in Modifiers)
            {
                Console.WriteLine($"\t- {i.Key}: {i.Description}");
            }
        }
    }
}
