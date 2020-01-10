using System;

namespace CLI.Helpers
{
    public abstract class CliFunction
    {
        public abstract string Name { get; }
        public abstract void Invoke();
    }
}
