using System;

namespace ConsoleApp
{
    class Program
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            //var runnnerTasksStructs = new TasksStructs.Runner(new UserInterface.ConsoleUI());
            //runnnerTasksStructs.Run();

            //var runnerTasksEnum = new TasksEnums.Runner(new UserInterface.ConsoleUI());
            //runnerTasksEnum.Run();

            //var runnerTasksExceptions = new TasksExceptions.Runner(new UserInterface.ConsoleUI());
            //runnerTasksExceptions.RunTask5();

            //var runnerTasksIO = new IOTasks.RunnerIOTasks(new UserInterface.ConsoleUI(), _logger);
            //runnerTasksIO.Run();

            //var runnerTaskSerialization = new SerializationTasks.Runner(new ConsoleUI());
            //runnerTaskSerialization.Run();

            //var runnerReflectionTasks = new ReflectionTasks.ReflectionTasksRunner(new UserInterface.ConsoleUI());
            //runnerReflectionTasks.Run();

            //var calculationRunner = new Calculation.Runner();
            //calculationRunner.Run();

            var runnerFileOperations = new FileOperations.Runner(_logger);
            runnerFileOperations.Run();

            var runnerExcelOperations = new ExcelOperations.Runner(_logger);
            runnerExcelOperations.Run();
        }
    }
}
