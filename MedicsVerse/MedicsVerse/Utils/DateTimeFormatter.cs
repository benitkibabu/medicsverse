// DateTimeFormatter.cs
// Author:  benitkibabu 
// Date: 07/09/2022
using System;
namespace MedicsVerse.Utils
{
    public class DateTimeFormatter
    {
        private const string TODAY = "Today";
        private const string DATE_MONTH_FORMAT = "MMM dd";
        private const string DATE_MONTH_TIME_FORMAT = "MMM dd, HH:mm";
        private const string DATE_MONTH_YEAR_FORMAT = "MMM dd, yyyy";

        public static readonly string FULL_DATE_FORMAT = "MMM dd, yyyy";
        public static readonly string FULL_DATETME_FORMAT = "MMM dd, yyyy, HH:mm:ss";

        public DateTimeFormatter()
        {
        }

        public static string ShortDate(string dateString)
        {
            DateTime dateTime = Convert.ToDateTime(dateString);
            string date = dateTime.ToShortDateString();

            return date;
        }

        public static string ShortDate(string dateString, string format)
        {
            DateTime dateTime = Convert.ToDateTime(dateString);
            string date = dateTime.ToString(format);

            return date;
        }

        public static string LongDate(string dateString)
        {
            DateTime dateTime = Convert.ToDateTime(dateString);
            string date = dateTime.ToLongDateString();

            return date;
        }

        public static string ConvertT(DateTime date)
        {
            if (date.Equals(DateTime.Today))
            {
                return TODAY;
            }
            else if (date.Year == DateTime.Now.Year)
            {
                return date.ToString(DATE_MONTH_FORMAT);
            }

            return date.ToString(DATE_MONTH_YEAR_FORMAT);
        }

        public static string GetDateTimeString(DateTime date)
        {
            if (date.Equals(DateTime.Today))
            {
                return TODAY;
            }
            else if (date.Year == DateTime.Now.Year)
            {
                return date.ToString(DATE_MONTH_FORMAT);
            }

            return date.ToString(DATE_MONTH_YEAR_FORMAT);
        }

        public static string GetLongDateTimeString(DateTime date)
        {
            if (date.Equals(DateTime.Today))
            {
                return TODAY;
            }

            return date.ToString(FULL_DATETME_FORMAT);
        }

        public static string GetMonthTimeString(DateTime date)
        {
            if (date.Equals(DateTime.Today))
            {
                return TODAY;
            }

            return date.ToString(DATE_MONTH_TIME_FORMAT);
        }
    }
}

