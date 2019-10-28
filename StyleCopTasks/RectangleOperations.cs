using System;
using System.Collections.Generic;
using System.Text;

namespace StyleCopTasks
{
    class RectangleOperations
    {
        public static Rectangle BuildSmallestFromTwoRectangels(Rectangle first, Rectangle second)
        {
            var A = new Point(MinX(first, second), MinY(first, second));
            var C = new Point(MaxX(first, second), MaxY(first, second));

            return new Rectangle(A, C);
        }

        public static Rectangle BuildІntersectionOfTwoRectangels(Rectangle first, Rectangle second)
        {
            if (IsIntersected(first, second))
            {
                int[] xArray = { first.A.X, first.C.X, second.A.X, second.C.X };
                int[] yArray = { first.A.Y, first.C.Y, second.A.Y, second.C.Y };
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

        private static int MaxX(Rectangle first, Rectangle second)
        {
            return Math.Max(first.C.X, second.C.X);
        }

        private static int MaxY(Rectangle first, Rectangle second)
        {
            return Math.Max(first.C.Y, second.C.Y);
        }

        private static int MinX(Rectangle first, Rectangle second)
        {
            return Math.Min(first.C.X, second.C.X);
        }

        private static int MinY(Rectangle first, Rectangle second)
        {
            return Math.Min(first.C.Y, second.C.Y);
        }
    }
}
