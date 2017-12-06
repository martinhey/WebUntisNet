using System;
using TaurusSoftware.WebUntisNet.Types;

namespace TaurusSoftware.WebUntisNet
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

        public static int? DateTimeToApiDate(DateTime? value)
        {
            if (value.HasValue)
            {
                return DateTimeToApiDate(value.Value);
            }

            return null;
        }

        public static DateTime ApiTimeToDateTime(int value)
        {
            return ApiDateAndTimeToDateTime(0, value);
        }

        public static Code? ApiCodeToCode(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            switch (value.ToLowerInvariant())
            {
                case "cancelled":
                    return Code.Cancelled;
                case "irregular":
                    return Code.Irregular;
                    default:
                        return null;
            }
        }

        public static LessonType ApiLessonTypeToLessonType(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return LessonType.Lesson;
            }

            switch (value.ToLowerInvariant())
            {
                case "oh":
                    return LessonType.OfficeHour;
                case "bs":
                    return LessonType.BreakSupervision;
                case "sb":
                    return LessonType.Standby;
                case "ex":
                    return LessonType.Examination;
                default:
                    return LessonType.Lesson;
            }
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
