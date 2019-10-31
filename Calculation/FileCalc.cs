using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Calculation
{
    public class FileCalc : IWriter
    {
        private int _line = 0;
        public string Read()
        {
            using (StreamReader streamReader = new StreamReader(@"D:\Test\Arguments.txt"))
            {
                for (int i = 0; i < _line; i++)
                {
                    streamReader.ReadLine();
                }
                _line++;
                return streamReader.ReadLine();
            }
        }

        public void Write(string input)
        {
            using (StreamWriter streamWriter = new StreamWriter(@"D:\Test\Result.txt"))
            {
                streamWriter.WriteLine(input);
            }
        }
    }
}
