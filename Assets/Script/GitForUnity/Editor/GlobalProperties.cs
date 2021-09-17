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


        public static bool IsVoidGitPath(string path, ref string voidPath)
        {
            voidPath = string.Empty;
            if (!Directory.Exists(path))
            {
                return false;
            }

            DirectoryInfo dirInfo = Directory.CreateDirectory(path);
            while (dirInfo != null)
            {
                if(Repository.IsValid(dirInfo.FullName))
                {
                    voidPath = dirInfo.FullName;
                    return false;
                }
                dirInfo = dirInfo.Parent;
            }
            return false;
        }
    }
}

