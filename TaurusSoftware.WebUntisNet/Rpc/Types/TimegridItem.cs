using System.Collections.Generic;

namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class TimegridItem
    {
        public int day { get; set; }
        public List<TimeUnit> timeUnits { get; set; }
    }
}