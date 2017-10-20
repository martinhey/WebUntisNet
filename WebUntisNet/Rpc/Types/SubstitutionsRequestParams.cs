namespace WebUntisNet.Rpc.Types
{
    public class SubstitutionsRequestParams : IRpcRequestParams
    {
        public int startDate { get; set; }
        public int endDate { get; set; }
        public int departmentId { get; set; }
    }
}