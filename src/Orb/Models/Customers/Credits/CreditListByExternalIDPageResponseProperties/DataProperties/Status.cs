using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.Credits.CreditListByExternalIDPageResponseProperties.DataProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<Status, string>))]
public sealed record class Status(string value) : Orb::IEnum<Status, string>
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
