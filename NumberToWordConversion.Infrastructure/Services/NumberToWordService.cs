using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConversion.Infrastructure.Services
{
    public class NumberToWordService:INumberToWordService
    {
        private static readonly string[] ones = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private static readonly string[] teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private static readonly string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private static readonly string[] powerOfTens = { "", "Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion" };

        public string Convert(decimal number)
        {
            StringBuilder words = new StringBuilder();

            long wholeNumber = (long)number;
            words.Append(ConvertToWords(wholeNumber) + " dollars");

            if (number.ToString().Contains("."))
            {
                long decimalNumber = long.Parse(number.ToString().Split(".")[1]);
                if (decimalNumber > 0)
                {
                    words.Append(" and " + ConvertToWords(decimalNumber) + " cents");
                }
            }
            

            return words.ToString();
        }

        private static string ConvertToWords(long number)
        {
            StringBuilder words = new StringBuilder();
            int powerIndex = 0;

            while (number > 0)
            {
                if (number % 1000 != 0)
                {
                    if (!words.Equals(""))
                    {
                        words = new StringBuilder(ConvertToWordsUnderThousand(number % 1000) + " " + powerOfTens[powerIndex] + " " + words);
                    }
                    else
                    {
                        words = new StringBuilder(ConvertToWordsUnderThousand(number % 1000) + " " + powerOfTens[powerIndex]);
                    }
                }

                number /= 1000;
                powerIndex++;
            }

            return words.ToString().Trim();
        }

        private static string ConvertToWordsUnderThousand(long number)
        {
            StringBuilder words = new StringBuilder();

            if (number >= 100)
            {
                words.Append(ones[number / 100] + " Hundred");
                number %= 100;
                if (number > 0)
                {
                    words.Append(" and ");
                }
            }

            if (number > 0)
            {
                if (number < 20)
                {
                    words.Append((!words.Equals("") ? " " : "") + (number < 10 ? ones[number] : teens[number - 10]));
                }
                else
                {
                    words.Append((!words.Equals("") ? " " : "") + tens[number / 10]);
                    if (number % 10 > 0)
                    {
                        words.Append("-" + ones[number % 10]);
                    }
                }
            }

            return words.ToString();
        }



    }
}

