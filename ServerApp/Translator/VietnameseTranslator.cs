using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp.Translator
{
    public class VietnameseTranslator : ITranslator
    {
        private static readonly string[] units = { "", "mươi", "trăm", "nghìn", "triệu", "tỷ" };
        private static readonly string[] digits = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
        public string Translate(string number)
        {
            // Trim and remove lead zero
            number = number.Trim().TrimStart('0').PadLeft(1, '0');

            // Empty string
            if (string.IsNullOrEmpty(number))
            {
                return null;
            }

            if (number == "0")
            {
                return "Không";
            }

            string result = "";
            int count = 0;
            bool isTailZero = true;

            for (int i = 0; i < number.Length; i++)
            {
                int j = number.Length - i - 1;
                if (number[j] < '0' || number[j] > '9')
                {
                    return null;
                }
                if (count == 3)
                {
                    isTailZero = true;
                    count = 0;
                    Console.WriteLine(i);
                    switch (i % 9)
                    {
                        case 0:
                            result = "tỷ " + result;
                            break;
                        case 3:
                            result = "nghìn " + result;
                            break;
                        case 6:
                            result = "triệu " + result;
                            break;
                    }
                }

                string digit = digits[number[j] - '0'];

                if (number[j] != '0')
                {
                    isTailZero = false;
                }

                if (!isTailZero)
                {
                    if (count == 1 && number[j] == '0')
                    {
                        result = "lẻ " + result;
                    }
                    else if (count == 1 && number[j] == '1')
                    {
                        result = "mười " + result;
                    }
                    else
                    {
                        string unit = (count == 0) ? " " : " " + units[count] + " ";
                        result = digit + unit + result;
                    }
                }

                count++;
            }

            return char.ToUpper(result[0]) + result.Substring(1);
        }
    }
}
