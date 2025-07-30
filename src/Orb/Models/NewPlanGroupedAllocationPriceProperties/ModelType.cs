using System;
using System.Text.Json.Serialization;

namespace Orb.Models.NewPlanGroupedAllocationPriceProperties;

[JsonConverter(typeof(EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : IEnum<ModelType, string>
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
