using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.neuralab.utilities
{
    public static class MathAndNumbersUtils
    {
        public static string roundedTwoDecimalPlacesString(string decNum)
        {
            //This method is used when returning decimal numbers directly from database. MSSQL DB actually returns string representation so hence the parsing to decimal insdide this method///////////////////////////

            decimal dn = decimal.Parse(decNum);

            return Math.Round(dn, 2).ToString();
        }


        public static string generateNumStringWithDots(string numWithoutDots)
        {
            //The method accepts string numbers with comma as a decimal delimiter

            string returnString = "";

            string[] parts = numWithoutDots.Split(',');

            char[] firstPart = parts[0].ToCharArray();

            int lastPos = firstPart.Length - 1;

            int counter = 1;

            while (lastPos > -1)
            {
                if ((counter % 3 == 0) && (lastPos > 0))
                {
                    returnString = returnString.Insert(0, "." + firstPart[lastPos].ToString());
                }
                else
                {
                    returnString = returnString.Insert(0, firstPart[lastPos].ToString());
                }

                lastPos--;
                counter++;
            }


            if (parts.Length == 1)
            {
                returnString = returnString + ",00";
            }
            else
            {
                returnString = returnString + "," + parts[1];
            }

            return returnString;
        }
    }
}
