namespace WebUntisNet.Rpc.Types
{
    public class SubstitutionsRequest : RpcRequest<SubstitutionsRequestParams>
    {
        public override string id => "19";
        public override string method => "getSubstitutions";
    }
}