using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
/*
 * Author: Louis Fleron
 * Year: 2017
 * Reason: Refreshing Computer Science. 
 * This code is distributed under GNU General Public License version 3.0
 * */
namespace NumeralSystemConverters
{
    /*
     * Static class for converting Base2. 
     * */
    public static class Base2
    {
        /*
         * Converts from Base10 (Decimal) to Base 2 (Binary).
         * Input: int n - A number in Base 10.
         * Output: String - Converted binary string 
         **/
        public static string Base10ToBase2(int n)
        {
            string b = String.Empty;
            while(n > 0)
            {
                int remainder = n % 2;
                b = remainder + b;
                n /= 2;
            }
            return b;
        }

        /*
         * Converts from Base2 to Base10.
         * Input: Int b - A binary number - max 32 bits.
         * Output: Converted number in Base10. 
         * */
        public static int Base2ToBase10(int b)
        {
            int n = 0;
            int base_val = 1;
            while(b > 0)
            {
                int remainder = b % 10;
                n = n + base_val * remainder;
                b /= 10;
                base_val *= 2;
            }
            return n;
        }

        /*
         * Converts from Base2 to Base10.
         * Input: Binary string to be converted.
         * Output: Converted number in Base10. Note BigInteger as output due to input being a string which is of arbitrary length. 
         * */
        public static BigInteger Base2ToBase10(string b)
        {
            BigInteger n = 0;
            int base_val = 1;
            for (int i = b.Length-1; i >= 0; i--)
            {
                int bit = b[i] - '0';
                n += base_val * bit;
                base_val *= 2;
            }
            return n;
        }

        /*
         * Method to convert a binary string into a BitArray. 
         * */
        public static BitArray ToBitArray(string b)
        {
            BitArray bitArray = new BitArray(b.Length);
            for (int i = 0; i < b.Length; i++)
            {
                bitArray[i] = (b[i] == '1') ? true : false;
            }
            return bitArray;
        }
    }
}
