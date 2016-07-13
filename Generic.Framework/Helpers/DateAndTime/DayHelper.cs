using System;
using System.Collections.Generic;
using System.Globalization;

namespace Generic.Framework.Helpers.DateAndTime
{
    public static class DayHelper
    {
        public static List<string> GetDaysForCurrentCulture()
        {
            return GetDaysForCulture(CultureInfo.CurrentCulture);
        }

        public static List<string> GetDaysForCulture(CultureInfo cultureInfo)
        {
            var dayNames = new List<string>();

            for (var i = 1; i <= 7; i++)
                dayNames.Add(GetDayNameForCulture(cultureInfo, (DayOfWeek)i));

            return dayNames;
        }

        public static string GetDayNameForCurrentCulture(DayOfWeek dayOfWeek)
        {
            return GetDayNameForCulture(CultureInfo.CurrentCulture, dayOfWeek);
        }

        /// <summary>
        /// Returns the day name for a given culture and day number
        /// </summary>
        /// <param name="cultureInfo">The culture to translate</param>
        /// <param name="dayOfWeek">The number of the day. Eg January = 1</param>
        public static string GetDayNameForCulture(CultureInfo cultureInfo, DayOfWeek dayOfWeek)
        {
            return cultureInfo.DateTimeFormat.GetDayName(dayOfWeek);
        }

        public static string GetDayNameForCurrentCulture(int dayNumber)
        {
            return GetDayNameForCulture(CultureInfo.CurrentCulture, dayNumber);
        }

        /// <summary>
        /// Returns the day name for a given culture and day number
        /// </summary>
        /// <param name="cultureInfo">The culture to translate</param>
        /// <param name="dayNumber">The number of the day. Eg January = 1</param>
        public static string GetDayNameForCulture(CultureInfo cultureInfo, int dayNumber)
        {
            if(dayNumber < 1 || dayNumber > 7)
                throw new ArgumentException("The day number must be equal or greater than 1 and equal or less than 7");

            return cultureInfo.DateTimeFormat.GetDayName((DayOfWeek)dayNumber);
        }

        /// <summary>
        /// Returns the previous day of the week
        /// </summary>
        /// <example>For Monday, Sunday would be returned</example>
        public static DayOfWeek NextDayOfWeek(this DayOfWeek dayOfWeek)
        {
            //For reference:
            //dayOfWeekSunday = 1,
            //dayOfWeekMonday = 2,
            //dayOfWeekTuesday = 3,
            //dayOfWeekWednesday = 4,
            //dayOfWeekThursday = 5,
            //dayOfWeekFriday = 6,
            //dayOfWeekSaturday = 7,

            var intDayOfWeek = (int)dayOfWeek;
            var intNextDayOfWeek = intDayOfWeek + 1;

            //Loop around if needed
            if (intNextDayOfWeek == 8)
                intNextDayOfWeek = 1;

            return (DayOfWeek)intNextDayOfWeek; //Cast back
        }

        /// <summary>
        /// Returns the last day of the current week
        /// </summary>
        /// <param name="workingDate">The date to work with</param>
        /// <param name="firstDayOfWeek">The first day of the working week</param>
        /// <returns>The last day of the week</returns>
        /// <example>For a working date of Wednesday when Monday is the firstDayOfWeek, the next Sunday will be the last day of this week</example>
        public static DateTime GetLastDayOfWeek(DateTime workingDate, DayOfWeek firstDayOfWeek)
        {
            //Last week day of this week
            var lastDayOfWeek = firstDayOfWeek.PreviousDayOfWeek();

            //Determine the differential between the two days
            var differential = DayHelper.DaysBetween(workingDate.DayOfWeek, lastDayOfWeek);

            return workingDate.Date.AddDays(differential);
        }

