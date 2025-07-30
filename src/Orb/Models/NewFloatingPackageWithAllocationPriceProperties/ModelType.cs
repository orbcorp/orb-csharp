using System;
using System.Text.Json.Serialization;

namespace Orb.Models.NewFloatingPackageWithAllocationPriceProperties;

[JsonConverter(typeof(EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : IEnum<ModelType, string>
{
    public static readonly ModelType PackageWithAllocation = new("package_with_allocation");

    readonly string _value = value;

    public enum Value
    {
        PackageWithAllocation,
    }

    public Value Known() =>
        _value switch
        {
            "package_with_allocation" => Value.PackageWithAllocation,
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
