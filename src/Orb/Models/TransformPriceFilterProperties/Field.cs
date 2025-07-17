using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.TransformPriceFilterProperties;

/// <summary>
/// The property of the price to filter on.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::EnumConverter<Field, string>))]
public sealed record class Field(string value) : Orb::IEnum<Field, string>
{
    public static readonly Field PriceID = new("price_id");

    public static readonly Field ItemID = new("item_id");

    public static readonly Field PriceType = new("price_type");

    public static readonly Field Currency = new("currency");

    public static readonly Field PricingUnitID = new("pricing_unit_id");

    readonly string _value = value;

    public enum Value
    {
        PriceID,
        ItemID,
        PriceType,
        Currency,
        PricingUnitID,
    }

    public Value Known() =>
        _value switch
        {
            "price_id" => Value.PriceID,
            "item_id" => Value.ItemID,
            "price_type" => Value.PriceType,
            "currency" => Value.Currency,
            "pricing_unit_id" => Value.PricingUnitID,
            _ => throw new System::ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static Field FromRaw(string value)
    {
        return new(value);
    }
}
