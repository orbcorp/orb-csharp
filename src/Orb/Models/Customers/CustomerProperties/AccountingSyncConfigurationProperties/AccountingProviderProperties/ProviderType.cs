using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.CustomerProperties.AccountingSyncConfigurationProperties.AccountingProviderProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<ProviderType, string>))]
public sealed record class ProviderType(string value) : Orb::IEnum<ProviderType, string>
{
    public static readonly ProviderType Quickbooks = new("quickbooks");

    public static readonly ProviderType Netsuite = new("netsuite");

    readonly string _value = value;

    public enum Value
    {
        Quickbooks,
        Netsuite,
    }

    public Value Known() =>
        _value switch
        {
            "quickbooks" => Value.Quickbooks,
            "netsuite" => Value.Netsuite,
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

    public static ProviderType FromRaw(string value)
    {
        return new(value);
    }
}
