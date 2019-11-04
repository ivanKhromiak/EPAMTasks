using System;
using System.IO;
using System.Collections.Generic;

namespace FileOperations
{
    class DirectoryReaderHashSet: IDirectoryReader
    {
        private HashSet<string> _uniqueFiles;

        private HashSet<string> _dublicateFiles;

        public DirectoryReaderHashSet(string pathToSourceDirectory, string pathToComparerDirectory)
        {
            _uniqueFiles = SetUniqueFiles(pathToSourceDirectory, pathToComparerDirectory);
            _dublicateFiles = SetDublicateFiles(pathToSourceDirectory, pathToComparerDirectory);
        }

        public ICollection<string> GetDublicateFiles()
        {
            return _dublicateFiles;
        }

        public int GetCountOfDublicateFiles()
        {
            return _dublicateFiles.Count;
        }

        public ICollection<string> GetUniqueFiles()
        {
            return _uniqueFiles;
        }

        private HashSet<string> GetFiles(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("The path is empty"); 
            }
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException("No such path: " + path);
            }

            var directoryInfo = new DirectoryInfo(path);
            var directories = directoryInfo.GetDirectories();
            var filesInfo = directoryInfo.GetFiles();
            var files = new HashSet<string>();

            foreach (var item in filesInfo)
            {
                files.Add(Path.GetFileName(item.FullName));
            }

            foreach (var directory in directories)
            {
                files.UnionWith(GetFiles(directory.ToString()));
            }

            return files;
        }

        private HashSet<string> SetDublicateFiles(string pathToSourceDirectory, string pathToComparerDirectory)
        {
            var dublicateFiles = GetFiles(pathToSourceDirectory);
            dublicateFiles.IntersectWith(GetFiles(pathToComparerDirectory));
            return dublicateFiles;
        }

        private HashSet<string> SetUniqueFiles(string pathToSourceDirectory, string pathToComparerDirectory)
        {
            var uniqueFiles = GetFiles(pathToSourceDirectory);
            uniqueFiles.SymmetricExceptWith(GetFiles(pathToComparerDirectory));
            return uniqueFiles;
        }
    }
}
