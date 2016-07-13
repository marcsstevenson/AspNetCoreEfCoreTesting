using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Generic.Framework.Helpers.DateAndTime
{
    public static class WeekHelper
    {
        public static int WeeksBetween(this DateTime startDate, DateTime endDate, bool daysFullInclusive = true, bool roundUp = true)
        {
            var daysBetween = startDate.Subtract(endDate).TotalDays;
            if (daysFullInclusive) daysBetween++; //For example, days between the same datetime = 1
            var weeksBetween = (daysBetween / 7);
            
            return Convert.ToInt32(roundUp ? System.Math.Ceiling(weeksBetween) : System.Math.Round(weeksBetween, 0, MidpointRounding.AwayFromZero));
        }


        public static List<string> GetDayOfWeeksForCurrentCulture()
        {
            return GetDayOfWeeksForCulture(CultureInfo.CurrentCulture);
        }

        public static List<string> GetDayOfWeeksForCulture(CultureInfo cultureInfo)
        {
            return EnumHelper.EnumToList<DayOfWeek>().Select(dayOfWeek => GetDayOfWeekNameForCulture(cultureInfo, dayOfWeek)).ToList();
        }

        public static string GetDayOfWeekNameForCurrentCulture(DayOfWeek dayOfWeek)
        {
            return GetDayOfWeekNameForCulture(CultureInfo.CurrentCulture, dayOfWeek);
        }

        /// <summary>
        /// Returns the day name for a given culture and DayOfWeek value
        /// </summary>
        /// <param name="cultureInfo">The culture to translate</param>
        /// <param name="dayOfWeek">The day of the week. Eg Friday</param>
        public static string GetDayOfWeekNameForCulture(CultureInfo cultureInfo, DayOfWeek dayOfWeek)
        {
            return cultureInfo.DateTimeFormat.GetDayName(dayOfWeek);
        }
    }
}