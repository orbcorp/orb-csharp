using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.NewSubscriptionUnitWithProrationPriceProperties;

[JsonConverter(typeof(EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : IEnum<ModelType, string>
{
    public static readonly ModelType UnitWithProration = new("unit_with_proration");

    readonly string _value = value;

    public enum Value
    {
        UnitWithProration,
    }

    public Value Known() =>
        _value switch
        {
            "unit_with_proration" => Value.UnitWithProration,
            _ => throw new ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static ModelType FromRaw(string value)
    {
        return new(value);
    }
}
