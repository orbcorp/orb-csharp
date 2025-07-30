using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Invoices.InvoiceListParamsProperties;

[JsonConverter(typeof(EnumConverter<Status, string>))]
public sealed record class Status(string value) : IEnum<Status, string>
{
    public static readonly Status Draft = new("draft");

    public static readonly Status Issued = new("issued");

    public static readonly Status Paid = new("paid");

    public static readonly Status Synced = new("synced");

    public static readonly Status Void = new("void");

    readonly string _value = value;

    public enum Value
    {
        Draft,
        Issued,
        Paid,
        Synced,
        Void,
    }

    public Value Known() =>
        _value switch
        {
            "draft" => Value.Draft,
            "issued" => Value.Issued,
            "paid" => Value.Paid,
            "synced" => Value.Synced,
            "void" => Value.Void,
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
