using System;
using System.Collections.Generic;
using System.Text;

namespace StyleCopTasks
{
    class Circle
    {
        public Point Center { get; private set; }

        public double Radius { get; private set; }

        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public void Move(int lenght, int height)
        {
            Center.X += lenght;
            Center.Y += height;
        }

        public void ChangeSize(double lenght)
        {
            Radius += lenght;
        }
    }
}
