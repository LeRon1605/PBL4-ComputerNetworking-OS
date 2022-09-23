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

            // Remove lead zero number
            number = number.TrimStart('0').PadLeft(1, '0');

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
                    if ((i >= 9 && i % 9 == 0) || number[j] != '0' || number[j - 1] != '0' || number[j - 2] != '0')
                    {
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
                    isTailZero = true;
                    count = 0;
                }

                string digit = digits[number[j] - '0'];

                if (number[j] != '0')
                {
                    isTailZero = false;
                }

                if (!isTailZero)
                {
                    bool isSpecialCase = false;
               
                    if (count == 0 && j - 1 >= 0  && number[j - 1] != '0')
                    {
                        // x(x/{0, 1})(1) -> 1: mốt
                        if (number[j] == '1' && number[j - 1] != '1')
                        {
                            isSpecialCase = true;
                            result = "mốt " + result;
                        }

                        // x(x/{0})(5) -> 5: lăm
                        if (number[j] == '5')
                        {
                            isSpecialCase = true;
                            result = "lăm " + result;
                        }
                    }

                    if (count == 1)
                    {
                        // x(0)x -> 0: lẻ
                        if (number[j] == '0')
                        {
                            isSpecialCase = true;
                            result = "lẻ " + result;
                        }

                        // x(1)x: 1: mười
                        if (number[j] == '1')
                        {
                            isSpecialCase = true;
                            result = "mười " + result;
                        }
                    }

                    if (!isSpecialCase)
                    {
                        string unit = (count == 0) ? " " : " " + units[count] + " ";
                        result = digit + unit + result;
                    }
                }

                count++;
            }

            if (isNegative)
            {
                result = "âm " + result;
            }

            return char.ToUpper(result[0]) + result.Substring(1, result.Length - 2);
        }
    }
}
