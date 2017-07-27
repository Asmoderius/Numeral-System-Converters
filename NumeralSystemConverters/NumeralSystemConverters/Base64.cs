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
    public static class Base64
    {
        private const String Base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

        /*
         * Function that converts from Base10 to Base64.
         * Input: Int n - Number in Base10
         * Output: String - Number in base64.
         * */
        public static string Base10ToBase64(int n)
        {
            string s = string.Empty;
            while(n > 0)
            {
                byte remainder = (byte)(n % 64);
                s = Base64Chars[remainder] + s;
                n /= 64;
            }
            return s;
        }

        /*
         * Function that converts from Base64 to Base10.
         * Input: Int n - Number in Base10
         * Output: String - Number in base64.
         * */
        public static int Base64ToBase10(string s)
        {
            int n = 0;
            int base_Val = 1;
            for (int i = s.Length-1; i >= 0; i--)
            {
                n += Base64Chars.IndexOf(s[i]) * base_Val;
                base_Val *= 64;
            }
            return n;
        }

        /*
         * Function that converts from Base16 to Base64.
         * Input: String HexString - Number in Base16
         * Output: String - Number in base64.
         * Calls the Base16.ToByteArray function to convert HexString into a ByteArray. 
         * */
        public static string Base16ToBase64(string hexString)
        {
            return Base16ToBase64(Base16.ToByteArray(hexString));
        }

        /*
         * Function that converts from Base16 to Base64.
         * Input: ByteArray containing a number in Base16. 
         * Output: String - Number in base64.
         * */
        public static string Base16ToBase64(byte[] hexByteArray)
        {
            if (hexByteArray.Length > 0)
            {
                uint n;
                byte n0, n1, n2, n3;
                string base64String = "";

                int padCount = hexByteArray.Length % 3;
                for (int i = 0; i < hexByteArray.Length; i += 3)
                {
                    n = (uint)hexByteArray[i] << 16;

                    if (i + 1 < hexByteArray.Length)
                    {
                        n += (uint)hexByteArray[i + 1] << 8;
                    }

                    if (i + 2 < hexByteArray.Length)
                    {
                        n += (uint)hexByteArray[i + 2];
                    }

                    n0 = (byte)(n >> 18 & 63);
                    n1 = (byte)(n >> 12 & 63);
                    n2 = (byte)(n >> 6 & 63);
                    n3 = (byte)(n & 63);

                    base64String += Base64Chars[n0];
                    base64String += Base64Chars[n1];
                    if (i + 1 < hexByteArray.Length)
                    {
                        base64String += Base64Chars[n2];
                    }
                    if (i + 2 < hexByteArray.Length)
                    {
                        base64String += Base64Chars[n3];
                    }

                }
                if (padCount > 0)
                {
                    for (; padCount < 3; padCount++)
                    {
                        base64String += "=";
                    }
                }
                return base64String;
            }
            else
            {
                return "Failure - Cannot convert an empty Byte Array";
            }
        }

    }
}
