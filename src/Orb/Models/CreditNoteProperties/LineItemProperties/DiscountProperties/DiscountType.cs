using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.CreditNoteProperties.LineItemProperties.DiscountProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<DiscountType, string>))]
public sealed record class DiscountType(string value) : Orb::IEnum<DiscountType, string>
{
    public static readonly DiscountType Percentage = new("percentage");

    public static readonly DiscountType Amount = new("amount");

    readonly string _value = value;

    public enum Value
    {
        Percentage,
        Amount,
    }

    public Value Known() =>
        _value switch
        {
            "percentage" => Value.Percentage,
            "amount" => Value.Amount,
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

    public static DiscountType FromRaw(string value)
    {
        return new(value);
    }
}
