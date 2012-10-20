using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net_Neuralab_Utilities
{
    class MathAndNumbersUtils
    {
        //This method is used when returning decimal numbers directly from database. MSSQL DB actually returns string representation so hence the parsing to decimal insdide this method///////////////////////////

        public static string roundedTwoDecimalPlacesString(string decNum)
        {
            decimal dn = decimal.Parse(decNum);

            return Math.Round(dn, 2).ToString();
        }
    }
}
