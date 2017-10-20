using System.Collections.Generic;

namespace WebUntisNet.Rpc.Types
{
    public class Substitution
    {
        public string type { get; set; }
        public int lsid { get; set; }
        public int date { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }
        public List<ReplacementIdentifier> kl { get; set; }
        public List<ReplacementIdentifier> te { get; set; }
        public List<ReplacementIdentifier> su { get; set; }
        public List<ReplacementIdentifier> ro { get; set; }
        public string txt { get; set; }
        public Reschedule reschedule { get; set; }
    }
}