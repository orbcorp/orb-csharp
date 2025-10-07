using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Customers.CustomerUpdateParamsProperties.TaxConfigurationProperties.NumeralProperties;

[JsonConverter(typeof(Converter))]
public class TaxProvider
{
    public JsonElement Json { get; private init; }

    public TaxProvider()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"numeral\"");
    }

    TaxProvider(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new TaxProvider().Json))
        {
            throw new OrbInvalidDataException("Invalid constant given for 'TaxProvider'");
        }
    }

    private class Converter : JsonConverter<TaxProvider>
    {
        public override TaxProvider? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            TaxProvider value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}
