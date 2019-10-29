using System;
using System.IO;
using Newtonsoft.Json;

namespace SerializationTasks
{
    class JSONSerialization : ISerialization
    {
        public string FileName { get; set; }

        public Type SerializeType { get; set; }

        public JSONSerialization(string fileName, Type serializeType)
        {
            FileName = fileName;
            SerializeType = serializeType;
        }

        public void Serialize(object obj)
        {
            using (var fs = new StreamWriter(FileName))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(fs, obj);
            }
        }

        public object Deserialize()
        {
            throw new NotImplementedException();
        }
    }
}
