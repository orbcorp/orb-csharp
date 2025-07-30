using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.NewSphereConfigurationProperties;

[JsonConverter(typeof(EnumConverter<TaxProvider, string>))]
public sealed record class TaxProvider(string value) : IEnum<TaxProvider, string>
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

    public static TaxProvider FromRaw(string value)
    {
        return new(value);
    }
}
