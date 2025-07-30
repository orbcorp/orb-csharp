using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.TopUps.TopUpCreateByExternalIDResponseProperties;

/// <summary>
/// The unit of expires_after.
/// </summary>
[JsonConverter(typeof(EnumConverter<ExpiresAfterUnit, string>))]
public sealed record class ExpiresAfterUnit(string value) : IEnum<ExpiresAfterUnit, string>
{
    public static readonly ExpiresAfterUnit Day = new("day");

    public static readonly ExpiresAfterUnit Month = new("month");

    readonly string _value = value;

    public enum Value
    {
        Day,
        Month,
    }

    public Value Known() =>
        _value switch
        {
            "day" => Value.Day,
            "month" => Value.Month,
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

    public static ExpiresAfterUnit FromRaw(string value)
    {
        return new(value);
    }
}
