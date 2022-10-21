using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Utils.Formatter
{
    public class NumberFormatter : IFormatter
    {
        public string Format(object value)
        {
            string number = (string)value;
            // Remove space
            number = number.Trim();

            // Empty string
            if (string.IsNullOrEmpty(number))
            {
                return null;
            }

            bool isNegative = false;
            if (number[0] == '-')
            {
                isNegative = true;
                number = number.Substring(1);  
            }
            
            number = number.TrimStart('0').PadLeft(1, '0');
            string result = "";
            for (int i = 0;i < number.Length;i++)
            {
                if (number[i] < '0' || number[i] > '9') return (string)value;
                if (i != 0 && (number.Length - i) % 3 == 0)
                {
                    result += ".";
                }
                result += number[i];
            }

            return isNegative ? "-" + result : result;
        }
    }
}
