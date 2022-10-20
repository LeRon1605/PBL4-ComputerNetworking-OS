using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace ServerApp.Translator
{
    public class FrenchTranslator : ITranslator
    {
        private static readonly string[] digits = {"zéro", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit",
        "neuf", "dix","onze", "douze", "treize", "quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf"};

        private static readonly string[] dozens = {"vingt", "trente", "quarante", "cinquante", "soixante", "soixante-dix", "quatre-vingt", "quatre-vingt-dix" };

        private static readonly string[] units = {"", "mille", "million", "milliard", "billion", "billiard", "trillion",
        "trilliard", "quadrillion", "quadrilliard", "quintillion", "quintilliard", "sextillion", "sextilliard", "septillion",
        "septilliard", "octillion", "octilliard", "nonillion", "nonilliard", "décillion", "décilliard", "undecillion", "undecilliard",
        "duodecillion", "duodecilliard", "tredecillion", "tredecilliard", "quattuordecillion", "quattuordecilliard", "quindecillion", "quindecilliard",
        "sexdecillion", "sexdecilliard", "septdecillion", "septdecilliard"};

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
                        if(_number >= 70 && _number < 100)
                        {
                            if(_number < 80)
                            {
                                if (_number % 10 == 1)
                                {
                                    return dozen + " et " + digits[(_number % 10) + 10];
                                }
                                else
                                {
                                    return dozen + "-" + digits[(_number % 10) + 10];
                                }
                            }
                            else if (_number < 90)
                            {
                                return dozen + "-" + digits[_number % 10];
                            }
                            else
                            {
                                dozen = dozens[i - 1];
                                return dozen + "-" + digits[(_number % 10) + 10];
                            }

                        }
                        if(_number % 10 == 1)
                        {
                            return dozen + " et " + digits[_number % 10];
                        }
                        else
                        {
                            return dozen + "-" + digits[_number % 10];
                        }   
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
                if(rem == 1)
                {
                    result = "cent";
                }
                else
                {
                    result = digits[rem] + " cent";
                }
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

        public string HandlerNumber(string number)
        {

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
                return "Minos " + Translate(number);
            }

            string result = "";

            for (int i = numberSplit.Count - 1; i >= 0; i--)
            {
                if (i == 1)
                {
                    if (HandlerNumber(numberSplit[i]) == "Zéro")
                    {
                        result += "";
                    }
                    else
                    {

                    }
                    {
                        if(HandlerNumber(numberSplit[i]) == "Un")
                        {
                            result += units[i] + ", ";

                        }
                        else
                        {
                            result += HandlerNumber(numberSplit[i]) + " " + units[i] + ", ";
                        }
                    }
                }
                else if (i != 0 && i != 1)
                {
                    if (HandlerNumber(numberSplit[i]) == "Zéro")
                    {
                        result += "";
                    }
                    else
                    {
                        if (HandlerNumber(numberSplit[i]) == "Un")
                        {
                            result += HandlerNumber(numberSplit[i]) + " " + units[i] + ", ";


                        }
                        else
                        {
                            result += HandlerNumber(numberSplit[i]) + " " + units[i] + "s, ";
                        }
                    }
                }
                else
                {
                    if (HandlerNumber(numberSplit[i]) == "Zéro")
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
