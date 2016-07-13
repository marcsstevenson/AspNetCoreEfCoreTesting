using System;
using System.Collections.Generic;
using Generic.Framework.Helpers.DateAndTime;
using Generic.Framework.Interfaces;

namespace Generic.Framework.Helpers.OpenDays
{
    public static class OpenDaysHelper
    {
        public static bool IsOpenOnDay(this IOpenDays openDays, DateTime forDateTime)
        {
            switch (forDateTime.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    return openDays.OpenFriday;
                case DayOfWeek.Monday:
                    return openDays.OpenMonday;
                case DayOfWeek.Saturday:
                    return openDays.OpenSaturday;
                case DayOfWeek.Sunday:
                    return openDays.OpenSunday;
                case DayOfWeek.Thursday:
                    return openDays.OpenThursday;
                case DayOfWeek.Tuesday:
                    return openDays.OpenTuesday;
                case DayOfWeek.Wednesday:
                    return openDays.OpenWednesday;
                default:
                    throw new System.NotImplementedException();
            }
        }

        public static List<DayOfWeek> GetOpenDays(this IOpenDays activeSchool)
        {
            var openDays = new List<DayOfWeek>();

            if (activeSchool.OpenMonday) openDays.Add(DayOfWeek.Monday);
            if (activeSchool.OpenTuesday) openDays.Add(DayOfWeek.Tuesday);
            if (activeSchool.OpenWednesday) openDays.Add(DayOfWeek.Wednesday);
            if (activeSchool.OpenThursday) openDays.Add(DayOfWeek.Thursday);
            if (activeSchool.OpenFriday) openDays.Add(DayOfWeek.Friday);
            if (activeSchool.OpenSaturday) openDays.Add(DayOfWeek.Saturday);
            if (activeSchool.OpenSunday) openDays.Add(DayOfWeek.Sunday);

            return openDays;
        }

        public static List<KeyValuePair<int, string>> GetOpenDaysKeyValuePairs(this IOpenDays activeSchool)
        {
            var activeDays = new List<KeyValuePair<int, string>>();
            if (activeSchool.OpenSunday)
            {
                activeDays.Add(new KeyValuePair<int, string>(0, DayHelper.GetDayNameForCurrentCulture(DayOfWeek.Sunday)));
            }
            if (activeSchool.OpenMonday)
            {
                activeDays.Add(new KeyValuePair<int, string>(1, DayHelper.GetDayNameForCurrentCulture(DayOfWeek.Monday)));
            }
            if (activeSchool.OpenTuesday)
            {
                activeDays.Add(new KeyValuePair<int, string>(2, DayHelper.GetDayNameForCurrentCulture(DayOfWeek.Tuesday)));
            }
            if (activeSchool.OpenWednesday)
            {
                activeDays.Add(new KeyValuePair<int, string>(3, DayHelper.GetDayNameForCurrentCulture(DayOfWeek.Wednesday)));
            }
            if (activeSchool.OpenThursday)
            {
                activeDays.Add(new KeyValuePair<int, string>(4, DayHelper.GetDayNameForCurrentCulture(DayOfWeek.Thursday)));
            }
            if (activeSchool.OpenFriday)
            {
                activeDays.Add(new KeyValuePair<int, string>(5, DayHelper.GetDayNameForCurrentCulture(DayOfWeek.Friday)));
            }
            if (activeSchool.OpenSaturday)
            {
                activeDays.Add(new KeyValuePair<int, string>(6, DayHelper.GetDayNameForCurrentCulture(DayOfWeek.Saturday)));
            }
            return activeDays;
        }
    }
}