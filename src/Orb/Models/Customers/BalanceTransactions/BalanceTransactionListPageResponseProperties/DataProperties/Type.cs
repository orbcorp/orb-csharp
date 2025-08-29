using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.BalanceTransactions.BalanceTransactionListPageResponseProperties.DataProperties;

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Increment,
    Decrement,
}

sealed class TypeConverter : JsonConverter<Type>
{
    public override Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "increment" => DataProperties.Type.Increment,
            "decrement" => DataProperties.Type.Decrement,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataProperties.Type.Increment => "increment",
                DataProperties.Type.Decrement => "decrement",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
