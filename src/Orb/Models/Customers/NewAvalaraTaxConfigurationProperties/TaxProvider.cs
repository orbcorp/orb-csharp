using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.NewAvalaraTaxConfigurationProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<TaxProvider, string>))]
public sealed record class TaxProvider(string value) : Orb::IEnum<TaxProvider, string>
{
    public static readonly TaxProvider Avalara = new("avalara");

    readonly string _value = value;

    public enum Value
    {
        Avalara,
    }

    public Value Known() =>
        _value switch
        {
            "avalara" => Value.Avalara,
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
