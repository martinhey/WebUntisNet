namespace WebUntisNet.Rpc.Types
{
    public class PersonIdRequest : RpcRequest<PersonIdRequest.RequestParams>
    {
        public override string id => "18";
        public override string method => "getPersonId";

        public class RequestParams : IRpcRequestParams
        {
            public int type { get; set; }
            public string sn { get; set; }
            public string fn { get; set; }
            public int dob { get; set; }
        }
    }
}