using System;
using System.Collections.Generic;
using System.Linq;

namespace Generic.Framework.Helpers.DateAndTime
{
    public static class TimeZoneHelper
    {
        public static List<TimeZoneInfo> GetAllTimeZoneInfos()
        {
            return TimeZoneInfo.GetSystemTimeZones().ToList();
        }

        public static TimeZoneInfo TimeZoneInfoFromId(string timeZoneInfoId)
        {
            return TimeZoneInfo.FindSystemTimeZoneById(timeZoneInfoId);
        }

        public static string TimeZoneInfoToString(TimeZoneInfo timeZoneInfo)
        {
            return timeZoneInfo.ToString();
        }

        public static DateTime GetLocalTime(this TimeZoneInfo timeZoneInfo, DateTime? dateTime = null)
        {
            dateTime = dateTime ?? Clock.Now();

            return TimeZoneInfo.ConvertTimeFromUtc(dateTime.Value, timeZoneInfo);
        }

        public static string NewZealandTimeZone
        {
            get { return "New Zealand Standard Time"; }
        }
    }
}