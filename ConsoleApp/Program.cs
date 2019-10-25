using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var runnnerTasksStructs = new TasksStructs.Runner(new UI());
            //runnnerTasksStructs.Run();

            //var runnerTasksEnum = new TasksEnums.Runner(new UI());
            //runnerTasksEnum.Run();

            //var runnerTasksExceptions = new TasksExceptions.Runner(new UI());
            //runnerTasksExceptions.RunTask5();

            var runnerTasksIO = new IOTasks.RunnerIOTasks(new UI(), new Logger.CustomLogger(Logger.FileLog.WriteLog));
            runnerTasksIO.Run();

            //var runnerReflectionTasks = new ReflectionTasks.ReflectionTasksRunner(new UI());
            //runnerReflectionTasks.Run();
        }
    }
}
