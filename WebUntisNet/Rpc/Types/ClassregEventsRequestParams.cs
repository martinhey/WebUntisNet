namespace WebUntisNet.Rpc.Types
{
    public class ClassregEventsRequestParams : IRpcRequestParams
    {
        public int startDate { get; set; }
        public int endDate { get; set; }
    }
}