using System;
using System.Collections.Generic;
using System.Text;
using UserInterface;

namespace StyleCopTasks
{
    class Runner : IRunnable
    {
        private readonly IUserInterface _ui;

        public Runner(UserInterface.IUserInterface UI)
        {
            _ui = UI;
        }

        public void Run()
        {
            var rectangleA = new Rectangle(new Point(0.0, 0.0), new Point(5.0, 5.0));
            var rectangleB = new Rectangle(new Point(0.0, 4.0), new Point(10.0, 10.0));

            _ui.Write("Rectangle A:" + rectangleA.ToString());
            _ui.Write("Rectangle B:" + rectangleB.ToString());

            _ui.Write("Changing size of rectangle A on 4.0 and 1.0:");
            rectangleA.ChangeSize(4.0, 1.0);
            _ui.Write(rectangleA.ToString());

            _ui.Write("Moving rectangle B on 2.0 and 1.5:");
            rectangleB.Move(2.0, 1.5);
            _ui.Write(rectangleA.ToString());

            _ui.Write("Smallest from rectangles A and B:");
            _ui.Write(rectangleA.BuildSmallestFromTwoRectangels(rectangleB).ToString());

            _ui.Write("Intersections of rectangles A and B:");
            _ui.Write(rectangleA.BuildІntersectionOfTwoRectangels(rectangleB).ToString());
        }
    }
}
