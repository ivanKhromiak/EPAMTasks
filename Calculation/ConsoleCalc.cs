using System;
using System.Collections.Generic;
using System.Text;

namespace Calculation
{
    public class ConsoleCalc : IWriter
    {
        public string Read()
        {
            return Console.ReadLine();
        }

        public void Write(string input)
        {
            Console.WriteLine(input);
        }
    }
}
