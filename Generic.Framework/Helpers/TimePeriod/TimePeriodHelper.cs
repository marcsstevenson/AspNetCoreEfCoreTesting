using System;
using System.Collections.Generic;
using System.Linq;
using Generic.Framework.Helpers.DateAndTime;
using Generic.Framework.Interfaces;

namespace Generic.Framework.Helpers.TimePeriod
{
    public static class TimePeriodHelper
    {
        public const string OverlapErrorMessage = "Time periods cannot overlap";
        public const string YearExceededErrorMessage = "All time periods cannot exceed a year in duration";
        public const string FirstDayBeforeStartOfYearErrorMessage = "Time periods cannot have a first day before the start of the year";
        public const string AllTimePeriodsShallHaveFirstDaysBeforeLastDaysErrorMessage = "All time periods shall have first days before last days";

        public static int WeeksInTimePeriod(this ITimePeriod dateTimeRange, bool daysFullInclusive = true, bool roundUp = true)
        {
            return System.Math.Abs(dateTimeRange.LastDay.WeeksBetween(dateTimeRange.FirstDay, daysFullInclusive, roundUp));
        }

        public static int WeeksInTimePeriod(this ITimePeriod dateTimeRange, DayOfWeek firstDayOfWeek, bool daysFullInclusive = true, bool roundUp = true)
        {
            var weeksInTimePeriod = System.Math.Abs(dateTimeRange.LastDay.WeeksBetween(dateTimeRange.FirstDay, daysFullInclusive, roundUp));

            //Is the first day also a firstDayOfWeek?
            if (dateTimeRange.FirstDay.DayOfWeek != firstDayOfWeek)
                weeksInTimePeriod++; //Add an additional week

            return weeksInTimePeriod;
        }

        public static bool ContainsDayOfWeek(this ITimePeriod dateTimeRange, DayOfWeek dayOfWeek)
        {
            if (dateTimeRange.TotalDays() >= 7) return true;
            
            //Sunday 0
            //Monday 1
            //Tuesday 2
            //Wednesday 3 
            //Thursday 4
            //Friday 5
            //Saturday 6

            var firstDayOfTheWeekIndex = (int)dateTimeRange.FirstDay.DayOfWeek;
            var lastDayOfTheWeekIndex = (int)dateTimeRange.LastDay.DayOfWeek;
            var dayOfWeekIndex = (int) dayOfWeek;

            if (firstDayOfTheWeekIndex > lastDayOfTheWeekIndex)
                //eg start Friday 5, end Tuesday 2, test Monday 1
                //eg start Friday 5, end Tuesday 2, test Saturday 6
                return dayOfWeekIndex >= firstDayOfTheWeekIndex || dayOfWeekIndex <= lastDayOfTheWeekIndex;
            else
                //eg start Sunday 0, end Thursday 4, test Monday 1
                return dayOfWeekIndex >= firstDayOfTheWeekIndex && dayOfWeekIndex <= lastDayOfTheWeekIndex;
        }

        public static double TotalDays(this ITimePeriod dateTimeRange)
        {
            return dateTimeRange.LastDay.Subtract(dateTimeRange.FirstDay).TotalDays;
        }

        public static T GetCurrent<T>(this IEnumerable<T> all, DateTime? forDateTime = null) where T : ITimePeriod
        {
            if (!forDateTime.HasValue)
                forDateTime = Clock.Now();

            return all.FirstOrDefault(i => i.FirstDay <= forDateTime && i.LastDay >= forDateTime);
        }
        
        public static T GetNext<T>(this IEnumerable<T> all, DateTime? forDateTime = null) where T : ITimePeriod
        {
            if (!forDateTime.HasValue)
                forDateTime = Clock.Now();

            return all.Where(i => i.LastDay > forDateTime.Value).OrderBy(i => i.LastDay).FirstOrDefault();
        }

        public static T GetPrevious<T>(this IEnumerable<T> all, DateTime? forDateTime = null) where T : ITimePeriod
        {
            if (!forDateTime.HasValue)
                forDateTime = Clock.Now();

            return all.Where(i => i.LastDay > forDateTime.Value).OrderBy(i => i.FirstDay).LastOrDefault();
        }

        public static T GetClosestToTime<T>(this List<T> timePeriods, DateTime dateTime) where T : ITimePeriod
        {
            var ordered = timePeriods.OrderBy(i => System.Math.Abs(dateTime.Subtract(i.GetMidPoint()).Ticks)).ToList();
            return ordered.First();
        }

