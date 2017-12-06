using System;
using Newtonsoft.Json;
using TaurusSoftware.WebUntisNet.Rpc.Types;

namespace TaurusSoftware.WebUntisNet.Json
{
    public class NumberValueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Number);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Integer)
            {
                var value = (long)reader.Value;
                var result = (Number) Activator.CreateInstance(objectType);
                result.Value = value;
                return result;
            }
            throw  new JsonReaderException("unexpected value");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}
