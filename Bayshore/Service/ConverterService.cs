using System;

namespace Bayshore.Service
{
    public class ConverterService : IConverterService
    {
        public string ConvertIntoWords(decimal incomingNumber)
        {
            var convertedNumToString = incomingNumber.ToString();
            var checkForDecimal = convertedNumToString.Split('.');

            if (checkForDecimal.Length > 1)
            {              
                return ConvertIntoWords(Convert.ToInt64(checkForDecimal[0])) + " and " + checkForDecimal[1] + "/100";
            }
            else
            {
                return ConvertIntoWords(Convert.ToInt64(incomingNumber));
            }
        }


        public string ConvertIntoWords(long number)
        {
            if (number < 0) return "minus " + ConvertIntoWords(Math.Abs(number));

            string words = string.Empty;
            if ((number / 1000000000) > 0)
            {
                words = words + ConvertIntoWords(number / 1000000000) + " billion ";
                number = number % 1000000000;
            }
            if ((number / 1000000) > 0)
            {
                words = words + ConvertIntoWords(number / 1000000) + " million ";
                number = number % 1000000;
            }
            if ((number / 1000) > 0)
            {
                words = words + ConvertIntoWords(number / 1000) + " thousand ";
                number = number % 1000;
            }
            if ((number / 100) > 0)
            {
                words = words + ConvertIntoWords(number / 100) + " hundred ";
                number = number % 100;
            }
            if (number > 0)
            {
                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
                if (number < 20)
                {
                    words = words + unitsMap[number];
                }
                else
                {
                    words = words + tensMap[number / 10];

                    if ((number % 10) > 0)  words = words + " " + unitsMap[number % 10];                 
                }
            }
          
            return words;
        }
    }
}
