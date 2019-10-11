using System;

namespace TasksExceptions
{
    internal class ExceptionCaller
    {
        internal static void DoStackOverflowException()
        {
            throw new StackOverflowException();
        }

        internal static void DoIndexOutOfRangeException()
        {
            int[] array = { 4, 7 };
            int sum = array[0] + array[1] + array[2];
        }

        internal static void DoSomeMath(int a, int b)
        {
            if (a < 0)
            {
                throw new ArgumentException("Parameter should be greater than 0", "a");
            }
            if (b > 0)
            {
                throw new ArgumentException("Parameter should be less than 0", "b");
            }
        }
    }
}
