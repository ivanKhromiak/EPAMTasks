﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Logger
{
    public class FileLog
    {
        private static readonly string path = @"C:\Users\Ivan\source\repos\EPAMTasks\Log.txt";

        public static void WriteLog(string messege)
        {
            if (!File.Exists(path))
            {
                using (FileStream filestream = File.Create(path)) { };
            }

            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine(messege);
            }
        }
    }
}