        public static T GetNextOrClosestToTime<T>(this List<T> timePeriods, DateTime dateTime) where T : ITimePeriod
        {
            var next = timePeriods.GetNext(dateTime);

            return next == null ? timePeriods.GetClosestToTime(dateTime): next;
        }

        public static List<T> BuildTimePeriodWeeks<T>(this ITimePeriod timePeriod,
            DateTime? forDateTime = null, DayOfWeek? firstDayOfWeek = DayOfWeek.Monday, 
            bool includeOutOfRangeTimePeriods = false,
            List<DayOfWeek> openDays = null, List<DateTime> exclusionDates = null) where T : ITimePeriodWeek, new()
        {
            //Sanitise the arguments
            if (!forDateTime.HasValue)
                forDateTime = Clock.Now().ToDateOnly();

            if (timePeriod.LastDay < timePeriod.FirstDay)
                throw new ArgumentException();

            if (!includeOutOfRangeTimePeriods && timePeriod.LastDay < forDateTime)
                return null; //Not in the date range

            if (!includeOutOfRangeTimePeriods && timePeriod.FirstDay > forDateTime)
                return null; //Not in the date range

            var workingFirstDay = timePeriod.FirstDay;

            var timePeriodWeeks = new List<T>();

            while (workingFirstDay <= timePeriod.LastDay)
            {
                int lengthOfWeek;

                if (firstDayOfWeek.HasValue && workingFirstDay.DayOfWeek != firstDayOfWeek)
                {
                    var endOfWeekDay = firstDayOfWeek.Value.PreviousDayOfWeek();
                    //Add the number of days to end this partial week
                    lengthOfWeek = DayHelper.DaysBetween(workingFirstDay.DayOfWeek, endOfWeekDay);
                }
                else
                    lengthOfWeek = 6;

                var workingLastDayOfWeek = workingFirstDay.AddDays(lengthOfWeek);

                //Use the last day of the time period if needed
                if (workingLastDayOfWeek > timePeriod.LastDay)
                    workingLastDayOfWeek = timePeriod.LastDay;

                var timePeriodWeek = new T
                {
                    FirstDay = workingFirstDay.ToStartOfDay(),
                    LastDay = workingLastDayOfWeek.ToStartOfDay(),
                    WeekNumber = timePeriodWeeks.Count + 1
                };
                
                //Is the week empty? Do not add to the list
                if (!timePeriodWeek.IsEmpty(openDays, exclusionDates))
                {
                    timePeriodWeek.IsCurrent = timePeriodWeek.Contains(forDateTime.Value);
                    timePeriodWeeks.Add(timePeriodWeek);
                }

                //workingFirstDay = workingFirstDay.AddDays(7);
                workingFirstDay = workingFirstDay.AddDays(lengthOfWeek + 1);
            }

            return timePeriodWeeks;
        }

        public static bool Contains(this ITimePeriod timePeriod, DateTime dateTime)
        {
            return timePeriod.FirstDay <= dateTime && timePeriod.LastDay >= dateTime;
        }

        //public static List<DateTime> GetDays(this ITimePeriod timePeriod)
        //{
        //    if (timePeriod.LastDay < timePeriod.FirstDay)
        //        throw new ArgumentException();

        //    var workingFirstDay = timePeriod.FirstDay;

        //    var days = new List<DateTime>();

        //    while (workingFirstDay <= timePeriod.LastDay)
        //    {
        //        days.Add(workingFirstDay);
        //        workingFirstDay = workingFirstDay.AddDays(1);
        //    }

        //    return days;
        //}
        
        public static bool DoTimePeriodsOverlap(this ITimePeriod one, ITimePeriod timePeriod)
        {
            return one.ContainsTime(timePeriod.FirstDay) || one.ContainsTime(timePeriod.LastDay);
        }

        public static bool ContainsTime(this ITimePeriod timePeriod, DateTime dateTime)
        {
            return dateTime >= timePeriod.FirstDay && dateTime <= timePeriod.LastDay.ToEndOfDay();
        }

        public static bool IsBeforeTime(this ITimePeriod timePeriod, DateTime dateTime)
        {
            return dateTime > timePeriod.LastDay;
        }

