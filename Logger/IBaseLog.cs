using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public interface ILogBase
    {
        void WriteLog(string Message);
    }
}
