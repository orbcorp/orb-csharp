using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionFetchUsageParamsProperties;

/// <summary>
/// This determines the windowing of usage reporting.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::EnumConverter<Granularity, string>))]
public sealed record class Granularity(string value) : Orb::IEnum<Granularity, string>
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

    public static Granularity FromRaw(string value)
    {
        return new(value);
    }
}
