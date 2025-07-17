using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.SubscriptionChanges.SubscriptionChangeCancelResponseProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<Status, string>))]
public sealed record class Status(string value) : Orb::IEnum<Status, string>
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
