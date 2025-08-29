using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.CreditNoteProperties.LineItemProperties.DiscountProperties;

[JsonConverter(typeof(DiscountTypeConverter))]
public enum DiscountType
{
    Percentage,
    Amount,
}

sealed class DiscountTypeConverter : JsonConverter<DiscountType>
{
    public override DiscountType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage" => DiscountType.Percentage,
            "amount" => DiscountType.Amount,
            _ => (DiscountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DiscountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DiscountType.Percentage => "percentage",
                DiscountType.Amount => "amount",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
