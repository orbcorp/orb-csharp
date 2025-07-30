using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.Ledger.IncrementLedgerEntryProperties;

[JsonConverter(typeof(EnumConverter<EntryType, string>))]
public sealed record class EntryType(string value) : IEnum<EntryType, string>
{
    public static readonly EntryType Increment = new("increment");

    readonly string _value = value;

    public enum Value
    {
        Increment,
    }

    public Value Known() =>
        _value switch
        {
            "increment" => Value.Increment,
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
