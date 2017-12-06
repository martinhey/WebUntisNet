namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class StudentsRequest : RpcRequest<StudentsRequest.RequestParams>
    {
        public override string id => "4";
        public override string method => "getStudents";

        public class RequestParams : EmptyRequestParams
        {
        }
    }
}