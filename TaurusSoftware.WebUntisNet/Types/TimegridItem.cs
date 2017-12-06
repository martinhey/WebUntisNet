using System;
using System.Collections.Generic;

namespace TaurusSoftware.WebUntisNet.Types
{
    public class TimegridItem
    {
        public DayOfWeek Day { get; set; }
        public List<TimegridUnit> TimeUnits { get; set; }
    }
}