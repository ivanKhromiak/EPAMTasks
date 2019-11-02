using System;
using System.Collections.Generic;
using System.Text;

namespace TasksEnums
{
    public class Runner: UserInterface.IRunnable
    {
        private UserInterface.IUserInterface UI;

        public Runner(UserInterface.IUserInterface UI)
        {
            this.UI = UI;
        }

        public void Run()
        {
            UI.Write("Write number");
            int number;
            int.TryParse(UI.Read(), out number);
            UI.Write($"{(Months)number}");

            Colors colors = Colors.Blue;
            colors.GetSortedColors();

            UI.Write($"The values of LongRange enum:");
            foreach (var item in Enum.GetValues(typeof(LongRange)))
            {
                UI.Write($"{item}");
            }
        }
    }
}
