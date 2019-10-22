using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionTasks
{
    public class ReflectionTasksRunner
    {
        private UserInterface.IUserInterface UI;

        public ReflectionTasksRunner(UserInterface.IUserInterface UI)
        {
            this.UI = UI;
        }

        public void Run()
        {
            var assemblyInfo = new AssemblyInfo();
            UI.Write("Enter path:");
            string path = UI.Read();
            List<string> assemblyStringInfo = assemblyInfo.GetAssemblyInfo();
            foreach (var item in assemblyStringInfo)
            {
                UI.Write(item);
            }
        }
    }
}
