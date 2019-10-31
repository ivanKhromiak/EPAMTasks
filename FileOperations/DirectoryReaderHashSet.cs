using System;
using System.IO;
using System.Collections.Generic;

namespace FileOperations
{
    class DirectoryReaderHashSet: IDirectoryReader
    {
        private HashSet<string> _uniqueFiles = new HashSet<string>();

        private HashSet<string> _dublicateFiles = new HashSet<string>();

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
            if (!Directory.Exists(path))
            {
                throw new ArgumentException("No such path");
            }

            var directoryInfo = new DirectoryInfo(path);
            var directories = directoryInfo.GetDirectories();
            var filesInfo = directoryInfo.GetFiles();
            var files = new HashSet<string>();

            foreach (var item in filesInfo)
            {
                files.Add(Path.GetFileName(item.FullName));
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
            uniqueFiles.UnionWith(GetFiles(pathToComparerDirectory));
            uniqueFiles.ExceptWith(_dublicateFiles);
            return uniqueFiles;
        }
    }
}
