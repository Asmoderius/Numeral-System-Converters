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
    public static class Base16
    {
        private const string hexValues = "0123456789ABCDEF";
         /*
         * Converts from Base10 (Decimal) to Base 16 (HexiDecimal).
         * Input: int n - A number in Base 10.
         * Output: String - Converted hexidecimal string 
         **/
        public static string Base10ToBase16(int n)
        {
            string hex = String.Empty;
            while(n > 0)
            {
                byte remainder = (byte)(n % 16);
                hex = hexValues[remainder] + hex;
                n /= 16;
            }
            return hex;
        }

        /*
         * Converts from Base16 (Hexidecimal) to Base 10 (Decimal).
         * Input: String h - A number in Base 16.
         * Output: int - Converted number as an integer. 
         **/
        public static int Base16ToBase10(string h)
        {
            int n = 0;
            int base_Val = 1;
            for (int i = h.Length-1; i >= 0; i--)
            {
                n += hexValues.IndexOf(h[i]) * base_Val;
                base_Val *= 16;
            }
            return n;
        }

        /*
         * Function that converts a hexidecimal number given as a string to a Byte Array.
         **/
        public static byte[] ToByteArray(string h)
        {
            h = h.Replace("-", "");
            byte[] results = new byte[h.Length / 2];
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = Convert.ToByte(h.Substring(i * 2, 2), 16);
            }
            return results;
        }

        /*
         * Function that converts a Byte Array to a hexidecimal number.
         **/
        public static string FromByteArray(byte[] array)
        {
            string s = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                s += ConvertByteToHex(array[i]);
            }
            return s;

        }

        /*
         * Helper function that converts a byte into two hexidecimal values. 
         * This has be made for "giggles" as C# contains methods which does the same. Lookup Convert.ToString(array[i], 16)
         * */
        private static string ConvertByteToHex(byte b)
        {
            string s = String.Empty;
            byte b1 = (byte)(b >> 4);
            byte b2 = (byte)(b & 0xF);
   
            if (b1 != 0)
                s += hexValues[b1];

            s += hexValues[b2];
            return s;
        }


    }
}
