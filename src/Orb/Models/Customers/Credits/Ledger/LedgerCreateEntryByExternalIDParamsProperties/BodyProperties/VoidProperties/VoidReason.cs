using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties.VoidProperties;

/// <summary>
/// Can only be specified when `entry_type=void`. The reason for the void.
/// </summary>
[JsonConverter(typeof(EnumConverter<VoidReason, string>))]
public sealed record class VoidReason(string value) : IEnum<VoidReason, string>
{
    public static readonly VoidReason Refund = new("refund");

    readonly string _value = value;

    public enum Value
    {
        Refund,
    }

    public Value Known() =>
        _value switch
        {
            "refund" => Value.Refund,
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

    public static VoidReason FromRaw(string value)
    {
        return new(value);
    }
}
