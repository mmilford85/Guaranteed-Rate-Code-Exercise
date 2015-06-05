namespace GRCE.Domain.Extensions
{
    using System;

    public static class DateTimeExtensions
    {
        public static string ToDobDisplayString(this DateTime dateTime)
        {
            return dateTime.ToShortDateString();
        }
    }
}
