using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.Ledger.ExpirationChangeLedgerEntryProperties;

[JsonConverter(typeof(EntryTypeConverter))]
public enum EntryType
{
    ExpirationChange,
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
            "expiration_change" => EntryType.ExpirationChange,
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
                EntryType.ExpirationChange => "expiration_change",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
