using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.neuralab.utilities
{
    public static class DateTimeUtils
    {
        //Check if given year is a leap year//////////////////////////////////////////////////////////////////////

        public static bool IsLeapYear(int year)
        {
            if (year % 4 != 0)
            {
                return false;
            }
            if (year % 100 == 0)
            {
                return (year % 400 == 0);
            }
            return true;
        }


        //Method generates string for online date-dependant filenaming (usefull if you want to save large number of files online ... i.e. images, pdfs... that can be public)////////////////////////////////////////////

        public static string generateStringFromDate()
        {
            DateTime dt = DateTime.Now;

            string dts = dt.Year.ToString() + "x" + dt.Month.ToString() + "x" + dt.Day.ToString() + "x" + dt.Hour.ToString() + "x" + dt.Minute.ToString() + "x" + dt.Second.ToString() + "x" + dt.Millisecond.ToString();

            return dts;
        }



        //UNIX time handlers // TO and FROM///////////////////////////////////////////////////////////////////////

        public static DateTime getDetTimeFromUNIXtime(int numberOfSeconds)
        {
            DateTime basicDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime newDate = basicDate.AddSeconds(numberOfSeconds);

            return newDate;
        }

        public static int getUNIXtimeFromDateTime(DateTime dateTime)
        {
            DateTime basicDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime newDate = dateTime;

            TimeSpan ts = newDate.Subtract(basicDate);


            return ts.Days * 24 * 60 * 60;
        }
    }
}
