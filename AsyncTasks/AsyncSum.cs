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
            var parallelSums = new int[11];
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

            if (numbers.GetLength(0) % 10 == 0) return parallelSums.Sum();

            var thread = new Thread(RemainsSum);
            thread.Start();
            thread.Join();
            return parallelSums.Sum();

            void RemainsSum()
            {
                for (var i = parts * 10; i < numbers.GetLength(0); i++)
                {
                    for (var j = 0; j < numbers.GetLength(1); j++)
                    {
                        parallelSums[10] += numbers[i, j];
                    }
                }
            }
        }
    }
}
