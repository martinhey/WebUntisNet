using System;

namespace WebUntisNet
{
    public static class TypeConverter
    {
        public static int ToApiDate(this DateTime value)
        {
            return DateTimeToApiDate(value);
        }

        public static int DateTimeToApiDate(DateTime value)
        {
            return value.Year * 10000 + value.Month * 100 + value.Day;
        }

        public static DateTime ApiDateAndTimeToDateTime(int date, int time)
        {
            var year = date / 100000; // dvision without fraction
            date -= year;
            var month = date / 100; // dvision without fraction
            date -= month;
            var day = date;

            var hour = time / 100; // dvision without fraction
            time -= hour;
            var minute = time;

            return new DateTime(year, month, day, hour, minute, 0);
        }

        public static DateTime ApiDateToDateTime(int date)
        {
            return ApiDateAndTimeToDateTime(date, 0);
        }

    }
}
