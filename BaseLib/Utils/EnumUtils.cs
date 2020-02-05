using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

        public static string GetEnumDefaultPropertyValue(int i)
        {
            var enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }

            var memberInfos = enumType.GetMember(GetEnumValueByInt(i).ToString());
            var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
            var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DefaultValueAttribute), false);
            var value = ((DefaultValueAttribute)valueAttributes[0]).Value;
            return value.ToString();
        }
    }
}
