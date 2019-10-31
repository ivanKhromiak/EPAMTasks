using System;

namespace Calculation
{
    public class Calc
    {
        public int calculation(int x, int y, Func<int, int, int> func)
        {
            return func(x, y);
        }
    }
}
