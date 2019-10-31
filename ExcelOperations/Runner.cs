using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ExcelOperations
{
    public class Runner
    {
        public UserInterface.IUserInterface UI { get; }

        public Logger.ILogger Logger { get; }

        public static IConfigurationRoot Configuration { get; }

        static Runner()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appconfig.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public Runner(Logger.ILogger logger)
        {
            if (Configuration["resultDestination"] == "Console")
            {
                UI = new UserInterface.ConsoleUI();
            }
            else if (Configuration["resultDestination"] == "Excel")
            {
                UI = new UserInterface.ExcelUI(Configuration["pathToExcelFile"]);
            }

            Logger = logger;
        }

        public void Run()
        {
            int sourceColumn;
            int.TryParse(Configuration["sourceColumn"], out sourceColumn);
            int comparerColumn;
            int.TryParse(Configuration["comparerColumn"], out comparerColumn);

            var excelDirectoryReader = new ExcelReaderHashSet(Configuration["pathToSourceFile"], sourceColumn, comparerColumn);

            UI.Write("Unique files: ");
            foreach (var item in excelDirectoryReader.GetUnique())
            {
                UI.Write(item);
            }
        }
    }
}
