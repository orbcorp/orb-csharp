using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.Ledger.IncrementLedgerEntryProperties;

[JsonConverter(typeof(EnumConverter<EntryStatus, string>))]
public sealed record class EntryStatus(string value) : IEnum<EntryStatus, string>
{
    public static readonly EntryStatus Committed = new("committed");

    public static readonly EntryStatus Pending = new("pending");

    readonly string _value = value;

    public enum Value
    {
        Committed,
        Pending,
    }

    public Value Known() =>
        _value switch
        {
            "committed" => Value.Committed,
            "pending" => Value.Pending,
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

    public static EntryStatus FromRaw(string value)
    {
        return new(value);
    }
}
