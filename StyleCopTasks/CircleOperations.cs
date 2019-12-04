using System;
using System.Collections.Generic;
using System.Text;

namespace StyleCopTasks
{
    class CircleOperations
    {
        static public Circle BuildSmallestFromTwoCircles(Circle first, Circle second)
        {
            var center = new Point((first.Center.X + second.Center.X) / 2, (first.Center.Y + second.Center.Y) / 2);

            var radius = Math.Sqrt(Math.Pow((second.Center.X - first.Center.X), 2) + Math.Pow((second.Center.Y - first.Center.Y), 2));

            radius += Math.Max(first.Radius, second.Radius);

            return new Circle(center, radius);
        }
    }
}
