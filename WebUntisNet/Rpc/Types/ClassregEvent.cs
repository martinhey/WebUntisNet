namespace WebUntisNet.Rpc.Types
{
    public class ClassregEvent
    {
        public string studentid { get; set; } // why not int ?
        public string surname { get; set; }
        public string forname { get; set; }
        public int date { get; set; }
        public string subject { get; set; }
        public string reason { get; set; }
        public string text { get; set; }
    }
}