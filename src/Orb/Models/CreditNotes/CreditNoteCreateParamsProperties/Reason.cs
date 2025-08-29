using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.CreditNotes.CreditNoteCreateParamsProperties;

/// <summary>
/// An optional reason for the credit note.
/// </summary>
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
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "duplicate" => Reason.Duplicate,
            "fraudulent" => Reason.Fraudulent,
            "order_change" => Reason.OrderChange,
            "product_unsatisfactory" => Reason.ProductUnsatisfactory,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.Duplicate => "duplicate",
                Reason.Fraudulent => "fraudulent",
                Reason.OrderChange => "order_change",
                Reason.ProductUnsatisfactory => "product_unsatisfactory",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
