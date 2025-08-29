using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionUpdateFixedFeeQuantityParamsProperties;

/// <summary>
/// Determines when the change takes effect. Note that if `effective_date` is specified,
/// this defaults to `effective_date`. Otherwise, this defaults to `immediate` unless
/// it's explicitly set to `upcoming_invoice`.
/// </summary>
[JsonConverter(typeof(ChangeOptionConverter))]
public enum ChangeOption
{
    Immediate,
    UpcomingInvoice,
    EffectiveDate,
}

sealed class ChangeOptionConverter : JsonConverter<ChangeOption>
{
    public override ChangeOption Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "immediate" => ChangeOption.Immediate,
            "upcoming_invoice" => ChangeOption.UpcomingInvoice,
            "effective_date" => ChangeOption.EffectiveDate,
            _ => (ChangeOption)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChangeOption value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChangeOption.Immediate => "immediate",
                ChangeOption.UpcomingInvoice => "upcoming_invoice",
                ChangeOption.EffectiveDate => "effective_date",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
