using System;

namespace WebUntisNet.Types
{
    public class Holiday
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LongName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}