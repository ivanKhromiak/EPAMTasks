using System;

namespace StyleCopTasks
{
    class Rectangle
    {
        public Point A { get; private set; }

        public Point B { get; private set; }

        public Point C { get; private set; }

        public Point D { get; private set; }

        public double Height
        {
            get
            {
                return B.Y - A.Y;
            }
        }

        public double Width
        {
            get
            {
                return C.X - A.X;
            }
        }

        public override string ToString()
        {
            return $"Coordinates of regtangle is {A.X}:{A.Y}, {B.X}:{B.Y}, {C.X}:{C.Y}, {D.X}:{D.Y}";
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

        public void Move(double lenght = 0, double height = 0)
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

        public void ChangeSize(double lenght = 0, double height = 0)
        {
            D.X += lenght;
            C.X += lenght;

            B.Y += height;
            C.Y += height;
        }
    }
}
