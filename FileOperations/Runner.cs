using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Diagnostics;

namespace FileOperations
{
    public class Runner
    {
        public UserInterface.IUserInterface UI { get; }

        private Logger.ILogger _logger;

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

            _logger = logger;
        }

        public void Run()
        {
            try
            {
                Stopwatch watch = Stopwatch.StartNew();
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
                watch.Stop();
                UI.Write("Elapsed time: " + watch.Elapsed.ToString());
            }
            catch(Exception e)
            {
                _logger.LogMessage(e, Logger.LoggingLevels.Error);
            }
        }
    }
}
