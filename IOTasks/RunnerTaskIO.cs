using System;
using System.Collections.Generic;
using System.Text;

namespace IOTasks
{
    public class RunnerTaskIO
    {
        private UserInterface.IUserInterface UI;

        public RunnerTaskIO(UserInterface.IUserInterface UI)
        {
            this.UI = UI;
        }

        public void Run()
        {
            var fileReader = new FileReader(UI);
            UI.Write("Enter path:");
            string path = UI.Read();
            fileReader.showInfoDirectory(path);
        }
    }
}
