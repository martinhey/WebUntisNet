namespace WebUntisNet.Rpc.Types
{
    public class PersonIdRequest : RpcRequest<PersonIdRequestParams>
    {
        public override string id => "18";
        public override string method => "getPersonId";
    }
}