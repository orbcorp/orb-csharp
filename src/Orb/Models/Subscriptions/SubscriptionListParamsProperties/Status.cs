using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionListParamsProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<Status, string>))]
public sealed record class Status(string value) : Orb::IEnum<Status, string>
{
    public static readonly Status Active = new("active");

    public static readonly Status Ended = new("ended");

    public static readonly Status Upcoming = new("upcoming");

    readonly string _value = value;

    public enum Value
    {
        Active,
        Ended,
        Upcoming,
    }

    public Value Known() =>
        _value switch
        {
            "active" => Value.Active,
            "ended" => Value.Ended,
            "upcoming" => Value.Upcoming,
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

    public static Status FromRaw(string value)
    {
        return new(value);
    }
}
