using System;
using System.Collections.Generic;
using System.Text;

namespace FileOperations
{
    interface IDirectoryReader
    {
        ICollection<string> GetUniqueFiles();

        ICollection<string> GetDublicateFiles();

        int GetCountOfDublicateFiles();
    }
}
