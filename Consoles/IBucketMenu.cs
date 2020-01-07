using System;
using System.Collections.Generic;

namespace BucketExtensions.Consoles
{
    public interface IBucketMenu
    {
        public string Title { get; }
        public List<String> MenuOptions { get; }
        public void DisplayTitle();
        public void DisplayOptions();
        public string RetrieveUserOption();
        public bool ValidateUserOption();
        public void Exit();
    }
}