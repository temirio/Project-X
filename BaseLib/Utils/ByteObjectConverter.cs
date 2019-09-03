using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace BaseLib.Utils
{
    public class ByteObjectConverter : IObjectConverter<byte[]>
    {
        public byte[] ObjectToValueConverter(object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public object ValueToObjectConverter(byte[] value)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                ms.Write(value, 0, value.Length);
                ms.Seek(0, SeekOrigin.Begin);
                return bf.Deserialize(ms);
            }
        }
    }
}
