using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<ChangeOption, string>))]
public sealed record class ChangeOption(string value) : Orb::IEnum<ChangeOption, string>
{
    public static readonly ChangeOption RequestedDate = new("requested_date");

    public static readonly ChangeOption EndOfSubscriptionTerm = new("end_of_subscription_term");

    public static readonly ChangeOption Immediate = new("immediate");

    readonly string _value = value;

    public enum Value
    {
        RequestedDate,
        EndOfSubscriptionTerm,
        Immediate,
    }

    public Value Known() =>
        _value switch
        {
            "requested_date" => Value.RequestedDate,
            "end_of_subscription_term" => Value.EndOfSubscriptionTerm,
            "immediate" => Value.Immediate,
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

    public static ChangeOption FromRaw(string value)
    {
        return new(value);
    }
}
