﻿using System;
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

        public IConfigurationRoot Configuration { get; }

        public Runner(UserInterface.IUserInterface ui, Logger.ILogger logger)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();

            Logger = logger;
        }

        public void Run()
        {
            var directoryReaderHashSet = new DirectoryReaderHashSet(Configuration["path1"], Configuration["path2"]);
            UI.Write("Dublicate files: ");
            foreach (var item in directoryReaderHashSet.GetDublicateFiles())
            {
                UI.Write(item);
            }

            UI.Write("Count of dublicate files: ");
            UI.Write(directoryReaderHashSet.GetDublicateCount().ToString());

            UI.Write("Unique files: ");
            foreach (var item in directoryReaderHashSet.GetFiles())
            {
                UI.Write(item);
            }
        }
    }
}