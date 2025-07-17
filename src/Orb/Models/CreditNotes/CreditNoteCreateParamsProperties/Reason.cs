using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.CreditNotes.CreditNoteCreateParamsProperties;

/// <summary>
/// An optional reason for the credit note.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::EnumConverter<Reason, string>))]
public sealed record class Reason(string value) : Orb::IEnum<Reason, string>
{
    public static readonly Reason Duplicate = new("duplicate");

    public static readonly Reason Fraudulent = new("fraudulent");

    public static readonly Reason OrderChange = new("order_change");

    public static readonly Reason ProductUnsatisfactory = new("product_unsatisfactory");

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
            "duplicate" => Value.Duplicate,
            "fraudulent" => Value.Fraudulent,
            "order_change" => Value.OrderChange,
            "product_unsatisfactory" => Value.ProductUnsatisfactory,
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
