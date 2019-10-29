using System;
using System.Collections.Generic;
using System.Text;

namespace FileOperations
{
    interface IDirectoryReader
    {
        ICollection<string> GetFiles();

        ICollection<string> GetDublicateFiles();

        int GetDublicateCount();
    }
}
