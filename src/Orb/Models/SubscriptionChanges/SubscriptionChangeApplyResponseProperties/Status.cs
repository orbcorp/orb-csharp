using System;
using System.Text.Json.Serialization;

namespace Orb.Models.SubscriptionChanges.SubscriptionChangeApplyResponseProperties;

[JsonConverter(typeof(EnumConverter<Status, string>))]
public sealed record class Status(string value) : IEnum<Status, string>
{
    public static readonly Status Pending = new("pending");

    public static readonly Status Applied = new("applied");

    public static readonly Status Cancelled = new("cancelled");

    readonly string _value = value;

    public enum Value
    {
        Pending,
        Applied,
        Cancelled,
    }

    public Value Known() =>
        _value switch
        {
            "pending" => Value.Pending,
            "applied" => Value.Applied,
            "cancelled" => Value.Cancelled,
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