        /// <summary>
        /// Returns the first day of the current week
        /// </summary>
        /// <param name="workingDate">The date to work with</param>
        /// <returns>The last day of the week</returns>
        /// <example>.NET Dates consider Sunday to be day 1 of the week.  So for a working date of Wednesday, this will return the previous Sunday</example>
        public static DateTime GetFirstDayOfWeek(DateTime workingDate)
        {
            //Day of week day of this date as an integer
            var dayOfWeek = (int)workingDate.DayOfWeek - 1;

            return workingDate.Date.AddDays(-dayOfWeek);
        }

        /// <summary>
        /// Returns the previous day of the week
        /// </summary>
        /// <example>For Monday, Sunday would be returned</example>
        public static DayOfWeek PreviousDayOfWeek(this DayOfWeek dayOfWeek)
        {
            //For reference:
            //dayOfWeekSunday = 1,
            //dayOfWeekMonday = 2,
            //dayOfWeekTuesday = 3,
            //dayOfWeekWednesday = 4,
            //dayOfWeekThursday = 5,
            //dayOfWeekFriday = 6,
            //dayOfWeekSaturday = 7,

            var intDayOfWeek = (int)dayOfWeek;
            var intPreviousDayOfWeek = intDayOfWeek - 1;

            //Loop around if needed
            if (intPreviousDayOfWeek == 0)
                intPreviousDayOfWeek = 7;

            return (DayOfWeek)intPreviousDayOfWeek; //Cast back
        }

        /// <summary>
        /// Returns the number of days between two days of the week
        /// </summary>
        /// <example>For Monday and Tuesday the return would be 1</example>
        /// <example>For Monday and Sunday the return would be 6</example>
        /// <example>For Monday and Monday the return would be 0</example>
        public static int DaysBetween(DayOfWeek firstDayOfWeek, DayOfWeek lastDayOfWeek)
        {
            //For reference:
            //dayOfWeekSunday = 0,
            //dayOfWeekMonday = 1,
            //dayOfWeekTuesday = 2,
            //dayOfWeekWednesday = 3,
            //dayOfWeekThursday = 4,
            //dayOfWeekFriday = 5,
            //dayOfWeekSaturday = 6,

            var intFirstDayOfWeek = (int)firstDayOfWeek;
            var intLastDayOfWeek = (int)lastDayOfWeek;
            var differential = intLastDayOfWeek - intFirstDayOfWeek;
            
            //Loop around if needed
            if (differential < 0)
                differential += 7;

            return differential;
        }

        /// <summary>
        /// Returns true of the day is between first and last days
        /// </summary>
        /// <remarks>Assumes that the first days is inclusive and the last day is exclusive</remarks>
        public static bool IsBetween(this DayOfWeek day, DayOfWeek firstDayOfWeek, DayOfWeek lastDayOfWeek)
        {
            //For reference:
            //dayOfWeekSunday = 1,
            //dayOfWeekMonday = 2,
            //dayOfWeekTuesday = 3,
            //dayOfWeekWednesday = 4,
            //dayOfWeekThursday = 5,
            //dayOfWeekFriday = 6,
            //dayOfWeekSaturday = 7,

            var intDay = (int)day;
            var intFirstDayOfWeek = (int)firstDayOfWeek;
            var intLastDayOfWeek = (int)lastDayOfWeek;

            //Move last day into next week if needed
            if (intFirstDayOfWeek <= intLastDayOfWeek)
                return intFirstDayOfWeek <= intDay && intDay < intLastDayOfWeek;
            else
                return intFirstDayOfWeek <= intDay || intDay < intLastDayOfWeek;
        }

        /// <summary>
        /// Returns a list containing all the dates between (and including) the start and end date
        /// </summary>
        public static List<DateTime> GetDatesBetween(DateTime startDate, DateTime endDate)
        {
            var dates = new List<DateTime>();
            // If endDate is before startDate, return empty list
            if (endDate < startDate)
                return dates;

            // Make sure we strip off the time part and just work with days 
            var currentDate = new DateTime(startDate.Date.Ticks);

            do
            {
                dates.Add(currentDate);
                currentDate = currentDate.AddDays(1);
            } while (currentDate.Date <= endDate.Date);

            return dates;
        }

    }
}