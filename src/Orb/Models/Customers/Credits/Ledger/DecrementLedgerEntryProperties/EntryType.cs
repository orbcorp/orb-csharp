using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.Ledger.DecrementLedgerEntryProperties;

[JsonConverter(typeof(EnumConverter<EntryType, string>))]
public sealed record class EntryType(string value) : IEnum<EntryType, string>
{
    public static readonly EntryType Decrement = new("decrement");

    readonly string _value = value;

    public enum Value
    {
        Decrement,
    }

    public Value Known() =>
        _value switch
        {
            "decrement" => Value.Decrement,
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
