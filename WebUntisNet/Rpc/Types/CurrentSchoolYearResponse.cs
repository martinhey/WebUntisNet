namespace WebUntisNet.Rpc.Types
{
    public class CurrentSchoolYearResponse : RpcResponse<CurrentSchoolYearResponse.ResponseResult>
    {

        public class ResponseResult : SchoolYear, IRpcResponseResult
        {
        }
    }
}