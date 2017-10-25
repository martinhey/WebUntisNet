namespace WebUntisNet.Rpc.Types
{
    public class ClassesRequest : RpcRequest<ClassesRequestParams>
    {
        public ClassesRequest(string schoolyearId) : base()
        {
            @params.schoolyearId = schoolyearId;
        }

        public override string id => "5";
        public override string method => "getKlassen";
    }
}