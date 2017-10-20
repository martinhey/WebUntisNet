using System.Collections.Generic;

namespace WebUntisNet.Rpc.Types
{
    public class Exam
    {
        public int id { get; set; }
        public List<int> classes { get; set; }
        public List<int> teachers { get; set; }
        public List<int> students { get; set; }
        public int subject { get; set; }
        public int date { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }
    }
}