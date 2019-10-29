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

            //var runnerTasksIO = new IOTasks.RunnerIOTasks(new UI(), new Logger.CustomLogger(new Logger.FileLog(), Logger.LoggingLevels.Error));
            //runnerTasksIO.Run();

            var runnerTaskSerialization = new SerializationTasks.Runner(new UI());
            runnerTaskSerialization.Run();

            //var runnerReflectionTasks = new ReflectionTasks.ReflectionTasksRunner(new UI());
            //runnerReflectionTasks.Run();


        }
    }
}
