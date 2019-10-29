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

            //var runnerTaskSerialization = new SerializationTasks.Runner(new ConsoleUI());
            //runnerTaskSerialization.Run();

            //var runnerReflectionTasks = new ReflectionTasks.ReflectionTasksRunner(new UI());
            //runnerReflectionTasks.Run();

            UserInterface.IUserInterface ui;

            if (FileOperations.Runner.Configuration["resultDestination"] == "Console")
            {
                ui = new ConsoleApp.ConsoleUI();
            }
            else
            {
                ui = new ConsoleApp.ConsoleUI();
            }

            var runnerFileOperations = new FileOperations.Runner(ui, new Logger.CustomLogger(new Logger.FileLog(), Logger.LoggingLevels.Error));
            runnerFileOperations.Run();
        }
    }
}
