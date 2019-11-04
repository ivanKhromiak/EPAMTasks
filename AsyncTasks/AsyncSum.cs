using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace AsyncTasks
{
    class AsyncSum
    {
        public static int Sum(int[,] numbers)
        {
            var parallelSums = new int[10];
            int parts = numbers.GetLength(0) / 10;
            Parallel.For(0, 10, (counter) =>
            {
                int sum = 0;

                for (int i = counter * parts; i < (counter + 1) * parts; i++)
                {
                    for (int j = 0; j < numbers.GetLength(1); j++)
                    {
                        sum += numbers[i, j];
                    }
                }

                parallelSums[counter] = sum;
            });

            return parallelSums.Sum();
        }
    }
}
