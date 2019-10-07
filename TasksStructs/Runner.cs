using System;

namespace TasksStructs
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
            UI.Write("Enter Name:");
            string name = UI.Read();

            UI.Write("Enter Surname:");
            string surname = UI.Read();

            int age;
            UI.Write("Enter Age:");
            int.TryParse(UI.Read(), out age);

            var person = new Person() { Name = name, Surname = surname, Age = age };

            UI.Write("Enter the comparative age:");
            int comparativeAge;
            int.TryParse(UI.Read(), out comparativeAge);
            UI.Write($"{person.CompareAge(comparativeAge)}");

            UI.Write("Enter X coordinate:");
            double x;
            double.TryParse(UI.Read(), out x);

            UI.Write("Enter Y coordinate:");
            double y;
            double.TryParse(UI.Read(), out y);

            UI.Write("Enter Height:");
            double heigth;
            double.TryParse(UI.Read(), out heigth);

            UI.Write("Enter Width:");
            double width;
            double.TryParse(UI.Read(), out width);

            var rectangle = new Rectangle()
            {
                X = x,
                Y = y,
                Height = heigth,
                Width = width
            };

            UI.Write($"Perimeter of rectangle: {rectangle.GetPerimeter(rectangle.Width, rectangle.Height)}");
        }
    }
}
