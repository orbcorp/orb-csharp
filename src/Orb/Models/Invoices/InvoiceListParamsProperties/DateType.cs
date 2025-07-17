using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Invoices.InvoiceListParamsProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<DateType, string>))]
public sealed record class DateType(string value) : Orb::IEnum<DateType, string>
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

    public static DateType FromRaw(string value)
    {
        return new(value);
    }
}
