using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.Ledger.VoidLedgerEntryProperties;

[JsonConverter(typeof(EnumConverter<EntryType, string>))]
public sealed record class EntryType(string value) : IEnum<EntryType, string>
{
    public static readonly EntryType Void = new("void");

    readonly string _value = value;

    public enum Value
    {
        Void,
    }

    public Value Known() =>
        _value switch
        {
            "void" => Value.Void,
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
