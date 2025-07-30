using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionCancelParamsProperties;

/// <summary>
/// Determines the timing of subscription cancellation
/// </summary>
[JsonConverter(typeof(EnumConverter<CancelOption, string>))]
public sealed record class CancelOption(string value) : IEnum<CancelOption, string>
{
    public static readonly CancelOption EndOfSubscriptionTerm = new("end_of_subscription_term");

    public static readonly CancelOption Immediate = new("immediate");

    public static readonly CancelOption RequestedDate = new("requested_date");

    readonly string _value = value;

    public enum Value
    {
        EndOfSubscriptionTerm,
        Immediate,
        RequestedDate,
    }

    public Value Known() =>
        _value switch
        {
            "end_of_subscription_term" => Value.EndOfSubscriptionTerm,
            "immediate" => Value.Immediate,
            "requested_date" => Value.RequestedDate,
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

    public static CancelOption FromRaw(string value)
    {
        return new(value);
    }
}
