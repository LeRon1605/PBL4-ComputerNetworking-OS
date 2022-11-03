using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp.Translator
{
    public class SpanishTranslator : ITranslator
    {
        private static readonly string[] digits = {"cero", "un", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho",
        "nueve", "diez","once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve", "veinte",
        "veintiuno", "veintidós", "veintitrés", "veinticuatro", "veinticinco", "veintiséis", "veintisiete", "veintiocho", "veintinueve"};

        private static readonly string[] dozens = {"treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa"};

        private static readonly string[] hundreds = {"", "cien", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos",
        "setecientos", "ochocientos", "novecientos"};

        private static readonly string[] unitsSingluler = {"", "" ,"millón", "", "billón", "", "trillón", "", "cuatrillón", "", "quintillón",
        "", "sextillón", "", "septillón", "", "octillón"};

        private static readonly string[] units = {"", "mil",  "millones", "", "billones", "", "trillones", "", "cuatrillones", "", "quintillones",
        "", "sextillones", "", "septillones", "", "octillones" };

        public string convert_xx(string number)
        {
            double _number = Convert.ToDouble(number);
            if (_number < 30)
            {
                return digits[Convert.ToInt32(_number)];
            }
            for (int i = 0; i < dozens.Length; i++)
            {
                string dozen = dozens[i];
                double value = 30 + 10 * i;
                if (value + 10 > _number)
                {
                    if ((_number % 10) != 0)
                    {
                        return dozen + " y " + digits[Convert.ToInt32(_number) % 10];
                    }
                    return dozen;
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
                if (rem == 1 && mod > 0)
                {
                    result = hundreds[rem] + "to";
                }
                else
                {
                    result = hundreds[rem];
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
            if (_number < 1000000)
            {
                for (int v = 0; v < units.Length; v++)
                {
                    int didx = v - 1;
                    double dval = Convert.ToDouble(Math.Pow(1000, v));
                    if (dval > _number)
                    {
                        double mod = (double)(Math.Pow(1000, didx));
                        int l = Convert.ToInt32(Math.Floor(_number / mod));
                        double r = _number - (l * mod);

                        if (l == 1)
                        {
                            result = units[didx];
                        }
                        else
                        {
                            result = convert_xxx(l.ToString()) + " " + units[didx];
                        }
                        if (r > 0)
                        {
                            result = result + " " + TranslateNumber(r.ToString());
                        }
                        return char.ToUpper(result[0]) + result.Substring(1);
                    }
                }
            }
            for (int v = 0; v < units.Length; v++)
            {
                if( v % 2 == 1 )
                {
                    int didx = v - 1;
                    double dval = Convert.ToDouble(Math.Pow(1000, v));
                    if (dval > _number)
                    {
                        double mod = (double)(Math.Pow(1000, didx));
                        int l = Convert.ToInt32(Math.Floor(_number / mod));
                        double r = _number - (l * mod);

                        if ( l == 1)
                        {
                            result = digits[1] + " "  + unitsSingluler[didx];
                        }
                        else
                        {
                            result = convert_xxx(l.ToString()) + " " + units[didx];
                        }
                        if (r > 0)
                        {
                            result = result + " " + TranslateNumber(r.ToString());
                        }
                        return char.ToUpper(result[0]) + result.Substring(1);
                    }
                }
                else
                {
                    int didx = v - 2;
                    double dval = Convert.ToDouble(Math.Pow(1000, v));
                    if (dval > _number)
                    {
                        double mod = (double)(Math.Pow(1000, didx));
                        int l = Convert.ToInt32(Math.Floor(_number / mod));
                        double r = _number - (l * mod);
                        result = TranslateNumber(l.ToString()) + " " + units[didx];
                        if (r > 0)
                        {
                            result = result + " " + TranslateNumber(r.ToString());
                        }
                        return char.ToUpper(result[0]) + result.Substring(1);
                    }
                }
            }
            return result;
        }
        public string Translate(string number)
        {
            number = number.Trim();

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
                if (count % 6 == 0 || i == 0)
                {
                    string subNumber = number.Substring(i, count);
                    for (int j = 0; j < numberSplit.Count; j++)
                    {
                        subNumber += "000000";
                    }
                    numberSplit.Add(subNumber);
                    count = 0;
                }
            }

            // Negative number
            if (isNegative)
            {
                return "Menos " + Translate(number);
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
