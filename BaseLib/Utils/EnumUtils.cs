using System;
using System.Collections.Generic;
using System.Text;

namespace BaseLib.Utils
{
    public class EnumUtils<T> where T : struct, IConvertible
    {

        public static T GetEnumValueByInt(int num)
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }

            T val = ((T[])Enum.GetValues(typeof(T)))[0];

            foreach (T enumValue in (T[])Enum.GetValues(typeof(T)))
            {
                if (Convert.ToInt32(enumValue).Equals(num))
                {
                    val = enumValue;
                    break;
                }
            }

            return val;
        }
    }
}
