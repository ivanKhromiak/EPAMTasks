using System;
using System.IO;
using System.Xml.Serialization;

namespace SerializationTasks
{
    class XMLSerialization : ISerialization
    {
        public string FileName { get; set; }

        public Type SerializeType { get; set; }

        public XMLSerialization(string fileName, Type serializeType)
        {
            FileName = fileName;
            SerializeType = serializeType;
        }

        public void Serialize(object obj)
        {
            using (FileStream fs = new FileStream(FileName, FileMode.Create))
            {
                var xs = new XmlSerializer(SerializeType);
                xs.Serialize(fs, obj);
            }
        }

        public object Deserialize()
        {
            using (FileStream fs = new FileStream(FileName, FileMode.Open))
            {
                var xs = new XmlSerializer(SerializeType);
                return xs.Deserialize(fs);
            }
        }
    }
}
