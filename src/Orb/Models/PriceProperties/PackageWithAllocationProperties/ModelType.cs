using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.PriceProperties.PackageWithAllocationProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : Orb::IEnum<ModelType, string>
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
