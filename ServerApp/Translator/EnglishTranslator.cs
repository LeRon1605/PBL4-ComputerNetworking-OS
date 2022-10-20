using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ServerApp.Translator
{
    public class EnglishTranslator : ITranslator
    {
        private static readonly string[] digits = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight",
        "nine", "ten","eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};

        private static readonly string[] dozens = {"twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};  
        
        private static readonly string[] units = {"", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion", 
        "sextillion", "septillion", "octillion", "nonillion", "decillion", "undecillion", "duodecillion", "tredecillion", 
        "quattuordecillion", "quindecillion", "sexdecillion", "septendecillion", "octodecillion", "novemdecillion", "vigintillion", "unvigintillion", 
        "duovigintillion", "trevigintillion", "quattuorvigintillion", "quinvigintillion", "sexvigintillion", "septenvigintillion", "octovigintillion", 
        "novemvigintillion", "trigintillion", "untrigintillion", "duotrigintillion", "tretrigintillion", "quattuortrigintillion"};
        
        public string convert_xx(string number)
        {
            int _number = Convert.ToInt32(number);
            if (_number < 20)
            {
                return digits[_number];    
            }
            for (int i = 0; i < dozens.Length; i++)
            {
                string dozen = dozens[i];
                int value = 20 + 10 * i;
                if (value + 10 > _number)
                {
                    if ((_number % 10) != 0)
                    {
                        return dozen + "-" + digits[_number % 10];
                    }
                    return dozen;
                }
            }
            return "";
        }
        public string convert_xxx(string number)
        {
            int _number = Convert.ToInt32(number);
            string result = "";
            int rem = _number / 100;
            int mod = _number % 100;
            if (rem > 0)
            {
                result = digits[rem] + " hundred";
                if (mod > 0)
                {
                    result = result + " and ";
                }
            }
            if (mod > 0)
            {
                result = result + convert_xx(mod.ToString());
            }
            return result;
        }
        public string HandlerNumber(string number)
        {

            number = number.TrimStart('0').PadLeft(1, '0');

            string result = "";

            int _number = Convert.ToInt32(number);

            if (_number < 100)
            {
                result = convert_xx(number);
                return char.ToUpper(result[0]) + result.Substring(1);
            }
            if (_number < 1000)
            {
                result = convert_xxx(number);
                return char.ToUpper(result[0]) + result.Substring(1);
            }
            return "";
        }

        public string Translate(string number)
        {
            // Remove space
            number = number.Trim();

            // Empty string
            if (string.IsNullOrEmpty(number))
            {
                return null;
            }

            number = number.TrimStart('0').PadLeft(1, '0');

            bool isNegative = false;
            if (number[0] == '-')
            {
                number = number.Substring(1);
                isNegative = true;
            }

            List<string> numberSplit = new List<string>();
            int count = 0;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (number[i] < '0' || number[i] > '9')
                {
                    return null;
                }
                count++;
                if (count % 3 == 0 || i == 0)
                {
                    string subNumber = number.Substring(i, count);
                    numberSplit.Add(subNumber);
                    count = 0;
                }
            }
            
            // Negative number
            if (isNegative)
            {
                return "Minus " + Translate(number);
            }

            string result = "";

            for (int i = numberSplit.Count - 1; i >= 0; i--)
            {
                if (i != 0)
                {
                    if (HandlerNumber(numberSplit[i]) == "Zero")
                    {
                        result += "";
                    }
                    else
                    {
                        result += HandlerNumber(numberSplit[i]) + " " + units[i] + ", ";
                    }
                }
                else
                {
                    if (HandlerNumber(numberSplit[i]) == "Zero")
                    {
                        result += "";
                    }
                    else
                    {
                        result += HandlerNumber(numberSplit[i]);
                    }
                }
            }
            return char.ToUpper(result[0]) + result.Substring(1);
        }
    }
}