using System;
using System.Collections.Generic;
using System.Linq;
using Generic.Framework.Helpers.DateAndTime;
using Generic.Framework.Interfaces;

namespace Generic.Framework.Helpers.TimePeriod
{
    public static class TimePeriodNullableHelper
    {
        public static int WeeksInTimePeriod(this ITimePeriodNullable dateTimeRangeNullable, bool daysFullInclusive = true, bool roundUp = true)
        {
            if (!dateTimeRangeNullable.FirstDay.HasValue || !dateTimeRangeNullable.LastDay.HasValue)
                return 0;

            return dateTimeRangeNullable.FirstDay.Value.WeeksBetween(dateTimeRangeNullable.LastDay.Value, daysFullInclusive, roundUp);

        }

        public static bool DateTimeIncludesNow(this ITimePeriodNullable dateTimeRangeNullable)
        {
            return dateTimeRangeNullable.DateTimeIsInRange(Clock.Now());
        }

        public static bool DateTimeIsInRange(this ITimePeriodNullable dateTimeRangeNullable, DateTime dateTime)
        {
            return (dateTimeRangeNullable.FirstDay == null || dateTimeRangeNullable.FirstDay <= dateTime)
                && (dateTimeRangeNullable.LastDay == null || dateTimeRangeNullable.LastDay >= dateTime);
        }

        public static bool DateTimeIsAfterRange(this ITimePeriodNullable dateTimeRangeNullable, DateTime dateTime)
        {
            if (dateTimeRangeNullable.LastDay.HasValue) return dateTimeRangeNullable.LastDay.Value <= dateTime;
             
            return true;
        }

        public static List<T> FilterForDateTimeIsInRange<T>(this List<T> dateTimeRangeNullables, DateTime dateTime)
            where T : ITimePeriodNullable
        {
            var expression = GetExpressionFilterForDateTimeIsInRange<T>(dateTime);
            return dateTimeRangeNullables.Where(expression).ToList();
        }

        public static Func<T, bool> GetExpressionFilterForDateTimeIsInRange<T>(DateTime dateTime) where T : ITimePeriodNullable
        {
            return i => (i.FirstDay == null || i.FirstDay <= dateTime)
                && (i.LastDay == null || i.LastDay >= dateTime);
        }

        public static List<T> FilterForDateTimeIsAfterRange<T>(this List<T> dateTimeRangeNullables, DateTime dateTime)
            where T : ITimePeriodNullable
        {
            var expression = GetExpressionFilterForDateTimeIsAfterRange<T>(dateTime);
            return dateTimeRangeNullables.Where(expression).ToList();
        }

        public static Func<T, bool> GetExpressionFilterForDateTimeIsAfterRange<T>(DateTime dateTime) where T : ITimePeriodNullable
        {
            return i => (i.FirstDay == null || i.FirstDay <= dateTime)
                && (i.LastDay == null || i.LastDay <= dateTime);
        }

        public static List<T> FilterForDateTimeIsAfterOrDuringRange<T>(this List<T> dateTimeRangeNullables, DateTime dateTime)
            where T : ITimePeriodNullable
        {
            var expression = GetExpressionFilterForDateTimeIsAfterOrDuringRange<T>(dateTime);
            return dateTimeRangeNullables.Where(expression).ToList();
        }

        public static List<T> FilterForDateTimeIsDuringRange<T>(this List<T> dateTimeRangeNullables, DateTime dateTime)
            where T : ITimePeriodNullable
        {
            var expression = GetExpressionFilterForDateTimeIsDuringRange<T>(dateTime);
            return dateTimeRangeNullables.Where(expression).ToList();
        }

        public static Func<T, bool> GetExpressionFilterForDateTimeIsAfterOrDuringRange<T>(DateTime dateTime) where T : ITimePeriodNullable
        {
            return i => (i.FirstDay == null || i.FirstDay <= dateTime);// && (i.LastDay == null || i.LastDay >= dateTime);
        }

        public static Func<T, bool> GetExpressionFilterForDateTimeIsDuringRange<T>(DateTime dateTime) where T : ITimePeriodNullable
        {
            return i => (i.FirstDay == null || i.FirstDay <= dateTime) && (i.LastDay == null || i.LastDay >= dateTime);
        }

        /// <summary>
        /// Returns the average value between first day and the last day.
        /// </summary>
        /// <returns>Returns DateTime.MinValue is first and last days are null.
        /// Returns FirstDay if LastDay is null
        /// Returns LastDay if FirstDay is null
        /// Returns the mid point between both days if both are not null
        /// </returns>
        public static DateTime GetMidPoint(this ITimePeriodNullable timePeriod)
        {
            if (!timePeriod.FirstDay.HasValue && !timePeriod.LastDay.HasValue)
                return DateTime.MinValue;

            if (!timePeriod.FirstDay.HasValue)
                return timePeriod.LastDay.Value;

            if (!timePeriod.LastDay.HasValue)
                return timePeriod.FirstDay.Value;

            return DateTimeHelper.GetMidPoint(timePeriod.FirstDay.Value, timePeriod.LastDay.Value);
        }
    }
}