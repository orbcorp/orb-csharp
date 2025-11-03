using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Coupons.CouponCreateParamsProperties.DiscountProperties.AmountProperties;

[JsonConverter(typeof(Converter))]
public class DiscountType
{
    public JsonElement Json { get; private init; }

    public DiscountType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"amount\"");
    }

    DiscountType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new DiscountType().Json))
        {
            throw new OrbInvalidDataException("Invalid constant given for 'DiscountType'");
        }
    }

    class Converter : JsonConverter<DiscountType>
    {
        public override DiscountType? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            DiscountType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}
