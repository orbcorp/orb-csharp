using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.Ledger.ExpirationChangeLedgerEntryProperties;

[JsonConverter(typeof(EnumConverter<EntryType, string>))]
public sealed record class EntryType(string value) : IEnum<EntryType, string>
{
    public static readonly EntryType ExpirationChange = new("expiration_change");

    readonly string _value = value;

    public enum Value
    {
        ExpirationChange,
    }

    public Value Known() =>
        _value switch
        {
            "expiration_change" => Value.ExpirationChange,
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

    public static EntryType FromRaw(string value)
    {
        return new(value);
    }
}
