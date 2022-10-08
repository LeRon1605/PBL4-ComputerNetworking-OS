using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp.Translator
{
    public class FrenchTranslator : ITranslator
    {
        private static readonly string[] digits = { "zéro", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit",
        "neuf", "dix","onze ", "douze", "treize", "quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf"};

        private static readonly string[] dozens = { "vingt", "trente", "quarante", "cinquante", "soixante", "soixante-dix", "quatre-vingts", "quatre-vingt-dix" };

        private static readonly string[] denom = { "", "" , "mille", "million", "milliard", "billion", "billiard", "trillion",
        "trilliard", "quadrillion", "quadrilliard", "quintillion", "quintilliard", "sextillion", "sextilliard", "septillion",
        "septilliard", "octillion", "octilliard", "nonillion", "nonilliard", "décillion", "décilliard", "undecillion", "undecilliard",
        "duodecillion", "duodecilliard", "tredecillion", "tredecilliard", "quattuordecillion", "quattuordecilliard", "quindecillion", "quindecilliard",
        "sexdecillion", "sexdecilliard", "septdecillion", "septdecilliard"};
        public string convert_xx(string number)
        {
            double _number = Convert.ToDouble(number);
            if (_number < 20)
            {
                return digits[Convert.ToInt32(_number)];
            }
            for (int i = 0; i < dozens.Length; i++)
            {
                string dezon = dozens[i];
                double value = 20 + 10 * i;
                if (value + 10 > _number)
                {
                    if ((_number % 10) != 0)
                    {
                        return dezon + "-" + digits[Convert.ToInt32(_number) % 10];
                    }
                    return dezon;
                }
            }
            return "";
        }
        public string convert_xxx(string number)
        {
            double _number = Convert.ToSingle(number);
            string result = "";
            int rem = Convert.ToInt32(Math.Floor(_number / 100));
            int mod = Convert.ToInt32(_number % 100);
            if (rem > 0)
            {
                result = digits[rem] + " cent";
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

        public string TranslateNumber(string number)
        {

            string result = "";

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
                double dval = Convert.ToDouble(Math.Pow(1000, v));
                if (dval > _number)
                {
                    double mod = (double)(Math.Pow(1000, v - 1));
                    int l = Convert.ToInt32(Math.Floor(_number / mod));
                    double r = _number - (l * mod);
                    result = convert_xxx(l.ToString()) + " " + denom[v];
                    if (r > 0)
                    {
                        result = result + ", " + TranslateNumber(r.ToString());
                    }
                    return char.ToUpper(result[0]) + result.Substring(1);
                }
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


            if (number[0] == '-')
            {
                number = number.Substring(1);
                return "Moins " + Translate(number);
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
                    for (int j = 0; j < numberSplit.Count; j++)
                    {
                        subNumber += "000";
                    }
                    numberSplit.Add(subNumber);
                    count = 0;
                }
            }

            string result = "";

            for (int i = numberSplit.Count - 1; i >= 0; i--)
            {
                if (i != 0)
                {
                    result += TranslateNumber(numberSplit[i]) + ", ";
                }
                else
                {
                    result += TranslateNumber(numberSplit[i]);
                }
            }
            return char.ToUpper(result[0]) + result.Substring(1);
        }
    }
}
