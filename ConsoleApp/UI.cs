using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class ConsoleUI : UserInterface.IUserInterface
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
