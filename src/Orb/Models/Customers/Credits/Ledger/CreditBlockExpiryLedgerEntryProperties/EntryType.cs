using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.Ledger.CreditBlockExpiryLedgerEntryProperties;

[JsonConverter(typeof(EnumConverter<EntryType, string>))]
public sealed record class EntryType(string value) : IEnum<EntryType, string>
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
