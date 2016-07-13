using System.Globalization;

namespace Generic.Framework.Helpers.Internationalisation
{
    public static class DateTimeFormatHelper
    {
        /// <summary>
        /// Returns if true if the current thread is set to use a month first date format - for example: 01/31/2014 (Jan 31st 2014)
        /// </summary>
        public static bool ThreadUsesMonthFirstFormat()
        {
            var userDateFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat;
            return userDateFormat.IsMonthFirst();
        }

        /// <summary>
        /// Returns if the 
        /// </summary>
        /// <param name="dateTimeFormatInfo"></param>
        /// <returns></returns>
        public static bool IsMonthFirst(this DateTimeFormatInfo dateTimeFormatInfo)
        {
            return dateTimeFormatInfo.LongDatePattern.ToLower().StartsWith("m");
        }
    }
}