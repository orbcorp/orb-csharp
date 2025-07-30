using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.Ledger.VoidInitiatedLedgerEntryProperties;

[JsonConverter(typeof(EnumConverter<EntryType, string>))]
public sealed record class EntryType(string value) : IEnum<EntryType, string>
{
    public static readonly EntryType VoidInitiated = new("void_initiated");

    readonly string _value = value;

    public enum Value
    {
        VoidInitiated,
    }

    public Value Known() =>
        _value switch
        {
            "void_initiated" => Value.VoidInitiated,
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
