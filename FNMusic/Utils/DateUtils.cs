using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FNMusic.Utils
{
    public class DateUtils
    {
        private static readonly string[] months = new string[]
        {
            "January",
            "Febuary",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"
        };


        public static string GetMonth(int value)
        {
            return months[value - 1].ToString();
        }
    }
}
