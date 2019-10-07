using System;
using System.Collections.Generic;
using System.Text;

namespace TasksStructs
{
    interface ISize
    {
        double Width { get; set; }

        double Height { get; set; }

        double GetPerimeter(double width, double height);
    }
}
