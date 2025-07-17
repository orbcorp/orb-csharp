using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.CreditNoteProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<Reason, string>))]
public sealed record class Reason(string value) : Orb::IEnum<Reason, string>
{
    public static readonly Reason Duplicate = new("Duplicate");

    public static readonly Reason Fraudulent = new("Fraudulent");

    public static readonly Reason OrderChange = new("Order change");

    public static readonly Reason ProductUnsatisfactory = new("Product unsatisfactory");

    readonly string _value = value;

    public enum Value
    {
        Duplicate,
        Fraudulent,
        OrderChange,
        ProductUnsatisfactory,
    }

    public Value Known() =>
        _value switch
        {
            "Duplicate" => Value.Duplicate,
            "Fraudulent" => Value.Fraudulent,
            "Order change" => Value.OrderChange,
            "Product unsatisfactory" => Value.ProductUnsatisfactory,
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

    public static Reason FromRaw(string value)
    {
        return new(value);
    }
}
