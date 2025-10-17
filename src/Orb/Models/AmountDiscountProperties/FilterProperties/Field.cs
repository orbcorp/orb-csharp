using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.AmountDiscountProperties.FilterProperties;

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(FieldConverter))]
public enum Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class FieldConverter : JsonConverter<Field>
{
    public override Field Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Field.PriceID,
            "item_id" => Field.ItemID,
            "price_type" => Field.PriceType,
            "currency" => Field.Currency,
            "pricing_unit_id" => Field.PricingUnitID,
            _ => (Field)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Field value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Field.PriceID => "price_id",
                Field.ItemID => "item_id",
                Field.PriceType => "price_type",
                Field.Currency => "currency",
                Field.PricingUnitID => "pricing_unit_id",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
