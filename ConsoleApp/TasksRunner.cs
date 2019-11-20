using System;
using System.Collections.Generic;
using UserInterface;
using NLog;

namespace ConsoleApp
{
    class TasksRunner
    {
        private readonly List<UserInterface.IRunnable> _runners = new List<UserInterface.IRunnable>();

        private static readonly NLog.Logger _logger = LogManager.GetCurrentClassLogger();

        public TasksRunner()
        {
            _runners.Add(new TasksStructs.Runner(new ConsoleUI()));
            _runners.Add(new TasksEnums.Runner(new ConsoleUI()));
            _runners.Add(new TasksExceptions.Runner(new ConsoleUI()));
            _runners.Add(new IOTasks.RunnerIOTasks(new ConsoleUI(), _logger));
            _runners.Add(new SerializationTasks.Runner(new ConsoleUI()));
            _runners.Add(new ReflectionTasks.ReflectionTasksRunner(new ConsoleUI()));
            _runners.Add(new Calculation.Runner());
            _runners.Add(new FileOperations.Runner(_logger));
            _runners.Add(new ExcelOperations.Runner(_logger));
            _runners.Add(new AsyncTasks.Runner(new ConsoleUI()));
        }

        public void Run(int choice)
        {
            if(choice < 0 && choice >= _runners.Count)
            {
                Console.WriteLine("No such tasks");
                return;
            }
               
            _runners[choice].Run();
        }
    }
}
