using System;
using System.Collections.Generic;
using System.Text;

namespace Calculation
{
    public class Runner: UserInterface.IRunnable
    {
        public void Run()
        {
            var calc = new Calculation.Calc();

            int Addition(int x, int y)
            {
                return x + y;
            }

            Calculation.IWriter ui = new Calculation.ConsoleCalc();
            int result = calc.calculation(int.Parse(ui.Read()), int.Parse(ui.Read()), Addition);
            ui.Write(result.ToString());

            ui = new Calculation.FileCalc();
            result = calc.calculation(int.Parse(ui.Read()), int.Parse(ui.Read()), Addition);
            ui.Write(result.ToString());
        }
    }
}
