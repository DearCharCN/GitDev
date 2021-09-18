using LibGit2Sharp;
using System;
using System.IO;

namespace GitForUnity
{
    public class GlobalProperties
    {
        public static string ProjectPath
        {
            get
            {
                return System.Environment.CurrentDirectory;
            }
        }
    }
}

