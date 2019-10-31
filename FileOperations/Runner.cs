using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace FileOperations
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
            var directoryReaderHashSet = 
                new DirectoryReaderHashSet(Configuration["pathToSourceDirectory"], Configuration["pathToComparerDirectory"]);

            UI.Write("Dublicate files: ");
            foreach (var item in directoryReaderHashSet.GetDublicateFiles())
            {
                UI.Write(item);
            }

            UI.Write("Count of dublicate files: ");
            UI.Write(directoryReaderHashSet.GetCountOfDublicateFiles().ToString());

            UI.Write("Unique files: ");
            foreach (var item in directoryReaderHashSet.GetUniqueFiles())
            {
                UI.Write(item);
            }
        }
    }
}
