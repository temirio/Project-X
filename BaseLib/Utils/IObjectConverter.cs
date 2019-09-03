using System;
using System.Collections.Generic;
using System.Text;

namespace BaseLib.Utils
{
    public interface IObjectConverter<T>
    {
        T ObjectToValueConverter(object obj);

        object ValueToObjectConverter(T value);
    }
}
