using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionFetchUsageParamsProperties;

/// <summary>
/// This determines the windowing of usage reporting.
/// </summary>
[JsonConverter(typeof(EnumConverter<Granularity, string>))]
public sealed record class Granularity(string value) : IEnum<Granularity, string>
{
    public static readonly Granularity Day = new("day");

    readonly string _value = value;

    public enum Value
    {
        Day,
    }

    public Value Known() =>
        _value switch
        {
            "day" => Value.Day,
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

    public static Granularity FromRaw(string value)
    {
        return new(value);
    }
}
