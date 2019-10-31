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

            var runnerFileOperations = 
                new FileOperations.Runner(new Logger.CustomLogger(new Logger.FileLog(), Logger.LoggingLevels.Error));
            runnerFileOperations.Run();

            //var calc = new Calculation.Calc();

            //int Addition(int x, int y)
            //{
            //    return x + y;
            //}
            //Calculation.IWriter ui = new Calculation.ConsoleCalc();

            //int result = calc.calculation(int.Parse(ui.Read()), int.Parse(ui.Read()), Addition);
            //ui.Write(result.ToString());

            //ui = new Calculation.FileCalc();
            //result = calc.calculation(int.Parse(ui.Read()), int.Parse(ui.Read()), Addition);
            //ui.Write(result.ToString());
        }
    }
}
