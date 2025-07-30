using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionProperties;

[JsonConverter(typeof(EnumConverter<Status, string>))]
public sealed record class Status(string value) : IEnum<Status, string>
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

    public static Status FromRaw(string value)
    {
        return new(value);
    }
}
