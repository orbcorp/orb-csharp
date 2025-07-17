using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger.VoidInitiatedLedgerEntryProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<EntryStatus, string>))]
public sealed record class EntryStatus(string value) : Orb::IEnum<EntryStatus, string>
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

    public static EntryStatus FromRaw(string value)
    {
        return new(value);
    }
}