        public static bool IsAfterTime(this ITimePeriod timePeriod, DateTime dateTime)
        {
            return dateTime < timePeriod.FirstDay;
        }

        /// <summary>
        /// Returns an exception if the time periods are not valid
        /// Validate that all first days are not after last days
        /// Valid time periods do not overlap 
        /// Optionally: ensure that all time periods do not exceed a year in duration
        /// Returns null if all is well
        /// </summary>
        public static Exception ValidateTimePeriods(List<ITimePeriod> timePeriods, bool ensureTotalTimePeriodIsWithinAYear, DateTime? yearStartDate = null)
        {
            if (timePeriods == null || !timePeriods.Any())
                return null;

            //Ensure that there are no first days that are after last days
            if (timePeriods.Any(i => i.FirstDay > i.LastDay))
                return new Exception(AllTimePeriodsShallHaveFirstDaysBeforeLastDaysErrorMessage);

            //Ensure that no time periods overlap
            foreach (var timePeriod in timePeriods)
            {
                bool overLaps = timePeriods.Any(i =>
                    i != timePeriod
                    && i.DoTimePeriodsOverlap(timePeriod));

                if (overLaps)
                    return new Exception(OverlapErrorMessage);
            }

            if (ensureTotalTimePeriodIsWithinAYear)
            {
                //Ensure that all time periods do not exceed a year in duration
                var min = timePeriods.Min(i => i.FirstDay);
                var max = timePeriods.Max(i => i.LastDay);

                if (min.AddYears(1) < max)
                    return new Exception(YearExceededErrorMessage);
            }

            if (ensureTotalTimePeriodIsWithinAYear && yearStartDate.HasValue)
            {
                //Ensure that no time period starts before the start of the year
                if (timePeriods.Any(t => t.FirstDay < yearStartDate))
                    return new Exception(FirstDayBeforeStartOfYearErrorMessage);
            }

            //All is well
            return null;
        }

        /// <summary>
        /// Determines if a time period has any days remaining after taking into account open days of the week and any exclusion dates (eg, public holidays)
        /// </summary>
        public static bool IsEmpty(this ITimePeriod timePeriod, List<DayOfWeek> openDays = null, List<DateTime> exclusionDates = null)
        {
            var allDates = timePeriod.GetDates(openDays, exclusionDates);
            return !allDates.Any();
        }

        /// <summary>
        /// Returns the dates of the time period. This is inclusive of the first and last days
        /// </summary>
        public static List<DateTime> GetDates(this ITimePeriod timePeriod, List<DayOfWeek> openDays = null, List<DateTime> exclusionDates = null)
        {
            var allDates = new List<DateTime>();

            for (DateTime date = timePeriod.FirstDay.Date; date <= timePeriod.LastDay.Date; date = date.AddDays(1))
                allDates.Add(date);

            //Strip out the non open days if needed
            if (openDays != null) allDates.FilterForOpenDays(openDays);

            //Strip out the exclusion dates if needed
            if (exclusionDates != null) allDates.FilterForExclusionDates(exclusionDates);

            return allDates;
        }

        /// <summary>
        /// Remove from the list of dates the days of the week are not in out our list of open days of the week
        /// </summary>
        public static void FilterForOpenDays(this List<DateTime> dates, List<DayOfWeek> openDays)
        {
            dates.RemoveAll(i => !openDays.Contains(i.DayOfWeek));
        }

        /// <summary>
        /// Remove from the list of dates the days of the week are not in out our list of open days of the week
        /// </summary>
        public static void FilterForExclusionDates(this List<DateTime> dates, List<DateTime> exclusionDates)
        {
            dates.RemoveAll(exclusionDates.Contains);
        }

        public static DateTime? GetFirstDayMatch(this ITimePeriod timePeriod, DayOfWeek dayOfWeek)
        {
            var workingDate = timePeriod.FirstDay.Date;

            while (workingDate <= timePeriod.LastDay)
            {
                if (workingDate.DayOfWeek == dayOfWeek) return workingDate;

                workingDate = workingDate.AddDays(1);
            }

            return null;
        }

        /// <summary>
        /// Returns the average value between first day and the last day
        /// </summary>
        public static DateTime GetMidPoint(this ITimePeriod timePeriod)
        {
            return DateTimeHelper.GetMidPoint(timePeriod.FirstDay, timePeriod.LastDay);
        }
    }
}