using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.NewSubscriptionGroupedTieredPackagePriceProperties;

[JsonConverter(typeof(EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : IEnum<ModelType, string>
{
    public static readonly ModelType GroupedTieredPackage = new("grouped_tiered_package");

    readonly string _value = value;

    public enum Value
    {
        GroupedTieredPackage,
    }

    public Value Known() =>
        _value switch
        {
            "grouped_tiered_package" => Value.GroupedTieredPackage,
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
