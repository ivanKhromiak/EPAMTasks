using System;
using System.Collections.Generic;
using System.Text;

namespace UserInterface
{
    public interface IUserInterface
    {
        string Read();

        void Write(string input);
    }
}
