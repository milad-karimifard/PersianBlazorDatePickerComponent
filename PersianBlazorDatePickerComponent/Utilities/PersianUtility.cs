using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;

namespace PersianBlazorDatePickerComponent.Utilities
{
    internal class PersianUtility
    {
        public static string GetMonthName(int number)
        {
            switch (number)
            {
                case 1:
                    return "فروردین";
                case 2:
                    return "اردیبهشت";
                case 3:
                    return "خرداد";
                case 4:
                    return "تیر";
                case 5:
                    return "مرداد";
                case 6:
                    return "شهریور";
                case 7:
                    return "مهر";
                case 8:
                    return "آبان";
                case 9:
                    return "آذر";
                case 10:
                    return "دی";
                case 11:
                    return "بهمن";
                case 12:
                    return "اسفند";
                default:
                    return "";
            }
        }

        public static string ConvertToPersianCalender(DateTime date)
        {
            PersianCalendar ps = new PersianCalendar();
            return ps.GetYear(date).ToString("0000") + "/" + ps.GetMonth(date).ToString("00") + "/" + ps.GetDayOfMonth(date).ToString("00");
        }

        public static T GetMonth<T>(DateTime date)
        {
            PersianCalendar ps = new PersianCalendar();
            int month = ps.GetMonth(date);

            if (typeof(T) == typeof(string))
            {
                return (T)Convert.ChangeType(GetMonthName(month), typeof(T));
            }
            else if (typeof(T) == typeof(int))
            {
                return (T)Convert.ChangeType(month, typeof(T));
            }
            return default(T);
        }

        public static T GetYear<T>(DateTime date)
        {
            PersianCalendar ps = new PersianCalendar();

            if (typeof(T) == typeof(string))
            {
                return (T)Convert.ChangeType(ps.GetYear(date).ToString("0000"), typeof(T));
            }
            else if (typeof(T) == typeof(int))
            {
                return (T)Convert.ChangeType(ps.GetYear(date), typeof(T));
            }
            return default(T);
        }

        public static int GetDaysOfMonth(DateTime date)
        {
            PersianCalendar ps = new PersianCalendar();
            return ps.GetDayOfMonth(date);
        }

        public static int GetDaysInMonth(DateTime date)
        {
            var ps = new PersianCalendar();

            int year = ps.GetYear(date);
            int month = ps.GetMonth(date);

            return ps.GetDaysInMonth(year, month);
        }

        public static bool IsToday(DateTime selectedDate, DateTime currentDate, int item, string mode)
        {
            try
            {
                int currentYear = GetYear<int>(currentDate);
                int currentMonth = GetMonth<int>(currentDate);
                int currentDay = GetDaysOfMonth(currentDate);


                if (mode == "day")
                {
                    int year = GetYear<int>(selectedDate);
                    int month = GetMonth<int>(selectedDate);

                    return currentYear == year && currentMonth == month && currentDay == item;
                }
                else if (mode == "month")
                {
                    int year = GetYear<int>(selectedDate);

                    return year == currentYear && currentMonth == item;
                }
                else
                {
                    return currentYear == item;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool IsDateTimeInRange(DateTime date, DateTime min, DateTime max, int day)
        {
            try
            {
                DateTime currentDate = new DateTime(date.Year, date.Month, day);

                return min <= currentDate && currentDate <= max;
            }
            catch
            {
                int difrence = DateTime.DaysInMonth(date.Year, date.Month);

                DateTime currentDate = new DateTime(date.Year, date.Month + 1, (day - difrence));

                return min <= currentDate && currentDate <= max;
            }
        }
    }
}
