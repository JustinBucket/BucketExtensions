using System;
using System.Collections.Generic;

namespace BucketExtensions.Consoles
{
    public interface IBucketMenu
    {
        public List<String> MenuOptions { get; }
        public void DisplayOptions();
        public string RetrieveUserOption();
        public bool ValidateUserOption();
        public void Exit();
    }
}