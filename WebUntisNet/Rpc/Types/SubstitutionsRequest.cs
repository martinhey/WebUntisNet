namespace WebUntisNet.Rpc.Types
{
    public class SubstitutionsRequest : RpcRequest<SubstitutionsRequest.RequestParams>
    {
        public override string id => "19";
        public override string method => "getSubstitutions";

        public class RequestParams : IRpcRequestParams
        {
            public int startDate { get; set; }
            public int endDate { get; set; }
            public int departmentId { get; set; }
        }
    }
}