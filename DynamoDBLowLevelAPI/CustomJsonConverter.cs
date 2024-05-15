using Amazon.DynamoDBv2.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DynamoDBLowLevelAPI;

public class CustomJsonConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(AttributeValue);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JToken token = JToken.Load(reader);
        if (token.Type == JTokenType.String)
        {
            return new AttributeValue { S = token.Value<string>() };
        }

        if (token.Type == JTokenType.Integer)
        {
            return new AttributeValue { N = token.Value<string>() };
        }

        throw new InvalidOperationException($"Unsupported AttributeValue type: {token.Type}");
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        AttributeValue attributeValue = (AttributeValue)value;
        if (attributeValue.S != null)
        {
            writer.WriteValue(attributeValue.S);
        }
        else if (attributeValue.N != null)
        {
            writer.WriteValue(attributeValue.N);
        }
        else
        {
            throw new InvalidOperationException($"Unsupported AttributeValue type: {value.GetType().Name}");
        }
    }
}