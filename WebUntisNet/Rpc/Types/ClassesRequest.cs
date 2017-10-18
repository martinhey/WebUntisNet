namespace WebUntisNet.Rpc.Types
{
    public class ClassesRequest : RpcRequest<ClassesRequestParams>
    {
        public override string id => "ID";
        public override string method => "getKlassen";
    }
}