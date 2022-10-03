using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ServerApp.Translator
{
    public class EnglishTranslator : ITranslator
    {
        private static readonly string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight",
        "nine", "ten","eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};

        private static readonly string[] units = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};  
        
        private static readonly string[] denom = { "", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion", 
        "sextillion", "septillion", "octillion", "nonillion", "decillion", "undecillion", "duodecillion", "tredecillion", 
        "quattuordecillion", "sexdecillion", "septendecillion", "octodecillion", "novemdecillion", "vigintillion" };
        
        public string convert_xx(string number)
        {
            double _number = Convert.ToDouble(number);
            if (_number < 20)
            {
                return digits[Convert.ToInt32(_number)];    
            }
            for (int i = 0; i < units.Length; i++)
            {
                string unit = units[i];
                double value = 20 + 10 * i;
                if (value + 10 > _number)
                {
                    if ((_number % 10) != 0)
                    {
                        return unit + "-" + digits[Convert.ToInt32(_number) % 10];
                    }
                    return unit;
                }
            }
            throw new Exception();
        }
        public string convert_xxx(string number)
        {
            double _number = Convert.ToSingle(number);
            string result = "";
            int rem = Convert.ToInt32(Math.Floor(_number / 100));
            int mod = Convert.ToInt32(_number % 100);
            if (rem > 0)
            {
                result = digits[rem] + " hundred";
                if (mod > 0)
                {
                    result = result + " ";
                }
            }
            if (mod > 0)
            {
                result = result + convert_xx(mod.ToString());
            }
            return result;
        }
        public string Translate(string number)
        {
            string result = "";

            if (number[0] == '-')
            {
                number = number.Substring(1);
                return "Minus " + Translate(number);
            }

            double _number = Convert.ToDouble(number);

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
            for (int v = 0; v < denom.Length; v++)
            {
                int didx = v - 1;
                double dval = Convert.ToDouble(Math.Pow(1000, v));
                if (dval > _number)
                {
                    double mod = (double)(Math.Pow(1000, didx));
                    int l = Convert.ToInt32(Math.Floor(_number / mod));
                    double r = _number - (l * mod);
                    result = convert_xxx(l.ToString()) + " " + denom[didx];
                    if (r > 0)
                    {
                        result = result + ", " + Translate(r.ToString());
                    }
                    return char.ToUpper(result[0]) + result.Substring(1);
                }
            }
            throw new Exception();
        }
    }
}
