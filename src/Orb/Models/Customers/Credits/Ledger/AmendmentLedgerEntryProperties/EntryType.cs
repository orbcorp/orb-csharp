using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.Ledger.AmendmentLedgerEntryProperties;

[JsonConverter(typeof(EntryTypeConverter))]
public enum EntryType
{
    Amendment,
}

sealed class EntryTypeConverter : JsonConverter<EntryType>
{
    public override EntryType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "amendment" => EntryType.Amendment,
            _ => (EntryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntryType.Amendment => "amendment",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
