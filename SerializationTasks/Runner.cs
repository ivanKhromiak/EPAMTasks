using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SerializationTasks
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
            var cars = new List<Car>();
            cars.Add(new Car("BMV", 50000));
            cars.Add(new Car("Opel", 20000));
            cars.Add(new Car("Nissan", 40000));

            var binarySerialization = new BinarySerialization("cars.bin", cars.GetType());
            var xmlSerialization = new XMLSerialization("cars.xml", cars.GetType());
            var jsonSerialization = new JSONSerialization("cars.txt", cars.GetType());

            binarySerialization.Serialize(cars);
            xmlSerialization.Serialize(cars);
            jsonSerialization.Serialize(cars);

            var carsFromBinary = (List<Car>)binarySerialization.Deserialize();
            var carsFromXML = (List<Car>)xmlSerialization.Deserialize();
            var carsFromJSON = (List<Car>)jsonSerialization.Deserialize();
        }
    }
}
