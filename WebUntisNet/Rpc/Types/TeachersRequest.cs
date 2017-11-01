namespace WebUntisNet.Rpc.Types
{
    public class TeachersRequest : RpcRequest<TeachersRequest.RequestParams>
    {
        public override string id => "3";
        public override string method => "getTeachers";

        public class RequestParams : EmptyRequestParams
        {
        }
    }
}
