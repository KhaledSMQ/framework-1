// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Types.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Framework.Core.Serializers
{
    public class IdJsonSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string raw = JToken.ReadFrom(reader).Value<string>();
            return new Id(raw);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Id).IsAssignableFrom(objectType);
        }
    }
}
