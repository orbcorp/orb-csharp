using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.ReplacePriceProperties.PriceProperties.BulkWithFiltersProperties;

/// <summary>
/// The pricing model type
/// </summary>
[JsonConverter(typeof(Converter))]
public class ModelType
{
    public JsonElement Json { get; private init; }

    public ModelType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"bulk_with_filters\"");
    }

    ModelType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new ModelType().Json))
        {
            throw new OrbInvalidDataException("Invalid constant given for 'ModelType'");
        }
    }

    private class Converter : JsonConverter<ModelType>
    {
        public override ModelType? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            ModelType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}
