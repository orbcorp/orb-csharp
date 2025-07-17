using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger.LedgerListParamsProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<EntryType, string>))]
public sealed record class EntryType(string value) : Orb::IEnum<EntryType, string>
{
    public static readonly EntryType Increment = new("increment");

    public static readonly EntryType Decrement = new("decrement");

    public static readonly EntryType ExpirationChange = new("expiration_change");

    public static readonly EntryType CreditBlockExpiry = new("credit_block_expiry");

    public static readonly EntryType Void = new("void");

    public static readonly EntryType VoidInitiated = new("void_initiated");

    public static readonly EntryType Amendment = new("amendment");

    readonly string _value = value;

    public enum Value
    {
        Increment,
        Decrement,
        ExpirationChange,
        CreditBlockExpiry,
        Void,
        VoidInitiated,
        Amendment,
    }

    public Value Known() =>
        _value switch
        {
            "increment" => Value.Increment,
            "decrement" => Value.Decrement,
            "expiration_change" => Value.ExpirationChange,
            "credit_block_expiry" => Value.CreditBlockExpiry,
            "void" => Value.Void,
            "void_initiated" => Value.VoidInitiated,
            "amendment" => Value.Amendment,
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
