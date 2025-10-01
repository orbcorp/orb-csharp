using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Subscriptions.SubscriptionCancelParamsProperties;

/// <summary>
/// Determines the timing of subscription cancellation
/// </summary>
[JsonConverter(typeof(CancelOptionConverter))]
public enum CancelOption
{
    EndOfSubscriptionTerm,
    Immediate,
    RequestedDate,
}

sealed class CancelOptionConverter : JsonConverter<CancelOption>
{
    public override CancelOption Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "end_of_subscription_term" => CancelOption.EndOfSubscriptionTerm,
            "immediate" => CancelOption.Immediate,
            "requested_date" => CancelOption.RequestedDate,
            _ => (CancelOption)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CancelOption value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CancelOption.EndOfSubscriptionTerm => "end_of_subscription_term",
                CancelOption.Immediate => "immediate",
                CancelOption.RequestedDate => "requested_date",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
