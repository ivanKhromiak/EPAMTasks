using System;

namespace StyleCopTasks
{
    class Rectangle
    {
        public Point A { get; private set; }

        public Point B { get; private set; }

        public Point C { get; private set; }

        public Point D { get; private set; }

        public int Height
        {
            get
            {
                return B.Y - A.Y;
            }
        }

        public int Width
        {
            get
            {
                return C.X - A.X;
            }
        }

        public Rectangle(Point a, Point c)
        {
            if (A.X != D.X || B.X != D.X)
            {
                throw new ArgumentException("Rectangle is not parallel to the x-axis");
            }

            if (A.Y != B.Y || C.Y != D.Y)
            {
                throw new ArgumentException("Rectangle is not parallel to the y-axis");
            }

            A = a;
            B = new Point(a.X, c.Y);
            C = c;
            D = new Point(c.X, a.Y);
        }

        public void Move(int lenght = 0, int height = 0)
        {
            A.X += lenght;
            B.X += lenght;
            C.X += lenght;
            D.X += lenght;

            A.Y += height;
            B.Y += height;
            C.Y += height;
            D.Y += height;
        }

        public void ChangeSize(int lenght = 0, int height = 0)
        {
            D.X += lenght;
            C.X += lenght;

            B.Y += height;
            C.Y += height;
        }
    }
}
