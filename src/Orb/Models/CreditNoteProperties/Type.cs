using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.CreditNoteProperties;

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Refund,
    Adjustment,
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
            "refund" => CreditNoteProperties.Type.Refund,
            "adjustment" => CreditNoteProperties.Type.Adjustment,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditNoteProperties.Type.Refund => "refund",
                CreditNoteProperties.Type.Adjustment => "adjustment",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
