using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionUsageProperties.GroupedSubscriptionUsageProperties.DataProperties;

[JsonConverter(typeof(EnumConverter<ViewMode, string>))]
public sealed record class ViewMode(string value) : IEnum<ViewMode, string>
{
    public static readonly ViewMode Periodic = new("periodic");

    public static readonly ViewMode Cumulative = new("cumulative");

    readonly string _value = value;

    public enum Value
    {
        Periodic,
        Cumulative,
    }

    public Value Known() =>
        _value switch
        {
            "periodic" => Value.Periodic,
            "cumulative" => Value.Cumulative,
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

    public static ViewMode FromRaw(string value)
    {
        return new(value);
    }
}
