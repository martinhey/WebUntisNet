namespace WebUntisNet.Rpc.Types
{
    public class ClassesRequest : RpcRequest<ClassesRequestParams>
    {
        public override string id => "5";
        public override string method => "getKlassen";
    }
}