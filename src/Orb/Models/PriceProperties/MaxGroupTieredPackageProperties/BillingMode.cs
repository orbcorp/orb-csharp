using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.PriceProperties.MaxGroupTieredPackageProperties;

[JsonConverter(typeof(BillingModeConverter))]
public enum BillingMode
{
    InAdvance,
    InArrear,
}

sealed class BillingModeConverter : JsonConverter<BillingMode>
{
    public override BillingMode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in_advance" => BillingMode.InAdvance,
            "in_arrear" => BillingMode.InArrear,
            _ => (BillingMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BillingMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BillingMode.InAdvance => "in_advance",
                BillingMode.InArrear => "in_arrear",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
