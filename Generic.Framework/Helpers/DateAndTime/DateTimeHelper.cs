using System;

namespace Generic.Framework.Helpers.DateAndTime
{
    public static class DateTimeHelper
    {
        /// <summary>
        /// Returns a new instance without time components (hours, minutes etc)
        /// </summary>
        public static DateTime ToDateOnly(this DateTime dateTime)
        {
            return new DateTime(year: dateTime.Year, month: dateTime.Month, day: dateTime.Day);
        }

        /// <summary>
        /// Returns the start of this day
        /// </summary>
        public static DateTime ToStartOfDay(this DateTime dateTime)
        {
            return dateTime.ToDateOnly(); //This is the same thing
        }

        /// <summary>
        /// Returns the end this day
        /// </summary>
        public static DateTime ToEndOfDay(this DateTime dateTime, bool toTheMillisecond = true)
        {
            return toTheMillisecond ? 
                new DateTime(year: dateTime.Year, month: dateTime.Month, day: dateTime.Day, hour: 23, minute: 59, second: 59, millisecond: 999) 
                : new DateTime(year: dateTime.Year, month: dateTime.Month, day: dateTime.Day, hour: 23, minute: 59, second: 59);
        }

        /// <summary>
        /// Returns true if the date components are the dates are the same
        /// </summary>
        public static bool IsSameDate(this DateTime dateTime, DateTime toCompare)
        {
            return dateTime.Year == toCompare.Year &&
                   dateTime.Month == toCompare.Month &&
                   dateTime.Date == toCompare.Date;
        }

        /// <summary>
        /// Returns true if the date is within a range of timespan either side of the comparison date
        /// </summary>
        public static bool IsWithin(this DateTime dateTime, TimeSpan timespan, DateTime toCompare)
        {
            var rangeStart = toCompare.Subtract(timespan);
            var rangeEnd = toCompare.Add(timespan);
            return dateTime >= rangeStart && dateTime <= rangeEnd;
        }

        public static DayOfWeek? GetDayOfWeekFromString(string dayOfWeekString )
        {

            switch (dayOfWeekString.Trim().ToLower())
            {
                case "monday":
                    return DayOfWeek.Monday;
                    
                case "tuesday":
                    return DayOfWeek.Tuesday;
                    
                case "wednesday":
                    return DayOfWeek.Wednesday;
                    
                case "thursday":
                    return DayOfWeek.Thursday;
                    
                case "friday":
                    return DayOfWeek.Friday;
                    
                case "saturday":
                    return DayOfWeek.Saturday;
                    
                case "sunday":
                    return DayOfWeek.Sunday;
                    
                default:
                    return null;
            }
        }

        public static DateTime GetTheNext5thMinute()
        {
            return GetTheNext5thMinute(Clock.Now());
        }

        public static DateTime GetTheNext5thMinute(this DateTime dateTime)
        {
            var minute = dateTime.Minute;
            var nextMinute = 0;
            var addHour = false;
            //var addDay = false;

            if (minute%5 == 0)
                nextMinute += 5; //Just add 5
            else
            {
                int fifths = Convert.ToInt32(System.Math.Ceiling(Convert.ToDouble(minute) / 5));
                nextMinute = fifths * 5;
            }

            if (nextMinute >= 60)
            {
                nextMinute = 0;
                addHour = true;
            }

            var next5th = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, nextMinute, 0);

            if (addHour) next5th = next5th.AddHours(1);

            return next5th;
        }
        
        public static DateTime GetMidPoint(DateTime firstDay, DateTime lastDay)
        {
            var timeSpan = lastDay.Subtract(firstDay);
            return firstDay.Add(new TimeSpan(timeSpan.Ticks / 2));
        }
    }
}