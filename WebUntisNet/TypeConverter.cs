using System;

namespace WebUntisNet
{
    public static class TypeConverter
    {
        public static DayOfWeek ApiDayOfWeekToDayOfWeek(int day)
        {
            return (DayOfWeek) (day - 1);
        }

        public static int DateTimeToApiDate(DateTime value)
        {
            return value.Year * 10000 + value.Month * 100 + value.Day;
        }

        public static DateTime ApiTimeToDateTime(int value)
        {
            return ApiDateAndTimeToDateTime(0, value);
        }

        public static DateTime ApiDateAndTimeToDateTime(int date, int time)
        {
            int year = DateTime.MinValue.Year;
            int month = DateTime.MinValue.Month;
            int day= DateTime.MinValue.Day;

            if (date > 0)
            {
                year = date / 10000; // dvision without fraction
                date -= year * 10000;
                month = date / 100; // dvision without fraction
                date -= month * 100;
                day = date;
            }

            var hour = time / 100; // dvision without fraction
            time -= hour * 100;
            var minute = time;

            return new DateTime(year, month, day, hour, minute, 0);
        }

        public static DateTime ApiDateToDateTime(int date)
        {
            return ApiDateAndTimeToDateTime(date, 0);
        }

    }
}
