using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var runnnerTasksStructs = new TasksStructs.Runner(new UI());
            runnnerTasksStructs.Run();

            var runnerTasksEnum = new TasksEnums.Runner(new UI());
            runnerTasksEnum.Run();
        }
    }
}
