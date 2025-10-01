using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.CreditNoteProperties;

[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    Duplicate,
    Fraudulent,
    OrderChange,
    ProductUnsatisfactory,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Duplicate" => Reason.Duplicate,
            "Fraudulent" => Reason.Fraudulent,
            "Order change" => Reason.OrderChange,
            "Product unsatisfactory" => Reason.ProductUnsatisfactory,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.Duplicate => "Duplicate",
                Reason.Fraudulent => "Fraudulent",
                Reason.OrderChange => "Order change",
                Reason.ProductUnsatisfactory => "Product unsatisfactory",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
