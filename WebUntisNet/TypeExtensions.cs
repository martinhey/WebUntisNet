using System;

namespace WebUntisNet
{
    public static class TypeExtensions
    {
        public static int ToApiDate(this DateTime value)
        {
            return value.Year * 10000 + value.Month * 100 + value.Day;
        }


    }
}
