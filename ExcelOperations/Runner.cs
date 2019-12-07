using System;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.IO;
using OneDriveManipulation;

namespace ExcelOperations
{
    public class Runner: UserInterface.IRunnable
    {
        public UserInterface.IUserInterface UI { get; }

        private readonly NLog.ILogger _logger;

        public static IConfigurationRoot Configuration { get; }

        static Runner()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appconfig.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public Runner(NLog.ILogger logger)
        {
            if (Configuration["resultDestination"] == "Console")
            {
                UI = new UserInterface.ConsoleUI();
            }
            else if (Configuration["resultDestination"] == "Excel")
            {
                UI = new UserInterface.ExcelUI(Configuration["pathToExcelFile"]);
            }

            _logger = logger;
        }

        public void Run()
        {
            try
            {
                var watch = Stopwatch.StartNew();
                int.TryParse(Configuration["sourceColumn"], out var sourceColumn);
                int.TryParse(Configuration["comparerColumn"], out var comparerColumn);

                var excelDirectoryReader = new ExcelReaderHashSet(Configuration["pathToSourceFile"], sourceColumn, comparerColumn);

                UI.Write("Unique values: ");
                foreach (var item in excelDirectoryReader.GetUnique())
                {
                    UI.Write(item);
                }
                watch.Stop();
                UI.Write("Elapsed time: " + watch.Elapsed.ToString());
            }
            catch(Exception e)
            {
                _logger.Error(e);
            }
        }
    }
}
