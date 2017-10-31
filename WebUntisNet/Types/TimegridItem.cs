using System;
using System.Collections.Generic;

namespace WebUntisNet.Types
{
    public class TimegridItem
    {
        public DayOfWeek Day { get; set; }
        public List<TimegridUnit> TimeUnits { get; set; }
    }
}