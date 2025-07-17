using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.Credits.TopUps.TopUpListPageResponseProperties.DataProperties;

/// <summary>
/// The unit of expires_after.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::EnumConverter<ExpiresAfterUnit, string>))]
public sealed record class ExpiresAfterUnit(string value) : Orb::IEnum<ExpiresAfterUnit, string>
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

    public static ExpiresAfterUnit FromRaw(string value)
    {
        return new(value);
    }
}
