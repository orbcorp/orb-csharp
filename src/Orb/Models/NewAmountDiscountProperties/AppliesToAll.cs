using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.NewAmountDiscountProperties;

/// <summary>
/// If set, the adjustment will apply to every price on the subscription.
/// </summary>
[JsonConverter(typeof(AppliesToAllConverter))]
public enum AppliesToAll
{
    True,
}

sealed class AppliesToAllConverter : JsonConverter<AppliesToAll>
{
    public override AppliesToAll Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => AppliesToAll.True,
            _ => (AppliesToAll)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AppliesToAll value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AppliesToAll.True => true,
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
