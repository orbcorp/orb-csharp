using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.InvoiceProperties.CustomerBalanceTransactionProperties;

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
            "increment" => CustomerBalanceTransactionProperties.Type.Increment,
            "decrement" => CustomerBalanceTransactionProperties.Type.Decrement,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerBalanceTransactionProperties.Type.Increment => "increment",
                CustomerBalanceTransactionProperties.Type.Decrement => "decrement",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
