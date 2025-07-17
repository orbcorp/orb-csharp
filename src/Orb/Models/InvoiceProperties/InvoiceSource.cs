using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.InvoiceProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<InvoiceSource, string>))]
public sealed record class InvoiceSource(string value) : Orb::IEnum<InvoiceSource, string>
{
    public static readonly InvoiceSource Subscription = new("subscription");

    public static readonly InvoiceSource Partial = new("partial");

    public static readonly InvoiceSource OneOff = new("one_off");

    readonly string _value = value;

    public enum Value
    {
        Subscription,
        Partial,
        OneOff,
    }

    public Value Known() =>
        _value switch
        {
            "subscription" => Value.Subscription,
            "partial" => Value.Partial,
            "one_off" => Value.OneOff,
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

    public static InvoiceSource FromRaw(string value)
    {
        return new(value);
    }
}
