using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.NewSubscriptionTieredPackagePriceProperties;

[JsonConverter(typeof(EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : IEnum<ModelType, string>
{
    public static readonly ModelType TieredPackage = new("tiered_package");

    readonly string _value = value;

    public enum Value
    {
        TieredPackage,
    }

    public Value Known() =>
        _value switch
        {
            "tiered_package" => Value.TieredPackage,
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
