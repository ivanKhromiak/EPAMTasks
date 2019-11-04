using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class TasksRunner
    {
        private List<UserInterface.IRunnable> _runners = new List<UserInterface.IRunnable>();

        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public TasksRunner()
        {
            _runners.Add(new TasksStructs.Runner(new UserInterface.ConsoleUI()));
            _runners.Add(new TasksEnums.Runner(new UserInterface.ConsoleUI()));
            _runners.Add(new TasksExceptions.Runner(new UserInterface.ConsoleUI()));
            _runners.Add(new IOTasks.RunnerIOTasks(new UserInterface.ConsoleUI(), _logger));
            _runners.Add(new SerializationTasks.Runner(new UserInterface.ConsoleUI()));
            _runners.Add(new ReflectionTasks.ReflectionTasksRunner(new UserInterface.ConsoleUI()));
            _runners.Add(new Calculation.Runner());
            _runners.Add(new FileOperations.Runner(_logger));
            _runners.Add(new ExcelOperations.Runner(_logger));
            _runners.Add(new AsyncTasks.Runner(new UserInterface.ConsoleUI()));
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
