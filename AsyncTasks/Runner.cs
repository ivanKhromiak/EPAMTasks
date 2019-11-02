using System;
using System.Linq;

namespace AsyncTasks
{
    public class Runner
    {
        private UserInterface.IUserInterface UI;

        public Runner(UserInterface.IUserInterface UI)
        {
            this.UI = UI;
        }

        public void Run()
        {
            UI.Write("Enter n:");
            int n;
            int.TryParse(UI.Read(), out n);
            UI.Write("Enter m:");
            int m;
            int.TryParse(UI.Read(), out m);
            var random = new Random();

            var numbers = new int[n, m];
            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    numbers[i, j] = random.Next(0, 1000);
                }
            }

            int sum = AsyncSum.Sum(numbers);
            int compererSum = numbers.Cast<int>().Sum();
            if(sum == compererSum)
            {
                UI.Write("Its correct");
            }
            else
            {
                UI.Write("Its not correct, right answer is:" + compererSum.ToString());
            }
            UI.Write(sum.ToString());
        }
    }
}
