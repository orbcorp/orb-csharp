using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.NewFloatingGroupedWithMeteredMinimumPriceProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : Orb::IEnum<ModelType, string>
{
    public static readonly ModelType GroupedWithMeteredMinimum = new(
        "grouped_with_metered_minimum"
    );

    readonly string _value = value;

    public enum Value
    {
        GroupedWithMeteredMinimum,
    }

    public Value Known() =>
        _value switch
        {
            "grouped_with_metered_minimum" => Value.GroupedWithMeteredMinimum,
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
