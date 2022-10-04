using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp.Translator
{
    public class SpanishTranslator : ITranslator
    {
        private static readonly string[] digits = { "cero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho",
        "nueve", "diez","once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve", "veinte",
        "veintiuno", "veintidós", "veintitrés", "veinticuatro", "veinticinco", "veintiséis", "veintisiete", "veintiocho", "veintinueve"};

        private static readonly string[] dozens = { "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };

        private static readonly string[] units = { "", "cien", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos",
        "setecientos", "ochocientos", "novecientos" };

        private static readonly string[] denom = { "", "mil",  "millones", "", "billones", "", "trillones" };

        private static readonly string[] denomSingluler = {"", "" ,"millón", "", "billón", "", "trillón" };
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
                    result = units[rem] + "to";
                }
                else
                {
                    result = units[rem];
                }
                if (mod > 0)
                {
                    result = result + " ";
                }
            }
            if (mod > 0)
            {
                digits[1] = "un";
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
                return "Menos " + Translate(number);
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
            if (_number < 1000000)
            {
                for (int v = 0; v < denom.Length; v++)
                {
                    int didx = v - 1;
                    double dval = Convert.ToDouble(Math.Pow(1000, v));
                    if (dval > _number)
                    {
                        double mod = (double)(Math.Pow(1000, didx));
                        int l = Convert.ToInt32(Math.Floor(_number / mod));
                        double r = _number - (l * mod);
                        digits[1] = "un";

                        if (l == 1)
                        {
                            result = denom[didx];
                        }
                        else
                        {
                            result = convert_xxx(l.ToString()) + " " + denom[didx];
                        }
                        if (r > 0)
                        {
                            result = result + " " + Translate(r.ToString());
                        }
                        return char.ToUpper(result[0]) + result.Substring(1);
                    }
                }
            }
            for (int v = 0; v < denom.Length; v++)
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
                        digits[1] = "un";

                        if ( l == 1)
                        {
                            result = digits[1] + " "  + denomSingluler[didx];

                        }
                        else
                        {
                            result = convert_xxx(l.ToString()) + " " + denom[didx];

                        }
                        if (r > 0)
                        {
                            result = result + " " + Translate(r.ToString());
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
                        result = Translate(l.ToString()) + " " + denom[didx];
                        if (r > 0)
                        {
                            result = result + " " + Translate(r.ToString());
                        }
                        return char.ToUpper(result[0]) + result.Substring(1);
                    }
                }
            }
            return "";
        }
    }
}
