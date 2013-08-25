﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Net_Neuralab_Utilities
{
    class TextStringUtils
    {
        //Static method will generate a random string in given length from hardcoded dictionary//////////////////////////////////////

        public static string generateRandomString(int length)
        {
            string dictionary = "abcdefghijklmnopqrstuvwxyz01234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            Random random = new Random();

            return new string(
                        Enumerable.Repeat(dictionary, length) // Numbers are possible values //
                                  .Select(s => s[random.Next(s.Length)])
                                  .ToArray());
        }



        /*Static method will generate a random string in 11-letter length from hardcoded dictionary. It will be suitable for windows admin passwords as the straing will include numbers,
         * LARGE letters and small letters.
         */

        public static string generateRandomStringforWindowsPasswords()
        {
            string dictionarysmall = "abcdefghijklmnopqrstuvwxyz";
            string dictionaryLARGE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string dictionaryNum = "01234567890";

            Random random1 = new Random();

            string keysmall = new string(
                        Enumerable.Repeat(dictionarysmall, 4) // Numbers are possible values //
                                  .Select(s => s[random1.Next(s.Length)])
                                  .ToArray());


            Random random2 = new Random();

            string keysLARGE = new string(
                        Enumerable.Repeat(dictionaryLARGE, 4) // Numbers are possible values //
                                  .Select(s => s[random2.Next(s.Length)])
                                  .ToArray());


            Random random3 = new Random();

            string keysNum = new string(
                        Enumerable.Repeat(dictionaryNum, 3) // Numbers are possible values //
                                  .Select(s => s[random3.Next(s.Length)])
                                  .ToArray());


            string original = keysmall + keysNum + keysLARGE;

            // The random number sequence for shufling
            Random num = new Random();

            // Create new string from the reordered char array
            string rand = new string(original.ToCharArray().
                OrderBy(s => (num.Next(2) % 2) == 0).ToArray());

            return rand;
        }

        
        //Method checks if given string is valid VAT number. Tested for Croatian usage////////////////////////////////////
        public static bool checkOIB(string oib)
        {
            if (oib.Length != 11) return false;

            long b;

            if (!long.TryParse(oib, out b)) return false;

            int a = 10;

            for (int i = 0; i < 10; i++)
            {
                a = a + Convert.ToInt32(oib.Substring(i, 1));
                a = a % 10;
                if (a == 0) a = 10;
                a *= 2;
                a = a % 11;
            }

            int controlNum = 11 - a;

            if (controlNum == 10) controlNum = 0;

            return controlNum == Convert.ToInt32(oib.Substring(10, 1));
        } 


        //Method checks if given straing is a valid email address///////////////////////////////////////////////////////////
        //my implementation
        private static Regex emailRegex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", RegexOptions.Compiled);
        public static bool checkEmailValidation(string emailToCheck)
        {
            return emailRegex.IsMatch(emailToCheck);
        }

        //Method is used when you want to remove illegal characters from path or string because filename cannot contain question marks for example
        //for example: RemoveIllegalCharacters("what is your name?") returns: what is your name
        public static string RemoveIllegalCharacters(string text)
        {
            return Path.GetInvalidFileNameChars().Aggregate(text, (current, c) => current.Replace(c.ToString(), string.Empty));
        }
    }
}
