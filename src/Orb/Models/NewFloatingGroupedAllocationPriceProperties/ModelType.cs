using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.NewFloatingGroupedAllocationPriceProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : Orb::IEnum<ModelType, string>
{
    public static readonly ModelType GroupedAllocation = new("grouped_allocation");

    readonly string _value = value;

    public enum Value
    {
        GroupedAllocation,
    }

    public Value Known() =>
        _value switch
        {
            "grouped_allocation" => Value.GroupedAllocation,
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
