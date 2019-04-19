using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace UserMgt.Utils
{
    public class ObjectSerializer<T>
    {
        public byte[] ToByteArray(T obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public T FromByteArray(byte[] bytes)
        {
            if (bytes == null)
                return default(T);

            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                T obj = (T) bf.Deserialize(ms);
                return obj;
            }
        }
    }
}
