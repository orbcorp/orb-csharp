using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(BillingCycleRelativeDateConverter))]
public enum BillingCycleRelativeDate
{
    StartOfTerm,
    EndOfTerm,
}

sealed class BillingCycleRelativeDateConverter : JsonConverter<BillingCycleRelativeDate>
{
    public override BillingCycleRelativeDate Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "start_of_term" => BillingCycleRelativeDate.StartOfTerm,
            "end_of_term" => BillingCycleRelativeDate.EndOfTerm,
            _ => (BillingCycleRelativeDate)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BillingCycleRelativeDate value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BillingCycleRelativeDate.StartOfTerm => "start_of_term",
                BillingCycleRelativeDate.EndOfTerm => "end_of_term",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
