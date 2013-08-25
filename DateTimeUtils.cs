using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net_Neuralab_Utilities
{
    class DateTimeUtils
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

        //same as method above but original from Microsoft and more simplified
        //DateTime.IsLeapYear(insertSomeYear)

        //my implementation of method generates string for online date-dependant filenaming (usefull if you want to save large number of files online ... i.e. images, pdfs... that can be public)////////////////////////////////////////////
        //usage: GenerateStringFromDate(" - ");
        public static string StringFromDateTime(string dateStringSplitter)
        {
            DateTime dt = DateTime.Now;
            return string.Concat(dt.Year.ToString(), dateStringSplitter, dt.Month.ToString(), dateStringSplitter, dt.Day.ToString(), dateStringSplitter, dt.Hour.ToString(), dateStringSplitter, dt.Minute.ToString(), dateStringSplitter, dt.Second.ToString(), dateStringSplitter, dt.Millisecond.ToString());
        }

        //Time handler method is used when you want to add 0 if minutes or seconds smaller then 10
        //usage: TimeFormatHandler(1, 9) returns: 01:09
        public static string TimeFormatHandler(double min, double sec)
        {
            return string.Concat((min < 10 ? "0" : ""), min, ":", (sec < 10 ? "0" : ""), sec);
        }

        //UNIX time handlers // TO and FROM///////////////////////////////////////////////////////////////////////

        private static readonly DateTime basicDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        public static DateTime getDetTimeFromUNIXtime(int numberOfSeconds)
        {
            return basicDate.AddSeconds(numberOfSeconds);
        }

        public static int getUNIXtimeFromDateTime(DateTime dateTime)
        {
            return dateTime.Subtract(basicDate).Days * 24 * 60 * 60;
        }
    }
}
