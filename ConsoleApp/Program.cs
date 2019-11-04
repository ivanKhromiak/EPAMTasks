using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = new TasksRunner();
            Console.WriteLine("Enter the number of tasks you want:");
            Console.WriteLine("0 - Struct tasks");
            Console.WriteLine("1 - Enum tasks");
            Console.WriteLine("2 - Exceptions tasks");
            Console.WriteLine("3 - IO tasks");
            Console.WriteLine("4 - Reflection tasks");
            Console.WriteLine("5 - Calculation tasks");
            Console.WriteLine("6 - File operations tasks");
            Console.WriteLine("7 - Excel operations tasks");
            Console.WriteLine("8 - Async tasks");

            if(!int.TryParse(Console.ReadLine(), out var choice))
            {
                Console.WriteLine("You enter invalid number");
                return;
            }

            runner.Run(choice);
        }
    }
}
