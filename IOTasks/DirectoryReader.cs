using System;
using System.Collections.Generic;
using System.IO;

namespace IOTasks
{
    internal class DirectoryReader
    {
        internal List<string> GetContentFromDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new ArgumentException("No such path");
            }

            var contentFromDirectory = new List<string>();
            var directoryInfo = new DirectoryInfo(path);
            var directories = directoryInfo.GetDirectories();
            var files = directoryInfo.GetFiles();

            foreach (var file in files)
            {
                contentFromDirectory.Add(file.FullName);
            }

            foreach (var directory in directories)
            {
                contentFromDirectory.Add(directory.FullName);
                contentFromDirectory.AddRange(GetContentFromDirectory(directory.ToString()));
            }

            return contentFromDirectory;
        }
    }
}
