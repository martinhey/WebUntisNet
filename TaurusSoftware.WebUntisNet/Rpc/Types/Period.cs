using System.Collections.Generic;

namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class Period
    {
        public int id { get; set; }

        public int date { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }

        public List<Identifier> kl { get; set; }
        public List<Identifier> te { get; set; }
        public List<Identifier> su { get; set; }
        public List<Identifier> ro { get; set; }

        public string lstype { get; set; }
        public string code { get; set; }
        public string lstext { get; set; }
        public string statflags { get; set; }
    }
}