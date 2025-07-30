using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionUpdateFixedFeeQuantityParamsProperties;

/// <summary>
/// Determines when the change takes effect. Note that if `effective_date` is specified,
/// this defaults to `effective_date`. Otherwise, this defaults to `immediate` unless
/// it's explicitly set to `upcoming_invoice`.
/// </summary>
[JsonConverter(typeof(EnumConverter<ChangeOption, string>))]
public sealed record class ChangeOption(string value) : IEnum<ChangeOption, string>
{
    public static readonly ChangeOption Immediate = new("immediate");

    public static readonly ChangeOption UpcomingInvoice = new("upcoming_invoice");

    public static readonly ChangeOption EffectiveDate = new("effective_date");

    readonly string _value = value;

    public enum Value
    {
        Immediate,
        UpcomingInvoice,
        EffectiveDate,
    }

    public Value Known() =>
        _value switch
        {
            "immediate" => Value.Immediate,
            "upcoming_invoice" => Value.UpcomingInvoice,
            "effective_date" => Value.EffectiveDate,
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

    public static ChangeOption FromRaw(string value)
    {
        return new(value);
    }
}
