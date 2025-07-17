using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.NewSphereConfigurationProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<TaxProvider, string>))]
public sealed record class TaxProvider(string value) : Orb::IEnum<TaxProvider, string>
{
    public static readonly TaxProvider Sphere = new("sphere");

    readonly string _value = value;

    public enum Value
    {
        Sphere,
    }

    public Value Known() =>
        _value switch
        {
            "sphere" => Value.Sphere,
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

    public static TaxProvider FromRaw(string value)
    {
        return new(value);
    }
}
