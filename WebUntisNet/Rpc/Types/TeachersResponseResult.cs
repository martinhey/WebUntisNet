using System.Collections.Generic;

namespace WebUntisNet.Rpc.Types
{
    public class TeachersResponseResult: List<Teacher>, IRpcResponseResult
    {
        public int id { get; set; }
        public string name { get; set; }
        public string forename { get; set; }
        public string longname { get; set; }
        public string forecolor { get; set; }
        public string backcolor { get; set; }


    }

    
}