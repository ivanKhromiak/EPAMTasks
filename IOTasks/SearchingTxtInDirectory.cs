using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IOTasks
{
    internal class SearchingTxtInDirectory
    {
        internal List<string> SearchTxtInDirectory(string path, string name)
        {
            var foundedTxt = new List<string>();
            var files = new DirectoryInfo(path).GetFiles("*" + name + "*" + ".txt");
            foreach (var item in files)
            {
                foundedTxt.Add(item.ToString());
            }
            return foundedTxt;
        }
    }
}
