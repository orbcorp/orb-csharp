using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.NewSubscriptionTieredPackageWithMinimumPriceProperties;

[JsonConverter(typeof(EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : IEnum<ModelType, string>
{
    public static readonly ModelType TieredPackageWithMinimum = new("tiered_package_with_minimum");

    readonly string _value = value;

    public enum Value
    {
        TieredPackageWithMinimum,
    }

    public Value Known() =>
        _value switch
        {
            "tiered_package_with_minimum" => Value.TieredPackageWithMinimum,
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
