using System;
using System.Text.Json.Serialization;

namespace Orb.Models.NewPlanTieredPriceProperties;

[JsonConverter(typeof(EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : IEnum<ModelType, string>
{
    public static readonly ModelType Tiered = new("tiered");

    readonly string _value = value;

    public enum Value
    {
        Tiered,
    }

    public Value Known() =>
        _value switch
        {
            "tiered" => Value.Tiered,
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
