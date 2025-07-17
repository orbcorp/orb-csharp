using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger.CreditBlockExpiryLedgerEntryProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<EntryType, string>))]
public sealed record class EntryType(string value) : Orb::IEnum<EntryType, string>
{
    public static readonly EntryType CreditBlockExpiry = new("credit_block_expiry");

    readonly string _value = value;

    public enum Value
    {
        CreditBlockExpiry,
    }

    public Value Known() =>
        _value switch
        {
            "credit_block_expiry" => Value.CreditBlockExpiry,
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

    public static EntryType FromRaw(string value)
    {
        return new(value);
    }
}
