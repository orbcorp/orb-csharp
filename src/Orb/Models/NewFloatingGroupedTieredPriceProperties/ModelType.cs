using System;
using System.Text.Json.Serialization;

namespace Orb.Models.NewFloatingGroupedTieredPriceProperties;

[JsonConverter(typeof(EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : IEnum<ModelType, string>
{
    public static readonly ModelType GroupedTiered = new("grouped_tiered");

    readonly string _value = value;

    public enum Value
    {
        GroupedTiered,
    }

    public Value Known() =>
        _value switch
        {
            "grouped_tiered" => Value.GroupedTiered,
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
