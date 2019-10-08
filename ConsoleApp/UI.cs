using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class UI : UserInterface.IUserInterface
    {
        public string Read()
        {
            return Console.ReadLine();
        }

        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
