using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties.VoidProperties;

[JsonConverter(typeof(Converter))]
public class EntryType
{
    public JsonElement Json { get; private init; }

    public EntryType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"void\"");
    }

    EntryType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new EntryType().Json))
        {
            throw new OrbInvalidDataException("Invalid constant given for 'EntryType'");
        }
    }

    class Converter : JsonConverter<EntryType>
    {
        public override EntryType? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            EntryType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}
