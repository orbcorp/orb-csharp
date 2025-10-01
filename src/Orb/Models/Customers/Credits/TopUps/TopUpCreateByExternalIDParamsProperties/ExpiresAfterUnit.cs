using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Customers.Credits.TopUps.TopUpCreateByExternalIDParamsProperties;

/// <summary>
/// The unit of expires_after.
/// </summary>
[JsonConverter(typeof(ExpiresAfterUnitConverter))]
public enum ExpiresAfterUnit
{
    Day,
    Month,
}

sealed class ExpiresAfterUnitConverter : JsonConverter<ExpiresAfterUnit>
{
    public override ExpiresAfterUnit Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "day" => ExpiresAfterUnit.Day,
            "month" => ExpiresAfterUnit.Month,
            _ => (ExpiresAfterUnit)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExpiresAfterUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExpiresAfterUnit.Day => "day",
                ExpiresAfterUnit.Month => "month",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
