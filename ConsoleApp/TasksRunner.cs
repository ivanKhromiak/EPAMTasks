using System;
using System.Collections.Generic;
using System.Text;
using InversionOfControl;
using UserInterface;

namespace ConsoleApp
{
    class TasksRunner
    {
        private List<UserInterface.IRunnable> _runners = new List<UserInterface.IRunnable>();

        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public TasksRunner()
        {
            var container = new Container();
            container.RegisterSingleton<IUserInterface, ConsoleUI>(new ConsoleUI());

            _runners.Add(new TasksStructs.Runner(container.GetInstance<ConsoleUI>()));
            _runners.Add(new TasksEnums.Runner(container.GetInstance<ConsoleUI>()));
            _runners.Add(new TasksExceptions.Runner(container.GetInstance<ConsoleUI>()));
            _runners.Add(new IOTasks.RunnerIOTasks(container.GetInstance<ConsoleUI>(), _logger));
            _runners.Add(new SerializationTasks.Runner(container.GetInstance<ConsoleUI>()));
            _runners.Add(new ReflectionTasks.ReflectionTasksRunner(container.GetInstance<ConsoleUI>()));
            _runners.Add(new Calculation.Runner());
            _runners.Add(new FileOperations.Runner(_logger));
            _runners.Add(new ExcelOperations.Runner(_logger));
            _runners.Add(new AsyncTasks.Runner(container.GetInstance<ConsoleUI>()));
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
