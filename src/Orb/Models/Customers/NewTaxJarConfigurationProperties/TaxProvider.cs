using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.NewTaxJarConfigurationProperties;

[JsonConverter(typeof(EnumConverter<TaxProvider, string>))]
public sealed record class TaxProvider(string value) : IEnum<TaxProvider, string>
{
    public static readonly TaxProvider Taxjar = new("taxjar");

    readonly string _value = value;

    public enum Value
    {
        Taxjar,
    }

    public Value Known() =>
        _value switch
        {
            "taxjar" => Value.Taxjar,
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
