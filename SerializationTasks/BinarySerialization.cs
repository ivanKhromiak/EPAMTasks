using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationTasks
{
    class BinarySerialization : ISerialization
    {
        public string FileName { get; set; }

        public Type SerializeType { get; set; }

        public BinarySerialization(string fileName, Type serializeType)
        {
            FileName = fileName;
            SerializeType = serializeType;
        }

        public void Serialize(object obj)
        {
            using (FileStream fs = new FileStream(FileName, FileMode.Create))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, obj);
            }
        }

        public object Deserialize()
        {
            using (FileStream fs = new FileStream(FileName, FileMode.Open))
            {
                var bf = new BinaryFormatter();
                return bf.Deserialize(fs);
            }
        }
    }
}
