using System;
using System.Collections.Generic;
using System.Text;

namespace SerializationTasks
{
    interface ISerialization
    {
        string FileName { get; set; }

        Type SerializeType { get; set; }

        void Serialize(object obj);

        object Deserialize();
    }
}
