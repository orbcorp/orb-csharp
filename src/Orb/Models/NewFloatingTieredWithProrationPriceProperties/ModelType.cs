using System;
using System.Text.Json.Serialization;

namespace Orb.Models.NewFloatingTieredWithProrationPriceProperties;

[JsonConverter(typeof(EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : IEnum<ModelType, string>
{
    public static readonly ModelType TieredWithProration = new("tiered_with_proration");

    readonly string _value = value;

    public enum Value
    {
        TieredWithProration,
    }

    public Value Known() =>
        _value switch
        {
            "tiered_with_proration" => Value.TieredWithProration,
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
