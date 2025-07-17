using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.NewSubscriptionUnitWithPercentPriceProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : Orb::IEnum<ModelType, string>
{
    public static readonly ModelType UnitWithPercent = new("unit_with_percent");

    readonly string _value = value;

    public enum Value
    {
        UnitWithPercent,
    }

    public Value Known() =>
        _value switch
        {
            "unit_with_percent" => Value.UnitWithPercent,
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
