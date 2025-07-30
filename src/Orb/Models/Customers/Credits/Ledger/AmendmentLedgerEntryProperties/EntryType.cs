using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.Ledger.AmendmentLedgerEntryProperties;

[JsonConverter(typeof(EnumConverter<EntryType, string>))]
public sealed record class EntryType(string value) : IEnum<EntryType, string>
{
    public static readonly EntryType Amendment = new("amendment");

    readonly string _value = value;

    public enum Value
    {
        Amendment,
    }

    public Value Known() =>
        _value switch
        {
            "amendment" => Value.Amendment,
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
