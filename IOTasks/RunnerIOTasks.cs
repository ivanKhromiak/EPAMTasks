using System;
using System.Collections.Generic;
using System.Text;

namespace IOTasks
{
    public class RunnerIOTasks
    {
        private UserInterface.IUserInterface UI;

        public RunnerIOTasks(UserInterface.IUserInterface UI)
        {
            this.UI = UI;
        }

        public void Run()
        {
            var fileReader = new DirectoryReader();
            UI.Write("Enter path:");
            string path = UI.Read();
            List<string> contentFormDirectory = fileReader.GetContentFromDirectory(path);
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
