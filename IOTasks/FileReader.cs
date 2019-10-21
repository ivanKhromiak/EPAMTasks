using System;
using System.Collections.Generic;
using System.IO;

namespace IOTasks
{
    internal class FileReader
    {
        public UserInterface.IUserInterface UI { get; private set; }
        
        public FileReader(UserInterface.IUserInterface UI)
        {
            this.UI = UI;
        }

        internal void showInfoDirectory(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            var directories = directoryInfo.GetDirectories();
            var files = directoryInfo.GetFiles();
            foreach (var file in files)
            {
                UI.Write(file.FullName);
            }
            foreach (var directory in directories)
            {
                UI.Write(directory.FullName);
                showInfoDirectory(directory.ToString());
            }
        }
    }
}
