namespace WebUntisNet.Rpc.Types
{
    public class PersonIdRequestParams : IRpcRequestParams
    {
        public int type { get; set; }
        public string sn { get; set; }
        public string fn { get; set; }
        public int dob { get; set; }
    }
}