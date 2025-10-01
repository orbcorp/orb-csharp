using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties.VoidProperties;

/// <summary>
/// Can only be specified when `entry_type=void`. The reason for the void.
/// </summary>
[JsonConverter(typeof(VoidReasonConverter))]
public enum VoidReason
{
    Refund,
}

sealed class VoidReasonConverter : JsonConverter<VoidReason>
{
    public override VoidReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "refund" => VoidReason.Refund,
            _ => (VoidReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoidReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VoidReason.Refund => "refund",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
