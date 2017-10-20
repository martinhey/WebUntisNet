namespace WebUntisNet.Rpc.Types
{
    public class ExamsRequestParams : IRpcRequestParams
    {
        public int examTypeId { get; set; }
        public int startDate { get; set; }
        public int endDate { get; set; }
    }
}