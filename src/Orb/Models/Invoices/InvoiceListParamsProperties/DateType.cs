using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Invoices.InvoiceListParamsProperties;

[JsonConverter(typeof(DateTypeConverter))]
public enum DateType
{
    DueDate,
    InvoiceDate,
}

sealed class DateTypeConverter : JsonConverter<DateType>
{
    public override DateType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "due_date" => DateType.DueDate,
            "invoice_date" => DateType.InvoiceDate,
            _ => (DateType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, DateType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DateType.DueDate => "due_date",
                DateType.InvoiceDate => "invoice_date",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
