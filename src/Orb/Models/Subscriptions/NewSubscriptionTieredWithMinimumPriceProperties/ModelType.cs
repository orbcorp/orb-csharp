using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.NewSubscriptionTieredWithMinimumPriceProperties;

[JsonConverter(typeof(EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : IEnum<ModelType, string>
{
    public static readonly ModelType TieredWithMinimum = new("tiered_with_minimum");

    readonly string _value = value;

    public enum Value
    {
        TieredWithMinimum,
    }

    public Value Known() =>
        _value switch
        {
            "tiered_with_minimum" => Value.TieredWithMinimum,
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
