using System;
using System.IO;
using System.Collections.Generic;

namespace FileOperations
{
    class DirectoryReaderHashSet: IDirectoryReader
    {
        private HashSet<string> _uniqueFiles = new HashSet<string>();

        private HashSet<string> _dublicateFiles = new HashSet<string>();

        private int _dublicateCount;

        public DirectoryReaderHashSet(string path1, string path2)
        {
            GetFilesAndCountUnique(path1);
            GetFilesAndCountUnique(path2);
        }

        public int GetDublicateCount()
        {
            return _dublicateCount;
        }

        public ICollection<string> GetDublicateFiles()
        {
            return _dublicateFiles;
        }

        public ICollection<string> GetFiles()
        {
            return _uniqueFiles;
        }

        private HashSet<string> GetFilesAndCountUnique(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new ArgumentException("No such path");
            }

            var directoryInfo = new DirectoryInfo(path);
            var directories = directoryInfo.GetDirectories();
            var files = directoryInfo.GetFiles();

            foreach (var file in files)
            {
                if (!_uniqueFiles.Add(Path.GetFileName(file.FullName)))
                {
                    _dublicateCount++;
                    _uniqueFiles.Remove(Path.GetFileName(file.FullName));
                    _dublicateFiles.Add(Path.GetFileName(file.FullName));
                }
            }

            foreach (var directory in directories)
            {
                _uniqueFiles.UnionWith(GetFilesAndCountUnique(directory.ToString()));
            }

            return _uniqueFiles;
        }  
    }
}
