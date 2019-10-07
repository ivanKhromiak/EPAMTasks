using System;
using System.Collections.Generic;
using System.Text;

namespace TasksStructs
{
    struct Rectangle: ISize, ICoordinates
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double GetPerimeter ( double width, double height)
        {
            return (width * 2) + (height * 2);  
        }
    }
}
