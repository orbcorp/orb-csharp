using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties.TrialEndDateProperties;

[JsonConverter(typeof(UnionMember1Converter))]
public enum UnionMember1
{
    Immediate,
}

sealed class UnionMember1Converter : JsonConverter<UnionMember1>
{
    public override UnionMember1 Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "immediate" => UnionMember1.Immediate,
            _ => (UnionMember1)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionMember1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionMember1.Immediate => "immediate",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
