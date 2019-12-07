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

        public Rectangle BuildSmallestFromTwoRectangels(Rectangle second)
        {
            var A = new Point(MinX(this, second), MinY(this, second));
            var C = new Point(MaxX(this, second), MaxY(this, second));

            return new Rectangle(A, C);
        }

        public Rectangle BuildІntersectionOfTwoRectangels(Rectangle second)
        {
            if (IsIntersected(this, second))
            {
                double[] xArray = { this.A.X, this.C.X, second.A.X, second.C.X };
                double[] yArray = { this.A.Y, this.C.Y, second.A.Y, second.C.Y };
                Array.Sort(xArray);
                Array.Sort(yArray);
                return new Rectangle(new Point(xArray[2], yArray[2]), new Point(xArray[1], yArray[1]));
            }
            return null;
        }

        private static bool IsIntersected(Rectangle first, Rectangle second)
        {
            return (second.A.Y + second.Height) > first.A.Y && (first.A.X + first.Width) > second.C.X;
        }

        private static double MaxX(Rectangle first, Rectangle second)
        {
            return Math.Max(first.C.X, second.C.X);
        }

        private static double MaxY(Rectangle first, Rectangle second)
        {
            return Math.Max(first.C.Y, second.C.Y);
        }

        private static double MinX(Rectangle first, Rectangle second)
        {
            return Math.Min(first.C.X, second.C.X);
        }

        private static double MinY(Rectangle first, Rectangle second)
        {
            return Math.Min(first.C.Y, second.C.Y);
        }
    }
}
