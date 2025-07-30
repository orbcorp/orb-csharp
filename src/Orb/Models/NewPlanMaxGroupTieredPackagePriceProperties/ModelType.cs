using System;
using System.Text.Json.Serialization;

namespace Orb.Models.NewPlanMaxGroupTieredPackagePriceProperties;

[JsonConverter(typeof(EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : IEnum<ModelType, string>
{
    public static readonly ModelType MaxGroupTieredPackage = new("max_group_tiered_package");

    readonly string _value = value;

    public enum Value
    {
        MaxGroupTieredPackage,
    }

    public Value Known() =>
        _value switch
        {
            "max_group_tiered_package" => Value.MaxGroupTieredPackage,
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
