using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.NewAmountDiscountProperties;

/// <summary>
/// If set, the adjustment will apply to every price on the subscription.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::EnumConverter<AppliesToAll, bool>))]
public sealed record class AppliesToAll(bool value) : Orb::IEnum<AppliesToAll, bool>
{
    public static readonly AppliesToAll True = new(true);

    readonly bool _value = value;

    public enum Value
    {
        True,
    }

    public Value Known() =>
        _value switch
        {
            true => Value.True,
            _ => throw new System::ArgumentOutOfRangeException(nameof(_value)),
        };

    public bool Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static AppliesToAll FromRaw(bool value)
    {
        return new(value);
    }
}
