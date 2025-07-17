using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Invoices.InvoiceFetchUpcomingResponseProperties.CustomerBalanceTransactionProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<Type, string>))]
public sealed record class Type(string value) : Orb::IEnum<Type, string>
{
    public static readonly Type Increment = new("increment");

    public static readonly Type Decrement = new("decrement");

    readonly string _value = value;

    public enum Value
    {
        Increment,
        Decrement,
    }

    public Value Known() =>
        _value switch
        {
            "increment" => Value.Increment,
            "decrement" => Value.Decrement,
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

    public static Type FromRaw(string value)
    {
        return new(value);
    }
}
