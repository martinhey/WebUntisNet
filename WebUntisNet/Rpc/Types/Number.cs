using Newtonsoft.Json;
using WebUntisNet.Json;

namespace WebUntisNet.Rpc.Types
{
    [JsonConverter(typeof(NumberValueConverter))]
    public class Number
    {
        public object Value { get; set; }
    }
}