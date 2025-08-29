using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionRedeemCouponParamsProperties;

[JsonConverter(typeof(ChangeOptionConverter))]
public enum ChangeOption
{
    RequestedDate,
    EndOfSubscriptionTerm,
    Immediate,
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
            "requested_date" => ChangeOption.RequestedDate,
            "end_of_subscription_term" => ChangeOption.EndOfSubscriptionTerm,
            "immediate" => ChangeOption.Immediate,
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
                ChangeOption.RequestedDate => "requested_date",
                ChangeOption.EndOfSubscriptionTerm => "end_of_subscription_term",
                ChangeOption.Immediate => "immediate",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
