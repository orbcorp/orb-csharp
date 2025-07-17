using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.PriceProperties.GroupedTieredProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : Orb::IEnum<ModelType, string>
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

    public static ModelType FromRaw(string value)
    {
        return new(value);
    }
}
