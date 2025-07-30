using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Invoices.InvoiceFetchUpcomingResponseProperties;

[JsonConverter(typeof(EnumConverter<Status, string>))]
public sealed record class Status(string value) : IEnum<Status, string>
{
    public static readonly Status Issued = new("issued");

    public static readonly Status Paid = new("paid");

    public static readonly Status Synced = new("synced");

    public static readonly Status Void = new("void");

    public static readonly Status Draft = new("draft");

    readonly string _value = value;

    public enum Value
    {
        Issued,
        Paid,
        Synced,
        Void,
        Draft,
    }

    public Value Known() =>
        _value switch
        {
            "issued" => Value.Issued,
            "paid" => Value.Paid,
            "synced" => Value.Synced,
            "void" => Value.Void,
            "draft" => Value.Draft,
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
