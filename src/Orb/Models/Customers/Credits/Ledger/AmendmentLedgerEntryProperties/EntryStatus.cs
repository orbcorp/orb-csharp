using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Customers.Credits.Ledger.AmendmentLedgerEntryProperties;

[JsonConverter(typeof(EntryStatusConverter))]
public enum EntryStatus
{
    Committed,
    Pending,
}

sealed class EntryStatusConverter : JsonConverter<EntryStatus>
{
    public override EntryStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "committed" => EntryStatus.Committed,
            "pending" => EntryStatus.Pending,
            _ => (EntryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntryStatus.Committed => "committed",
                EntryStatus.Pending => "pending",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
