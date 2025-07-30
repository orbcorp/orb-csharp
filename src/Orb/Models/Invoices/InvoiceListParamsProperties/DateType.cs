using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Invoices.InvoiceListParamsProperties;

[JsonConverter(typeof(EnumConverter<DateType, string>))]
public sealed record class DateType(string value) : IEnum<DateType, string>
{
    public static readonly DateType DueDate = new("due_date");

    public static readonly DateType InvoiceDate = new("invoice_date");

    readonly string _value = value;

    public enum Value
    {
        DueDate,
        InvoiceDate,
    }

    public Value Known() =>
        _value switch
        {
            "due_date" => Value.DueDate,
            "invoice_date" => Value.InvoiceDate,
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

    public static DateType FromRaw(string value)
    {
        return new(value);
    }
}
