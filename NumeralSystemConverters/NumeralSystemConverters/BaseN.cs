using System;
using System.Collections.Generic;
using System.Text;
/*
 * Author: Louis Fleron
 * Year: 2017
 * Reason: Refreshing Computer Science. 
 * This code is distributed under GNU General Public License version 3.0
 * */
namespace NumeralSystemConverters
{
    public static class BaseN
    {
        /*
         * Converts from BaseN to Base10.
         * Input: String in baseN, int BaseN which indicates the base, string baseValues - a string that holds all possible symbols in the given base.
         * Output: Converted number in Base10. 
         * */
        public static int BaseNToBase10(string b, int baseN, string baseValues)
        {
            int n = 0;
            int base_Val = 1;
            for (int i = b.Length-1; i >= 0; i--)
            {
                n += baseValues.IndexOf(b[i]) * base_Val;
                base_Val *= baseN;
            }
            return n;
        }

        /*
         * Converts a Base10 number to BaseN where N is given as input parameter.
         * Input: Int n - a number in base10. Int baseN - The base to be converted into. String baseValues - a string that holds all possible symbols in the given base. 
         * */
        public static string Base10ToBaseN(int n, int baseN, string baseValues)
        {
            string s = string.Empty;
            while(n > 0)
            {
                int remainder = n & baseN;
                s = baseValues[remainder] + s;
                n /= baseN;
            }
            return s;
        }

        /*
         * Converts from BaseN to BaseM without going through Base10.
         * Note that mod and division operations are integer-based. 
         * Input: String s - a number in BaseN. Int baseN - the base to be converted from. BaseM - The base to be converted into. 
         * Output: Converted number in BaseM given as a string. 
         * */
        public static string BaseNToBaseM(string s, int baseN, int baseM)
        {
            //String that holds the new number in Base M
            string newNumber = string.Empty;

            //While number in base N is not empty or rather is not 0.
            while (s != "0")
            {
                //Remainder is how much of Base M we can get out of the number in Base N.
                int remainder = 0;
                //Divide number in Base N by base M. Returns number in Base N but divided by Base M. Thus the need for a While loop as more divisions may be possible. 
                s = Divide(s, baseN, baseM, out remainder);
                char newDigit = ValueToDigit(remainder);
                //Add value defined by remainder to number in base M. 
                newNumber = newDigit + newNumber;
            }

            if (newNumber == string.Empty)
                newNumber = "0";

            return newNumber;
        }

        /*
         * Helper function to BaseNToBaseM.
         * Input: String number - Number to be divided. Int baseN - The base to be converted from. Int baseM - The base to be converted into. 
         * Int Remainder - The remainder of the division. Returned through out keyword. 
         * */
        private static string Divide(string number, int baseN, int baseM, out int remainder)
        {
            string result = string.Empty;
            remainder = 0;
            //Iterate through the entire number. 
            for (int i = 0; i < number.Length; i++)
            {
                int digitValue = DigitToValue(number[i]);
                //Calculate value of the digit at index i by BaseN 
                remainder = baseN * remainder + digitValue;
                //Divide the value by Base M. If remainder is less than baseM, newDigitValue will be zero. 
                int newDigitValue = remainder/baseM;
                //Calculate the remainder of division by Base M. 
                remainder = remainder % baseM;
                //If there is a new value of digit such that it is greater than zero, save it to string result. Result will become the new string s in BaseNToBaseM method.
                //Only if result is not empty will zeroes be added. Thus preventing leading zeroes. 
                if (newDigitValue > 0 || result != string.Empty)
                {
                    char newDigit = ValueToDigit(newDigitValue);
                    result = result + newDigit;
                }
            }

            if (result == string.Empty)
                result = "0";
            return result;
 
        }

        private static int DigitToValue(char digit)
        {

            int value = 0;

            if (digit >= '0' && digit <= '9')
                value = digit - '0';
            else 
                value = digit - 'A' + 10;

            return value;

        }

        private static char ValueToDigit(int value)
        {

            char digit = '\0';

            if (value < 10)
                digit = (char)('0' + value);
            else
                digit = (char)('A' + (value - 10));

            return digit;

        }

    }
}
