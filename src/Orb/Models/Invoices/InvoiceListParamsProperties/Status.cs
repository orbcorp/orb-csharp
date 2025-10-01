using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Invoices.InvoiceListParamsProperties;

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Draft,
    Issued,
    Paid,
    Synced,
    Void,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "draft" => Status.Draft,
            "issued" => Status.Issued,
            "paid" => Status.Paid,
            "synced" => Status.Synced,
            "void" => Status.Void,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Draft => "draft",
                Status.Issued => "issued",
                Status.Paid => "paid",
                Status.Synced => "synced",
                Status.Void => "void",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
