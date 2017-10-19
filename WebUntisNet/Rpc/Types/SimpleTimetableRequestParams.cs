namespace WebUntisNet.Rpc.Types
{
    public class SimpleTimetableRequestParams : IRpcRequestParams
    {
        public int id { get; set; }
        public int type { get; set; }
        public int? startDate { get; set; }
        public int? endDate { get; set; }
    }
}