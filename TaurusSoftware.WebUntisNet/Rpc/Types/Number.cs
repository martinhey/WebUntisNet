using Newtonsoft.Json;
using TaurusSoftware.WebUntisNet.Json;

namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    [JsonConverter(typeof(NumberValueConverter))]
    public class Number
    {
        public object Value { get; set; }
    }
}