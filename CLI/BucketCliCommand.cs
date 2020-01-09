using System;

namespace BucketExtensions.CLI
{
    public abstract class BucketCliCommand
    {
        public abstract string Name { get; }
        public abstract void Invoke();
    }
}
