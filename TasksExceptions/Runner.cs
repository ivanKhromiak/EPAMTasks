using System;
using System.Collections.Generic;
using System.Text;

namespace TasksExceptions
{
    public class Runner
    {
        private UserInterface.IUserInterface UI;

        public Runner(UserInterface.IUserInterface UI)
        {
            this.UI = UI;
        }

        public void RunTask4()
        {
            try
            {
                ExceptionCaller.DoStackOverflowException();
                ExceptionCaller.DoIndexOutOfRangeException();
            }
            catch (StackOverflowException e)
            {
                UI.Write(e.Message);
            }
            catch(IndexOutOfRangeException e)
            {
                UI.Write(e.Message);
            }
        }

        public void RunTask5()
        {
            try
            {
                ExceptionCaller.DoSomeMath(-8, 10);
            }
            catch(ArgumentException e)
            when (e.ParamName == "a")
            {
                UI.Write(e.Message);
            }
            catch (ArgumentException e)
            when (e.ParamName == "b")
            {
                UI.Write(e.Message);
            }
        }
    }
}
