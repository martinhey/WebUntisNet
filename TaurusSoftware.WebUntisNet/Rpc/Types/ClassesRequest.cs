namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class ClassesRequest : RpcRequest<ClassesRequest.RequestParams>
    {
        public ClassesRequest(string schoolyearId) : base()
        {
            @params.schoolyearId = schoolyearId;
        }

        public override string id => "5";
        public override string method => "getKlassen";


        public class RequestParams : IRpcRequestParams
        {
            public string schoolyearId { get; set; }
        }
    }
}