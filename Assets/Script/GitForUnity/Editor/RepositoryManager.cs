using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibGit2Sharp;
using System.IO;

namespace GitForUnity
{
    public class RepositoryManager
    {
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
                if (Repository.IsValid(dirInfo.FullName))
                {
                    voidPath = dirInfo.FullName;
                    return true;
                }
                dirInfo = dirInfo.Parent;
            }
            return false;
        }

        public static bool IsVoidRepository(string path, ref IRepositoryEntry repository)
        {
            string voidPath = string.Empty;
            return IsVoidRepository(path, ref repository, ref voidPath);
        }

        public static bool IsVoidRepository(string path, ref IRepositoryEntry repository, ref string voidPath)
        {
            voidPath = string.Empty;
            repository = null;
            if (!IsVoidGitPath(path, ref voidPath))
                return false;

            Repository r = new Repository(voidPath);

            repository = new RepositoryEntry(r, voidPath);
            return true;
        }

        public static IRepositoryEntry GetProjectRepository()
        {
            IRepositoryEntry rp = null;
            IsVoidRepository(GlobalProperties.ProjectPath, ref rp);
            return rp;
        }
    }

    public class RepositoryEntry : IRepositoryEntry
    {
        public Repository Repository { get { return _repository; } }

        private Repository _repository;

        public string RootRepositoryPath { get { return _rootRepositoryPath; } }

        public string _rootRepositoryPath;

        public RepositoryEntry(Repository repository, string rootRepositoryPath)
        {
            _repository = repository;
            _rootRepositoryPath = rootRepositoryPath;
        }
    }

    public interface IRepositoryEntry
    {
        Repository Repository { get; }

        string RootRepositoryPath { get; }
    }
}

