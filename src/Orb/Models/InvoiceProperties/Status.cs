using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.InvoiceProperties;

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Issued,
    Paid,
    Synced,
    Void,
    Draft,
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
            "issued" => Status.Issued,
            "paid" => Status.Paid,
            "synced" => Status.Synced,
            "void" => Status.Void,
            "draft" => Status.Draft,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Issued => "issued",
                Status.Paid => "paid",
                Status.Synced => "synced",
                Status.Void => "void",
                Status.Draft => "draft",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
