using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.CreditListPageResponseProperties.DataProperties;

[JsonConverter(typeof(EnumConverter<Status, string>))]
public sealed record class Status(string value) : IEnum<Status, string>
{
    public static readonly Status Active = new("active");

    public static readonly Status PendingPayment = new("pending_payment");

    readonly string _value = value;

    public enum Value
    {
        Active,
        PendingPayment,
    }

    public Value Known() =>
        _value switch
        {
            "active" => Value.Active,
            "pending_payment" => Value.PendingPayment,
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
