using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SerializationTasks
{
    [DataContract]
    [Serializable]
    public class Car
    {
        [DataMember]
        [XmlElement]
        public string Name { get; set; }

        [DataMember]
        [XmlElement]
        public int Price { get; set; }

        public Car()
        {
            Name = "Noname";
            Price = 0;
        }

        public Car(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
