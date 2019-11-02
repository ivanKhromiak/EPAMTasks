using System;
using System.Collections.Generic;
using System.Text;

namespace IOTasks
{
    public class RunnerIOTasks: UserInterface.IRunnable
    {
        private UserInterface.IUserInterface UI;

        private NLog.ILogger _logger;

        public RunnerIOTasks(UserInterface.IUserInterface UI, NLog.ILogger Logger)
        {
            this.UI = UI;
            _logger = Logger;
        }

        public void Run()
        {
            var fileReader = new DirectoryReader();
            UI.Write("Enter path:");
            string path = UI.Read();
            var contentFormDirectory = new List<string>();
            try
            {
                contentFormDirectory = fileReader.GetContentFromDirectory(path);
            }
            catch (ArgumentException e)
            {
                _logger.Error(e);
            }

            foreach (var item in contentFormDirectory)
            {
                UI.Write(item);
            }

            var searchingTxtInDirectory = new SearchingTxtInDirectory();
            UI.Write("Enter path:");
            path = UI.Read();
            UI.Write("Enter name of .txt:");
            string name = UI.Read();
            List<string> foundedTxt = searchingTxtInDirectory.SearchTxtInDirectory(path, name);

            foreach (var item in foundedTxt)
            {
                UI.Write(item);
            }
        }
    }
}
