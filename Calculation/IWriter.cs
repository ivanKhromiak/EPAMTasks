using System;
using System.Collections.Generic;
using System.Text;

namespace Calculation
{
    public interface IWriter
    {
        void Write(string input);
        string Read();
    }
}
