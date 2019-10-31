using System;

namespace UserInterface
{
    public class ConsoleUI : UserInterface.IUserInterface
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
