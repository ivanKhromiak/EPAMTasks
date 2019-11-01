using System;
using System.Collections.Generic;
using System.Text;

namespace Calculation
{
    internal interface IWriter
    {
        void Write(string input);
        string Read();
    }
}
