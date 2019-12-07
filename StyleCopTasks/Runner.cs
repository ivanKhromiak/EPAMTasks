using System;
using System.Collections.Generic;
using System.Text;
using UserInterface;

namespace StyleCopTasks
{
    class Runner : IRunnable
    {
        private IUserInterface _ui;

        public Runner(UserInterface.IUserInterface UI)
        {
            _ui = UI;
        }

        public void Run()
        {
            var rectangleA = new Rectangle(new Point(0.0, 0.0), new Point(5.0, 5.0));
            var rectangleB = new Rectangle(new Point(0.0, 4.0), new Point(10.0, 10.0));

            _ui.Write(rectangleA.ToString());
            _ui.Write(rectangleB.ToString());

        }
    }
}
