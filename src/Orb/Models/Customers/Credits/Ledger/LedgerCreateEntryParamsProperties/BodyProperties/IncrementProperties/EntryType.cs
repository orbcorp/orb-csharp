using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryParamsProperties.BodyProperties.IncrementProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<EntryType, string>))]
public sealed record class EntryType(string value) : Orb::IEnum<EntryType, string>
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
